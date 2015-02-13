using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class LottoRateDB
    {
        ConnectDB conn;
        public LottoRate lRate;
        public LottoRateDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lRate = new LottoRate();
            lRate.Active = "lot_rate_actice";
            lRate.Amount = "amount";
            lRate.AmountR = "amount_reward";
            lRate.Description = "rate_description";
            lRate.Id = "lot_rate_id";
            lRate.limit1 = "limit1";
            lRate.monthId = "month_id";
            lRate.NetTotal = "nettotal";
            lRate.pay = "pay";
            lRate.periodId = "period1";
            lRate.rateId = "rate_id";
            lRate.Reward = "reward";
            lRate.rec = "rec";
            lRate.rowNumber = "row_number";
            lRate.yearId = "year_id";

            lRate.table = "t_lottory_rate";
            lRate.pkField = "lot_rate_id";
        }
        private LottoRate setData(LottoRate item, DataTable dt)
        {
            item.Active = dt.Rows[0][lRate.Active].ToString();
            item.Amount = dt.Rows[0][lRate.Amount].ToString();
            item.AmountR = dt.Rows[0][lRate.AmountR].ToString();
            item.Description = dt.Rows[0][lRate.Description].ToString();
            item.Id = dt.Rows[0][lRate.Id].ToString();

            item.limit1 = dt.Rows[0][lRate.limit1].ToString();
            item.monthId = dt.Rows[0][lRate.monthId].ToString();
            item.NetTotal = dt.Rows[0][lRate.NetTotal].ToString();
            item.pay = dt.Rows[0][lRate.pay].ToString();
            item.periodId = dt.Rows[0][lRate.periodId].ToString();

            item.rateId = dt.Rows[0][lRate.rateId].ToString();
            item.Reward = dt.Rows[0][lRate.Reward].ToString();
            item.rec = dt.Rows[0][lRate.rec].ToString();
            item.rowNumber = dt.Rows[0][lRate.rowNumber].ToString();
            item.yearId = dt.Rows[0][lRate.yearId].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lRate.table + " Where " + lRate.Active + "='1' Order By " + lRate.rateId;
            dt = conn.selectData(sql);

            return dt;
        }
        public LottoRate selectByPk(String lThoId)
        {
            LottoRate item = new LottoRate();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lRate.table + " Where " + lRate.pkField + "='" + lThoId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(LottoRate p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }
            //p.thoName = p.thoName.Replace("''", "'");
            ////p.Remark = p.Remark.Replace("''", "'");
            //sql = "Insert Into " + lRate.table + " (" + lRate.pkField + "," + lRate.Active + "," + lRate.Amount + "," +
            //    lRate.AmountPer + "," + lRate.monthId + "," + lRate.periodId + "," +
            //    lRate.rowNumber + "," + lRate.thoId + "," + lRate.thoName + "," + lRate.yearId + ") " +
            //    "Values('" + p.Id + "','" + p.Active + "','" + p.Amount + "','" +
            //    p.AmountPer + "','" + p.monthId + "','" + p.periodId + "','" +
            //    p.rowNumber + "','" + p.thoId + "','" + p.thoName + "','" + p.yearId + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Rate");
            }
            finally
            {
            }
            return chk;
        }
        private String update(LottoRate p)
        {
            String sql = "", chk = "";

            //p.thoName = p.thoName.Replace("''", "'");

            //sql = "Update " + lRate.table + " Set " + lTho.Amount + "='" + p.Amount + "', " +
            //    lRate.AmountPer + "='" + p.AmountPer + "', " +
            //    lRate.monthId + "='" + p.monthId + "', " +
            //    lRate.periodId + "='" + p.periodId + "', " +
            //    lRate.rowNumber + "='" + p.rowNumber + "', " +
            //    lRate.thoId + "='" + p.thoId + "', " +
            //    lRate.thoName + "='" + p.thoName + "', " +
            //    lRate.yearId + "='" + p.yearId + "' " +
            //    "Where " + lTho.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Rate");
            }
            finally
            {
            }
            return chk;
        }
        public String insertRate(LottoRate p)
        {
            LottoRate item = new LottoRate();
            String chk = "";
            item = selectByPk(p.Id);
            if (item.Id == "")
            {
                chk = insert(p);
            }
            else
            {
                chk = update(p);
            }
            return chk;
        }
        public String deleteAll()
        {
            String sql = "", chk = "";
            sql = "Delete From " + lRate.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
