using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class TRateDB
    {
        ConnectDB conn;
        TRate tr;
        public TRateDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            tr = new TRate();
            tr.Active = "t_rate_active";
            tr.amount = "amount";
            tr.limit1 = "limit1";
            tr.monthId = "month_id";
            tr.pay = "pay";
            tr.periodId = "period_id";
            tr.RateDescription = "rate_description";
            tr.RateId = "rate_id";
            tr.TRateId = "t_rate_id";
            tr.yearId = "year_id";

            tr.table = "t_rate";
            tr.pkField = "t_rate_id";
        }
        private TRate setData(TRate item, DataTable dt)
        {
            item.Active = dt.Rows[0][tr.Active].ToString();
            item.amount = dt.Rows[0][tr.amount].ToString();
            item.limit1 = dt.Rows[0][tr.limit1].ToString();
            item.monthId = dt.Rows[0][tr.monthId].ToString();
            item.pay = dt.Rows[0][tr.pay].ToString();
            item.periodId = dt.Rows[0][tr.periodId].ToString();
            item.RateDescription = dt.Rows[0][tr.RateDescription].ToString();
            item.RateId = dt.Rows[0][tr.RateId].ToString();
            item.TRateId = dt.Rows[0][tr.TRateId].ToString();
            item.yearId = dt.Rows[0][tr.yearId].ToString();
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + tr.table + " Where " + tr.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public TRate selectByPk(String saleId)
        {
            TRate item = new TRate();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + tr.table + " Where " + tr.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(TRate p)
        {
            String sql = "", chk = "";
            if (p.TRateId.Equals(""))
            {
                p.TRateId = p.getGenID();
            }
            //p.Name = p.Name.Replace("''", "'");
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + tr.table + " (" + tr.pkField + "," + tr.Active + "," + tr.amount + "," +
                tr.limit1 + "," + tr.monthId + "," + tr.pay + "," +
                tr.periodId + "," + tr.RateDescription + "," + tr.RateId + "," +
                tr.yearId + ") " +
                "Values('" + p.TRateId + "','" + p.Active + "','" + p.amount + "','" + 
                p.limit1 + "','" + p.monthId + "'," + p.pay + ",'" +
                p.periodId + ",'" + p.RateDescription + ",'" + p.RateId + ",'" +
                p.yearId + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.TRateId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Thoodb");
            }
            finally
            {
            }
            return chk;
        }
        private String update(TRate p)
        {
            String sql = "", chk = "";

            //p.Name = p.Name.Replace("''", "'");

            sql = "Update " + tr.table + " Set " + tr.amount + "='" + p.amount + "', " +
                tr.limit1 + "='" + p.limit1 + "', " +
                tr.monthId + "='" + p.monthId + "', " +
                tr.pay + "=" + p.pay + ", " +
                tr.periodId + "='" + p.periodId + "', " +
                tr.RateDescription + "='" + p.RateDescription + "', " +
                tr.RateId + "='" + p.RateId + "', " +
                tr.yearId + "='" + p.yearId + "' " +
                "Where " + tr.pkField + "='" + p.TRateId + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Thoodb");
            }
            finally
            {
            }
            return chk;
        }
        public String deleteAll()
        {
            String sql = "", chk = "";
            sql = "Delete From " + tr.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
