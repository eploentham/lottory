using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class ThooDB
    {
        ConnectDB conn;
        public Thoo tho;
        public ThooDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            tho = new Thoo();
            tho.Id = "thoo_id";
            tho.Code = "thoo_code";
            tho.Name = "thoo_name";
            tho.Remark = "thoo_remark";
            tho.Active = "thoo_active";
            tho.Color = "thoo_color";
            tho.Limit1 = "thoo_limit";
            tho.Default = "thoo_default";
            tho.dateModiThooDefault = "date_modi_thoo_default";
            tho.staffModiThooDefault = "staff_modi_thoo_default";
            tho.thooDefaultCnt = "thoo_default_cnt";
            tho.sited = "";
            tho.table = "b_thoo";
            tho.pkField = "thoo_id";
        }
        private Thoo setData(Thoo item, DataTable dt)
        {
            item.Id = dt.Rows[0][tho.Id].ToString();
            item.Code = dt.Rows[0][tho.Code].ToString();
            item.Name = dt.Rows[0][tho.Name].ToString();
            item.Remark = dt.Rows[0][tho.Remark].ToString();
            item.Active = dt.Rows[0][tho.Active].ToString();
            item.Color = dt.Rows[0][tho.Color].ToString();
            item.Limit1 = dt.Rows[0][tho.Limit1].ToString();
            item.Default = dt.Rows[0][tho.Default].ToString();
            item.dateModiThooDefault = dt.Rows[0][tho.dateModiThooDefault].ToString();
            item.staffModiThooDefault = dt.Rows[0][tho.staffModiThooDefault].ToString();
            item.thooDefaultCnt = dt.Rows[0][tho.thooDefaultCnt].ToString();
            return item;
        }
        public List<Thoo> setData()
        {
            List<Thoo> ltho = new List<Thoo>();
            Thoo t = new Thoo();
            DataTable dt = selectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //t = thodb.setData(t, dt, i);
                t = new Thoo();
                t.Id = dt.Rows[i][tho.Id].ToString();
                t.Code = dt.Rows[i][tho.Code].ToString();
                t.Name = dt.Rows[i][tho.Name].ToString();
                t.Remark = dt.Rows[i][tho.Remark].ToString();
                t.Active = dt.Rows[i][tho.Active].ToString();
                t.Color = dt.Rows[i][tho.Color].ToString();
                t.Limit1 = dt.Rows[i][tho.Limit1].ToString();
                t.Default = dt.Rows[i][tho.Default].ToString();
                t.dateModiThooDefault = dt.Rows[0][tho.dateModiThooDefault].ToString();
                t.staffModiThooDefault = dt.Rows[0][tho.staffModiThooDefault].ToString();
                t.thooDefaultCnt = dt.Rows[0][tho.thooDefaultCnt].ToString();
                ltho.Add(t);
            }
            return ltho;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            try
            {
                sql = "Select * From " + tho.table + " Where " + tho.Active + "='1' Order By " + tho.Color;
                dt = conn.selectData(sql);
            }
            catch (Exception ex)
            {

            }
            

            return dt;
        }
        public DataTable selectAllNoDefault()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + tho.table + " Where " + tho.Active + "='1' and "+tho.Default+"<>'1' Order By " + tho.Color;
            dt = conn.selectData(sql);

            return dt;
        }
        public String selectMax()
        {
            String sql = "", cnt="";
            DataTable dt = new DataTable();
            sql = "Select Count(1) as cnt From " + tho.table + " ";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = String.Concat(int.Parse(dt.Rows[0]["cnt"].ToString())+1);
            }
            return cnt;
        }
        public Thoo selectByPk(String saleId)
        {
            Thoo item = new Thoo();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + tho.table + " Where " + tho.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Thoo selectByDefault()
        {
            Thoo item = new Thoo();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + tho.table + " Where " + tho.Default + "='1'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Thoo selectByCode(String saleId)
        {
            Thoo item = new Thoo();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + tho.table + " Where " + tho.Code + "='" + saleId + "' and " + tho.Active + "='1' ";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(Thoo p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
                p.Color = selectMax();
            }
            p.Name = p.Name.Replace("''", "'");
            p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + tho.table + " (" + tho.pkField + "," + tho.Name + "," + tho.Remark + "," +
                tho.Active + "," + tho.Code + "," + tho.Limit1 + "," + tho.Color + "," + tho.Default+","+tho.thooDefaultCnt+","+tho.staffModiThooDefault+","+tho.dateModiThooDefault + ") " +
                "Values('" + p.Id + "','" + p.Name + "','" + p.Remark + "','" + p.Active + "','" + p.Code + "'," + p.Limit1 + "," + p.Color + ",'0',0,'','')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
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
        private String update(Thoo p)
        {
            String sql = "", chk = "";

            p.Name = p.Name.Replace("''", "'");

            sql = "Update " + tho.table + " Set " + tho.Name + "='" + p.Name + "', " +
                tho.Remark + "='" + p.Remark + "', " +
                tho.Code + "='" + p.Code + "', " +
                tho.Limit1 + "=" + p.Limit1 + ", " +
                tho.Color + "='" + p.Color + "' " +
                //tho.Default + "='" + p.Default + "' " +
                "Where " + tho.pkField + "='" + p.Id + "'";
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
        public String insertThoo(Thoo p)
        {
            Thoo item = new Thoo();
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
            sql = "Delete From " + tho.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public ComboBox getCboThoo(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAllNoDefault();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][tho.Id].ToString();
                item.Text = dt.Rows[i][tho.Name].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            return c;
        }
        public ComboBox getCboThooAll(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][tho.Id].ToString();
                item.Text = dt.Rows[i][tho.Name].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            return c;
        }
        public String VoidThoo(String thooId)
        {
            String sql = "", chk = "";

            sql = "Update " + tho.table + " Set " + tho.Active + "='3' " +
                "Where " + tho.pkField + "='" + thooId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String UpdateThooDefault(String thooId, String sfId)
        {
            Thoo item = new Thoo();
            String sql = "", chk = "";
            if (thooId == null)
            {
                return "";
            }
            if (thooId.Equals(""))
            {
                return "";
            }
            item = selectByPk(thooId);
            if (item.Id.Equals(""))
            {
                return "";
            }
            sql = "Update " + tho.table + " Set " + tho.Default + "='0' " ;
            chk = conn.ExecuteNonQuery(sql);

            sql = "Update " + tho.table + " Set " + tho.Default + "='1', " +
                tho.staffModiThooDefault+"='"+sfId+"', "+
                tho.dateModiThooDefault + "=" + tho.dateGenDB + ", " +
                tho.thooDefaultCnt + "=" + tho.thooDefaultCnt + "+1 " +
                "Where " + tho.pkField + "='" + thooId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
