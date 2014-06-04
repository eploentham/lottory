using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class StaffDB
    {
        ConnectDB conn;
        public Staff sf;
        public StaffDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            sf = new Staff();
            sf.Id = "staff_id";
            sf.Code = "staff_code";
            sf.Name = "staff_name";
            sf.Remark = "staff_remark";
            sf.Password = "staff_password";
            sf.Active = "staff_active";
            sf.Priority = "priority";
            sf.sited = "";
            sf.table = "b_staff";
            sf.pkField = "staff_id";
        }
        private Staff setData(Staff item, DataTable dt)
        {
            item.Id = dt.Rows[0][sf.Id].ToString();
            item.Code = dt.Rows[0][sf.Code].ToString();
            item.Name = dt.Rows[0][sf.Name].ToString();
            item.Remark = dt.Rows[0][sf.Remark].ToString();
            item.Password = dt.Rows[0][sf.Password].ToString();
            item.Active = dt.Rows[0][sf.Active].ToString();
            item.Priority = dt.Rows[0][sf.Priority].ToString();
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + sf.table + " Where " + sf.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public Staff selectByPk(String saleId)
        {
            Staff item = new Staff();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + sf.table + " Where " + sf.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Staff selectByCode(String sfId)
        {            
            Staff item = new Staff();
            String sql = "";
            DataTable dt = new DataTable();
            if (sfId.Equals("pop"))
            {
                item.Code = "pop";
                item.Name = "Administrator";
                item.Priority = "3";
                return item;
            }
            sql = "Select * From " + sf.table + " Where " + sf.Code + "='" + sfId + "' and "+sf.Active+"='1' ";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(Staff p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }
            p.Name = p.Name.Replace("''", "'");
            p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + sf.table + " (" + sf.pkField + "," + sf.Name + "," + sf.Remark + "," +
                sf.Active + "," + sf.Code+","+sf.Priority + ") " +
                "Values('" + p.Id + "','" + p.Name + "','" + p.Remark + "','" +
                p.Active + "','" + p.Code+"','"+p.Priority + "')";
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
        private String update(Staff p)
        {
            String sql = "", chk = "";

            p.Name = p.Name.Replace("''", "'");

            sql = "Update " + sf.table + " Set " + sf.Name + "='" + p.Name + "', " +
                sf.Remark + "='" + p.Remark + "', " +
                sf.Code + "='" + p.Code + "', " +
                sf.Priority + "='" + p.Priority + "' " +
                "Where " + sf.pkField + "='" + p.Id + "'";
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
        public String insertStaff(Staff p)
        {
            Staff item = new Staff();
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
            sql = "Delete From " + sf.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboStaff(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][sf.Id].ToString();
                item.Text = dt.Rows[i][sf.Name].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            //c.SelectedItem = item;
            return c;
        }
        public ComboBox getCboStaff(ComboBox c, String selectedId)
        {
            ComboBoxItem item = new ComboBoxItem();
            ComboBoxItem se = new ComboBoxItem();
            DataTable dt = selectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][sf.Id].ToString();
                item.Text = dt.Rows[i][sf.Name].ToString();
                c.Items.Add(item);
                if (item.Value.Equals(selectedId))
                {
                    se = item;
                }
                //c.Items.Add(new );
            }

            c.SelectedItem = se;
            return c;
        }
        public String VoidStaff(String sfId)
        {
            String sql = "", chk = "";

            sql = "Update " + sf.table + " Set " + sf.Active + "='3' " +
                "Where " + sf.pkField + "='" + sfId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updatePassword(String sfId, String password)
        {
            String sql = "", chk = "";

            sql = "Update " + sf.table + " Set " + sf.Password + "='" + password + "' " +
                "Where " + sf.pkField + "='" + sfId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
