using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LinqKit;


namespace NAN.ZHAN.DAL
{
    public class EmployeeServices
    {
        public List<HR_Employee> GetEmployeeList(Expression<Func<HR_Employee, bool>> predicate)
        {
            using (NanZhanDBEntities nz= new NanZhanDBEntities())
            {
                nz.Configuration.ProxyCreationEnabled = false;
                //var list_emp = nz.HR_Employee.Where<HR_Employee>(predicate).OrderByDescending(s=>s.e_id).ToList<HR_Employee>();
                //return list_emp;
                return nz.Set<HR_Employee>().AsExpandable().Where(predicate).ToList<HR_Employee>();
            }
        }

        public int AddEmployee(HR_Employee emp)
        {
            
            try
            {
                using (NanZhanDBEntities nz = new NanZhanDBEntities())
                {
                    nz.HR_Employee.Add(emp);
                    return nz.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }
           
        }

        //修改
        public int EditEmployee(HR_Employee emp)
        {
            try
            {
                using (NanZhanDBEntities nz = new NanZhanDBEntities())
                {
                    nz.Set<HR_Employee>().Attach(emp);
                    nz.Entry<HR_Employee>(emp).State = System.Data.Entity.EntityState.Modified;
                    return nz.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }
           
           
        }

        //删除
        public int DeleteEmployee(int id)
        {
            try
            {
                using (NanZhanDBEntities nz = new NanZhanDBEntities())
                {
                    HR_Employee emp = nz.HR_Employee.SingleOrDefault<HR_Employee>(s => s.e_id == id);
                    nz.HR_Employee.Remove(emp);
                    return nz.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }
          
        }
    }
}
