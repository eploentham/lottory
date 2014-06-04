using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lottory.objdb
{
    public class FlockDB
    {
        ConnectDB conn;
        public FLock fl;
        public FlockDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fl = new FLock();
            fl.dateStart = "date_start";
            fl.fLock = "flock";
            fl.remark = "remark";
            fl.staffId = "staff_id";
            fl.table = "f_lock";
        }
        public String lockLotto(String sfId)
        {
            String sql = "", chk="";
            sql = "Update "+fl.table+" Set "+fl.fLock+"='1', "+fl.staffId+"='"+sfId+"'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String unLockLotto()
        {
            String sql = "", chk = "";
            sql = "Update " + fl.table + " Set " + fl.fLock + "='0' " ;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        private String selectLock()
        {
            DataTable dt = new DataTable();
            String sql = "";
            sql = "select " + fl.fLock + " From " + fl.table;
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][fl.fLock].ToString();
            }
            else
            {
                return "";
            }
        }
        public Boolean setLock(String sfId)
        {
            String chk = "";
            chk = selectLock();
            if (chk.Equals("0"))
            {
                chk = lockLotto(sfId);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
