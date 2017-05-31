using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NAN.ZHAN.DAL
{
    public class MeetingServices
    {
        public List<HR_MeettingSetting> GetMeetingSetting(Expression<Func<HR_MeettingSetting, bool>> predicate)
        {
            using (NanZhanDBEntities nz = new NanZhanDBEntities())
            {
                nz.Configuration.ProxyCreationEnabled = false;
                return nz.HR_MeettingSetting.Where<HR_MeettingSetting>(predicate).ToList<HR_MeettingSetting>();
            }
        }

        public int AddMeetingSetting(HR_MeettingSetting meetting)
        {
            try
            {
                using (NanZhanDBEntities nz = new NanZhanDBEntities())
                {
                    nz.HR_MeettingSetting.Add(meetting);
                    return nz.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int EidtMeettingSetting(HR_MeettingSetting meetting)
        {
            try
            {
                using (NanZhanDBEntities nz = new NanZhanDBEntities())
                {
                    nz.Set<HR_MeettingSetting>().Attach(meetting);
                    nz.Entry<HR_MeettingSetting>(meetting).State = System.Data.Entity.EntityState.Modified;
                    return nz.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                return 0;
            
            }
        }

        //逻辑删除

        public int DeleteMeetingSetting(int m_id)
        {
            try
            {
                using (NanZhanDBEntities nz = new NanZhanDBEntities())
                {
                    HR_MeettingSetting meet = nz.HR_MeettingSetting.Where<HR_MeettingSetting>(p => p.m_id == m_id).SingleOrDefault();
                    meet.m_isOpen = 0;
                    nz.Set<HR_MeettingSetting>().Attach(meet);
                    nz.Entry<HR_MeettingSetting>(meet).State = System.Data.Entity.EntityState.Modified;
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
