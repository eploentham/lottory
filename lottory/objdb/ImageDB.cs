using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class ImageDB
    {
        ConnectDB conn;
        public Image1 img;
        public ImageDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            img = new Image1();
            img.custId = "cust_id";
            img.Id = "img_id";
            img.pathFilename = "path_filename";
            img.saleId = "sale_id";
            img.staffId = "staff_id";
            img.Active = "img_active";
            img.yearId = "year_id";
            img.monthId = "month_id";
            img.periodId = "period1";
            img.statusInput = "status_input";

            img.pkField = "img_id";
            img.table = "t_image";
        }
        private Image1 setData(Image1 item, DataTable dt)
        {
            item.custId = dt.Rows[0][img.custId].ToString();
            item.Id = dt.Rows[0][img.Id].ToString();
            item.pathFilename = dt.Rows[0][img.pathFilename].ToString();
            item.saleId = dt.Rows[0][img.saleId].ToString();
            item.staffId = dt.Rows[0][img.staffId].ToString();
            item.Active = dt.Rows[0][img.Active].ToString();

            item.yearId = dt.Rows[0][img.yearId].ToString();
            item.monthId = dt.Rows[0][img.monthId].ToString();
            item.periodId = dt.Rows[0][img.periodId].ToString();
            item.statusInput = dt.Rows[0][img.statusInput].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + img.table + " Where " + img.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public Image1 selectByPk(String saleId)
        {
            Image1 item = new Image1();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + img.table + " Where " + img.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(Image1 p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }

            //p.Name = p.Name.Replace("''", "'");
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + img.table + " (" + img.pkField + "," + img.custId + "," + img.pathFilename + "," +
                img.saleId + "," + img.staffId + "," + img.Active + ","+
                img.yearId + "," + img.monthId + "," + img.periodId + "," + img.statusInput + ") " +
                "Values('" + p.Id + "','" + p.custId + "','" + p.pathFilename + "','" +
                p.saleId + "','" + p.staffId + "','" + p.Active + "','" +
                p.yearId + "','" + p.monthId + "','" + p.periodId + "','" + p.statusInput + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Image1");
            }
            finally
            {
            }
            return chk;
        }
        private String update(Image1 p)
        {
            String sql = "", chk = "";

            //p.Name = p.Name.Replace("''", "'");
            //p.saleName = p.saleName.Replace("''", "'");

            sql = "Update " + img.table + " Set " + img.custId + "='" + p.custId + "', " +
                img.pathFilename + "='" + p.pathFilename + "', " +
                img.saleId + "='" + p.saleId + "', " +
                img.staffId + "='" + p.staffId + "', " +
                img.yearId + "='" + p.yearId + "', " +
                img.monthId + "='" + p.monthId + "', " +
                img.periodId + "='" + p.periodId + "' " +
                "Where " + img.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Image1");
            }
            finally
            {
            }
            return chk;
        }
        public String insertImage(Image1 p)
        {
            Image1 item = new Image1();
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
            sql = "Delete From " + img.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
