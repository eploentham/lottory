using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class RateDB
    {
        ConnectDB conn;
        public Rate rate;
        public RateDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            rate = new Rate();
            rate.Id = "rate_id";
            rate.Description = "rate_description";
            rate.rec = "rec";
            rate.pay = "pay";
            rate.limit1 = "limit1";
            rate.discount = "discount";
            rate.Active = "rate_active";
            rate.thooId = "thoo_id";
            rate.sort1 = "sort1";
            rate.sited = "";
            rate.table = "b_rate";
            rate.pkField = "rate_id";
        }
        private Rate setData(Rate item, DataTable dt)
        {
            item.Id = dt.Rows[0][rate.Id].ToString();
            item.Description = dt.Rows[0][rate.Description].ToString();
            item.rec = dt.Rows[0][rate.rec].ToString();
            item.pay = dt.Rows[0][rate.pay].ToString();
            item.limit1 = dt.Rows[0][rate.limit1].ToString();
            item.discount = dt.Rows[0][rate.discount].ToString();
            item.Active = dt.Rows[0][rate.Active].ToString();
            item.thooId = dt.Rows[0][rate.thooId].ToString();
            item.sort1 = dt.Rows[0][rate.sort1].ToString();
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + rate.table + " Where " + rate.Active + "='1' Order By "+rate.sort1;
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectAlltoSaleRate()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select *, '' as sale_id, '' as sale_rate_id, " + rate.Description + " as sale_rate_description From " + rate.table + " Where " + rate.Active + "='1' Order By " + rate.sort1;
            dt = conn.selectData(sql);

            return dt;
        }
        public Rate selectByPk(String saleId)
        {
            Rate item = new Rate();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + rate.table + " Where " + rate.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(Rate p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }
            p.Description = p.Description.Replace("''", "'");
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + rate.table + " (" + rate.pkField + "," + rate.Description + "," + rate.rec + "," + 
                rate.pay + "," + rate.limit1 + "," + rate.discount + "," + 
                rate.thooId + "," + rate.Active + ") " +
                "Values('" + p.Id + "','" + p.Description + "','" + p.rec + "','" + 
                p.pay + "','" + p.limit1 + "','" + p.discount + "','" + 
                p.thooId + "','" + p.Active + "')";
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
        private String update(Rate p)
        {
            String sql = "", chk = "";

            p.Description = p.Description.Replace("''", "'");

            sql = "Update " + rate.table + " Set " + rate.Description + "='" + p.Description + "', " +
                rate.rec + "='" + p.rec + "', " +
                rate.pay + "='" + p.pay + "', " +
                rate.limit1 + "='" + p.limit1 + "', " +
                rate.discount + "='" + p.discount + "', " +
                rate.thooId + "='" + p.thooId + "' " +
                "Where " + rate.pkField + "='" + p.Id + "'";
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
        public String insertRate(Rate p)
        {
            Rate item = new Rate();
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
            sql = "Delete From " + rate.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboRate(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][rate.Id].ToString();
                item.Text = dt.Rows[i][rate.Description].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            return c;
        }
    }
}
