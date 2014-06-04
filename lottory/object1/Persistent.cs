using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottory.object1
{
    public class Persistent
    {
        public String table = "";
        public String pkField = "";
        public String sited = "";
        public String dateGenDB = "Format(Now(),'yyyy')+'-'+Format(Now(),'mm')+'-'+Format(Now(),'dd')+' '+Format(Now(),'hh:nn:ss')";
        public String getdDateDBtoShow = "Select Format(Now(),'dd')+'-'+Format(Now(),'mm')+'-'+Format(Now(),'yyyy')+' '+Format(Now(),'hh:nn:ss') as date1";
        public String getCBdl = "cdbl(Now())";
        Random r = new Random();
        Random r1 = new Random();
        //String[] rA={"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
        
        public String getGenID()
        {
            String len = "0000000000";
            //r1.Next(Char.ConvertToUtf32("A",0), Char.ConvertToUtf32("Z",0));
            len += r.Next(0, 999999999).ToString();
            len = len.Substring(len.Length - 10);
            len = char.ConvertFromUtf32(r1.Next(Char.ConvertToUtf32("A", 0), Char.ConvertToUtf32("Z", 0))) + char.ConvertFromUtf32(r1.Next(Char.ConvertToUtf32("A", 0), Char.ConvertToUtf32("Z", 0)))+len;
            
            return len;
        }
        public String dateTimetoDB()
        {
            return datetoDB(System.DateTime.Now) + " " + System.DateTime.Now.ToShortTimeString();
        }
        public String datetoDB()
        {
            return datetoDB(System.DateTime.Now);
        }
        private String datetoDB(object dt)
        {
            DateTime dt1 = new DateTime();
            try
            {
                if (dt == null)
                {
                    return "";
                }
                else if (dt == "")
                {
                    return "";
                }
                else
                {
                    dt1 = DateTime.Parse(dt.ToString());
                    if (dt1.Year <= 1500)
                    {
                        return String.Concat((dt1.Year + 543), "-") + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
                    }
                    else
                    {
                        return dt1.Year.ToString() + "-" + dt1.Month.ToString("00") + "-" + dt1.Day.ToString("00");
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Double NumberNull(object o)
        {
            //float a = new float();
            try
            {
                return float.Parse(o.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
            //return a.ToString();
        }
    }
}
