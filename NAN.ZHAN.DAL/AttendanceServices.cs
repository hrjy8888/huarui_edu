using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NAN.ZHAN.DAL
{
    public class AttendanceServices
    {
        public List<V_Attendance_Emp_Meetting> GetAttendance_Emp_Meetting(Expression<Func<V_Attendance_Emp_Meetting, bool>> predicate)
        {
            using (NanZhanDBEntities nz = new NanZhanDBEntities())
            {
                return nz.V_Attendance_Emp_Meetting
                    .Where<V_Attendance_Emp_Meetting>(predicate.Compile())
                    .AsQueryable()
                    .OrderByDescending(o => o.a_id)
                    .ToList<V_Attendance_Emp_Meetting>();
            }
        }
    }
}
