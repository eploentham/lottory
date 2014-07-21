using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class SaleDB
    {
        ConnectDB conn;
        public Sale sale;
        public SaleDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            sale = new Sale();
            sale.Id = "sale_id";
            sale.Code = "sale_code";
            sale.Name = "sale_name";            
            sale.Remark = "sale_remark";
            sale.Active = "sale_active";
            sale.Limit1 = "sale_limit";
            sale.statusDiscount = "status_discount";
            sale.sited = "";
            sale.table = "b_sale";
            sale.pkField = "sale_id";
        }
        private Sale setData(Sale item, DataTable dt)
        {
            item.Id = dt.Rows[0][sale.Id].ToString();
            item.Code = dt.Rows[0][sale.Code].ToString();
            item.Name = dt.Rows[0][sale.Name].ToString();            
            item.Remark = dt.Rows[0][sale.Remark].ToString();
            item.Limit1 = dt.Rows[0][sale.Limit1].ToString();
            item.Active = dt.Rows[0][sale.Active].ToString();
            item.statusDiscount = dt.Rows[0][sale.statusDiscount].ToString();
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + sale.table + " Where " + sale.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public List<Sale> selectSAll()
        {
            List<Sale> ls = new List<Sale>();
            DataTable dt1 = selectAll();
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    Sale item = new Sale();
                    item.Id = dt1.Rows[0][sale.Id].ToString();
                    item.Code = dt1.Rows[0][sale.Code].ToString();
                    item.Name = dt1.Rows[0][sale.Name].ToString();
                    item.Remark = dt1.Rows[0][sale.Remark].ToString();
                    item.Limit1 = dt1.Rows[0][sale.Limit1].ToString();
                    item.Active = dt1.Rows[0][sale.Active].ToString();
                    item.statusDiscount = dt1.Rows[0][sale.statusDiscount].ToString();
                    ls.Add(item);
                }
            }
            return ls;
        }
        public Sale selectByPk(String saleId)
        {
            Sale item = new Sale();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + sale.table + " Where " + sale.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Sale selectByCode(String saleId)
        {
            Sale item = new Sale();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + sale.table + " Where " + sale.Code + "='" + saleId + "' and " + sale.Active + "='1' ";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(Sale p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }
            if (p.Limit1.Equals(""))
            {
                p.Limit1 = "0";
            }
            p.Name = p.Name.Replace("''", "'");
            p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + sale.table + " (" + sale.pkField + "," + sale.Name+","+sale.Remark+","+
                sale.Active + "," + sale.Code+","+sale.Limit1+","+sale.statusDiscount + ") " +
                "Values('" + p.Id + "','" + p.Name+"','"+p.Remark+"','"+
                p.Active + "','"+p.Code+"',"+p.Limit1+",'"+p.statusDiscount+"')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Sale");
            }
            finally
            {
            }
            return chk;
        }
        private String update(Sale p)
        {
            String sql = "", chk = "";

            p.Name = p.Name.Replace("''", "'");

            sql = "Update " + sale.table + " Set " + sale.Name + "='" + p.Name + "', " +
                sale.Remark + "='" + p.Remark + "', " +
                sale.Code + "='" + p.Code + "', " +
                sale.Limit1 + "='" + p.Limit1 + "', " +
                sale.statusDiscount + "='" + p.statusDiscount + "' " +
                "Where " + sale.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Sale");
            }
            finally
            {
            }
            return chk;
        }
        public String insertSale(Sale p)
        {
            Sale item = new Sale();
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
            sql = "Delete From " + sale.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboSale(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][sale.Id].ToString();
                item.Text = dt.Rows[i][sale.Name].ToString();
                c.Items.Add(item);
                //aaa += "new { Text = "+dt.Rows[i][sale.Name].ToString()+", Value = "+dt.Rows[i][sale.Id].ToString()+" },";
                //c.Items.Add(new );
            }
            return c;
        }
        public String VoidSale(String saleId)
        {
            String sql = "", chk = "";

            sql = "Update " + sale.table + " Set " + sale.Active + "='3' " +
                "Where " + sale.pkField + "='" + saleId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
