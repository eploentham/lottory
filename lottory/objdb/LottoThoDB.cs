using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class LottoThoDB
    {
        ConnectDB conn;
        public LottoTho lTho;
        public LottoThoDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lTho = new LottoTho();
            lTho.Active = "lto_tho_active";
            lTho.Amount = "amount";
            lTho.AmountPer = "amount_per";
            lTho.Id = "lot_tho_id";
            lTho.monthId = "month_id";
            lTho.periodId = "period1";
            lTho.rowNumber = "row_number";
            lTho.thoId = "tho_id";
            lTho.thoName = "tho_name";
            lTho.yearId = "year_id";

            lTho.table = "t_lottory_tho";
            lTho.pkField = "lot_tho_id";
        }
        private LottoTho setData(LottoTho item, DataTable dt)
        {
            item.Active = dt.Rows[0][lTho.Active].ToString();
            item.Amount = dt.Rows[0][lTho.Amount].ToString();
            item.AmountPer = dt.Rows[0][lTho.AmountPer].ToString();
            item.Id = dt.Rows[0][lTho.Id].ToString();
            item.monthId = dt.Rows[0][lTho.monthId].ToString();
            item.periodId = dt.Rows[0][lTho.periodId].ToString();
            item.rowNumber = dt.Rows[0][lTho.rowNumber].ToString();
            item.thoId = dt.Rows[0][lTho.thoId].ToString();
            item.thoName = dt.Rows[0][lTho.thoName].ToString();
            item.yearId = dt.Rows[0][lTho.yearId].ToString();
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lTho.table + " Where " + lTho.Active + "='1' Order By " + lTho.thoName;
            dt = conn.selectData(sql);

            return dt;
        }
        public LottoTho selectByPk(String lThoId)
        {
            LottoTho item = new LottoTho();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lTho.table + " Where " + lTho.pkField + "='" + lThoId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(LottoTho p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }
            p.thoName = p.thoName.Replace("''", "'");
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + lTho.table + " (" + lTho.pkField + "," + lTho.Active + "," + lTho.Amount + "," +
                lTho.AmountPer + "," + lTho.monthId + "," + lTho.periodId + "," +
                lTho.rowNumber + "," + lTho.thoId + "," + lTho.thoName + "," + lTho.yearId + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.Amount + "','" +
                p.AmountPer + "','" + p.monthId + "','" + p.periodId + "','" +
                p.rowNumber + "','" + p.thoId + "','" + p.thoName + "','" + p.yearId + "')";
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
        private String update(LottoTho p)
        {
            String sql = "", chk = "";

            p.thoName = p.thoName.Replace("''", "'");

            sql = "Update " + lTho.table + " Set " + lTho.Amount + "='" + p.Amount + "', " +
                lTho.AmountPer + "='" + p.AmountPer + "', " +
                lTho.monthId + "='" + p.monthId + "', " +
                lTho.periodId + "='" + p.periodId + "', " +
                lTho.rowNumber + "='" + p.rowNumber + "', " +
                lTho.thoId + "='" + p.thoId + "', " +
                lTho.thoName + "='" + p.thoName + "', " +
                lTho.yearId + "='" + p.yearId + "' " +
                "Where " + lTho.pkField + "='" + p.Id + "'";
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
        public String insertRate(LottoTho p)
        {
            LottoTho item = new LottoTho();
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
            sql = "Delete From " + lTho.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        //public ComboBox getCboRate(ComboBox c)
        //{
        //    ComboBoxItem item = new ComboBoxItem();
        //    DataTable dt = selectAll();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        item = new ComboBoxItem();
        //        item.Value = dt.Rows[i][lTho.Id].ToString();
        //        item.Text = dt.Rows[i][lTho.Description].ToString();
        //        c.Items.Add(item);
        //        //c.Items.Add(new );
        //    }
        //    return c;
        //}
    }
}
