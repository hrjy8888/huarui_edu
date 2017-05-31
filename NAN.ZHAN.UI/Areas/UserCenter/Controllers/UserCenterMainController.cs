using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAN.ZHAN.DAL;
using System.Linq.Expressions;

namespace NAN.ZHAN.UI.Areas.UserCenter.Controllers
{
    public class UserCenterMainController : Controller
    {

        private EmployeeServices emp_services = new EmployeeServices();

        // GET: UserCenter/UserCenterMain/UserList
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult UserList()
        {
            string uname = Request["uname"];
            string mobile = Request["mobile"];
            Expression<Func<HR_Employee, bool>> predicate = PredicateBuilder.True<HR_Employee>();
            if (!string.IsNullOrEmpty(uname))
            {
                // predicate= b => b.e_loginid.Contains(uname);
                predicate = predicate.And(p => p.e_loginid.Contains(uname));
            }
            if (!string.IsNullOrEmpty(mobile))
            {
                predicate = predicate.And(p => p.e_mobile.Contains(mobile));
            }
            List<HR_Employee> emp_list = emp_services.GetEmployeeList(predicate);

            return Json(emp_list);
        }

        [HttpPost]
        public ActionResult UserAdd(HR_Employee emp)
        {
            emp.e_pwd = "888888";
            emp.e_state = 1;
            int count= emp_services.AddEmployee(emp);
            return Json(count == 1 ? new { msg = "op_success" }:new { msg="op_fail"});
        }

        [HttpPost]
        public ActionResult UserEdit(HR_Employee emp)
        {
            int count = emp_services.EditEmployee(emp);
            return Json(count == 1 ? new { msg = "op_success" } : new { msg = "op_fail" });
        }

        [HttpPost]
        public JsonResult GetUserSingle(int e_id)
        {
            Expression<Func<HR_Employee, bool>> predicate = s => s.e_id == e_id;
            HR_Employee emp= emp_services.GetEmployeeList(predicate)[0];
            return Json(emp);
        }
        //删除
        [HttpPost]
        public ActionResult UserDelete(int e_id)
        {
            int count=emp_services.DeleteEmployee(e_id);
            return Json(count == 1 ? new { msg = "op_success" } : new { msg = "op_fail" });
            
        }


    }
}