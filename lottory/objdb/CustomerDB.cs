using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class CustomerDB
    {
        ConnectDB conn;
        public Customer cust;
        public CustomerDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cust = new Customer();
            cust.Active = "cust_active";
            cust.Name = "cust_name";
            cust.Id = "cust_id";
            cust.saleId = "sale_id";
            cust.thoId = "thoo_id";
            cust.saleName = "sale_name";

            cust.table = "b_sale_cust";
            cust.pkField = "cust_id";
        }
        private Customer setData(Customer item, DataTable dt)
        {
            item.Id = dt.Rows[0][cust.Id].ToString();
            item.Active = dt.Rows[0][cust.Active].ToString();
            item.Name = dt.Rows[0][cust.Name].ToString();
            item.saleId = dt.Rows[0][cust.saleId].ToString();
            item.thoId = dt.Rows[0][cust.thoId].ToString();
            item.saleName = dt.Rows[0][cust.saleName].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cust.table + " Where " + cust.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public Customer selectByPk(String saleId)
        {
            Customer item = new Customer();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cust.table + " Where " + cust.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(Customer p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }

            p.Name = p.Name.Replace("''", "'");
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + cust.table + " (" + cust.pkField + "," + cust.Name + "," + cust.saleId + "," +
                cust.Active + "," + cust.thoId + ") " +
                "Values('" + p.Id + "','" + p.Name + "','" + p.saleId + "','" +
                p.Active + "','" + p.thoId + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Customer");
            }
            finally
            {
            }
            return chk;
        }
        private String update(Customer p)
        {
            String sql = "", chk = "";

            p.Name = p.Name.Replace("''", "'");
            p.saleName = p.saleName.Replace("''", "'");

            sql = "Update " + cust.table + " Set " + cust.Name + "='" + p.Name + "', " +
                cust.saleId + "='" + p.saleId + "', " +
                cust.thoId + "='" + p.thoId + "', " +
                cust.saleName + "='" + p.saleName + "' " +
                "Where " + cust.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Customer");
            }
            finally
            {
            }
            return chk;
        }
        public String deleteAll()
        {
            String sql = "", chk = "";
            sql = "Delete From " + cust.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboCustomer(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][cust.Id].ToString();
                item.Text = dt.Rows[i][cust.Name].ToString();
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public String VoidCustomer(String saleId)
        {
            String sql = "", chk = "";
            sql = "Update " + cust.table + " Set " + cust.Active + "='3' " +
                "Where " + cust.pkField + "='" + saleId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
