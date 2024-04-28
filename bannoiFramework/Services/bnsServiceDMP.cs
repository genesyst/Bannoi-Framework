using bannoiFramework.Dataset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bannoiFramework.Services
{
    public class bnsServiceDMP
    {
        public bnsServiceDMP()
        {
            
        }

        public static string getEmpFullName(string empCode)
        {
            string Res = null;
            try
            {
                using (BNSDATA_EHREntities db = new BNSDATA_EHREntities())
                {
                    var emp = (from p in db.EMPLOYEE
                               where p.EMPSTT != "8" && p.EMPCODE == empCode
                               select new { p.EMPTNAME, p.EMPLNAME, p.EMPFNAME }).FirstOrDefault();
                    if (emp != null)
                        Res = emp.EMPTNAME + emp.EMPFNAME + "  " + emp.EMPLNAME;
                }
            }
            catch { throw; }
            return Res;
        }

        public static bool gantUserTo(BNSDATA_EHREntities db, SIN_USERGANT gantModel)
        {
            bool Res = false;
            try
            {
                var isExist = db.SIN_USERGANT.Where(
                    c=>c.SIGNID==gantModel.SIGNID && c.SYSTEMCODE==gantModel.SYSTEMCODE && c.SYSTEMVERSION==gantModel.SYSTEMVERSION).FirstOrDefault();
                if (isExist != null)
                {
                    if (isExist.STT == "X")
                    {
                        isExist.STT = "E";
                        isExist.UPDATE_BY = gantModel.CREATE_BY;
                        isExist.UPDATE_DATE = DateTime.Now;
                        db.SaveChanges();
                        Res = true;
                    }
                    Res = true;
                }
                else
                {
                    db.SIN_USERGANT.Add(gantModel);
                    db.SaveChanges();
                    Res = true;
                }
            }
            catch { throw; }
            return Res;
        }
    }
}
