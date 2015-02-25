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
            img.FLock = "f_lock";
            img.dateCreate = "date_create";
            img.dateInput = "date_input";
            img.staffInputId = "staff_input_id";
            img.staffInputName = "staff_input_name";
            img.rowNumber = "row_number";
            img.thooId = "thoo_id";
            img.saleId = "sale_id";

            img.saleOldId = "sale_old_id";
            img.SfMoveId = "staff_move_id";
            img.dateMove = "date_move";
            img.sfVoidId = "staff_void_id";

            img.SfCheck1Id = "staff_check1_id";
            img.SfCheck2Id = "staff_check2_id";
            img.Amt = "amount";
            img.AmtCheck1 = "amount_check1";
            img.AmtCheck2 = "amount_check2";
            img.StatusCheck1 = "status_check1";
            img.StatusCheck2 = "status_check2";

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
            item.FLock = dt.Rows[0][img.FLock].ToString();

            item.dateCreate = dt.Rows[0][img.dateCreate].ToString();
            item.dateInput = dt.Rows[0][img.dateInput].ToString();
            item.staffInputId = dt.Rows[0][img.staffInputId].ToString();
            item.staffInputName = dt.Rows[0][img.staffInputName].ToString();
            item.rowNumber = dt.Rows[0][img.rowNumber].ToString();
            item.thooId = dt.Rows[0][img.thooId].ToString();

            item.saleOldId = dt.Rows[0][img.saleOldId].ToString();
            item.SfMoveId = dt.Rows[0][img.SfMoveId].ToString();
            item.dateMove = dt.Rows[0][img.dateMove].ToString();
            item.sfVoidId = dt.Rows[0][img.sfVoidId].ToString();

            item.SfCheck1Id = dt.Rows[0][img.SfCheck1Id].ToString();
            item.SfCheck2Id = dt.Rows[0][img.SfCheck2Id].ToString();
            item.Amt = dt.Rows[0][img.Amt].ToString();
            item.AmtCheck1 = dt.Rows[0][img.AmtCheck1].ToString();
            item.AmtCheck2 = dt.Rows[0][img.AmtCheck2].ToString();
            item.StatusCheck1 = dt.Rows[0][img.StatusCheck1].ToString();
            item.StatusCheck2 = dt.Rows[0][img.StatusCheck2].ToString();

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
        public Image1 selectByPk(String id)
        {
            Image1 item = new Image1();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + img.table + " Where " + img.pkField + "='" + id + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Image1 selectByRowNumber(String yearId, String monthId, String periodId, String id)
        {
            Image1 item = new Image1();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + img.table + " Where " + img.yearId + "='" + yearId + "' and " +
                img.monthId + "='" + monthId + "' and " + img.periodId + "='" + periodId +"' and "+ img.rowNumber + "='" + id + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public DataTable selectBySaleId(String yearId, String monthId, String periodId, String saleId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + img.table + " Where " + img.Active + "='1' and " + img.yearId + "='" + yearId + "' and " +
                img.monthId + "='" + monthId + "' and " + img.periodId + "='" + periodId + "' and "+img.saleId+"='"+saleId+"'" ;
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByPeriod(String yearId, String monthId, String periodId, String saleId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + img.table + " Where " + img.Active + "='1' and " + img.yearId + "='" + yearId + "' and " +
                img.monthId + "='" + monthId + "' and " + img.periodId + "='" + periodId + "' ";
            dt = conn.selectData(sql);

            return dt;
        }
        private String insert(Image1 p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }

            p.dateCreate = p.dateGenDB;
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + img.table + " (" + img.pkField + "," + img.custId + "," + img.pathFilename + "," +
                img.saleId + "," + img.staffId + "," + img.Active + ","+
                img.yearId + "," + img.monthId + "," + img.periodId + "," +
                img.statusInput + "," + img.FLock + "," + img.dateCreate + "," +
                img.dateInput + "," + img.staffInputId + "," + img.staffInputName + "," +
                img.rowNumber + "," + img.thooId + ") " +
                "Values('" + p.Id + "','" + p.custId + "','" + p.pathFilename + "','" +
                p.saleId + "','" + p.staffId + "','" + p.Active + "','" +
                p.yearId + "','" + p.monthId + "','" + p.periodId + "','" +
                "0','0'," + p.dateCreate+","+
                "'','','','"+
                p.rowNumber + "','" + p.thooId + "')";
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
                img.periodId + "='" + p.periodId + "', " +
                img.thooId + "='" + p.thooId + "' " +
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
                String max = "";
                max = selectMaxRowNumberByPeriod(p.yearId, p.monthId, p.periodId);
                p.rowNumber = max;
                //p.Id = p.rowNumber;
                chk = insert(p);
                chk = max;      //ให้ใช้ค่า max จะได้เรียงได้อย่างสวยงาม
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
        public String UpdateStatusInput(String imgId, String sfId, String sfName, String thoId, String amt)
        {
            String sql = "", chk = "";
            sql = "Update " + img.table+" Set "+img.statusInput+"='1', "+
                img.dateInput + "=" + img.dateGenDB + "," +
                img.staffInputId+"='"+sfId+"',"+
                img.staffInputName+"='"+sfName+"', "+
                img.thooId + "='" + thoId + "', " +
                img.Amt + "=" + amt + " " +
                "Where "+img.pkField+"='"+imgId+"'" ;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String UpdateLock(String imgId)
        {
            String sql = "", chk = "";
            sql = "Update " + img.table + " Set " + img.FLock + "='1' Where " + img.pkField + "='" + imgId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String UpdateUnLock(String imgId)
        {
            String sql = "", chk = "";
            sql = "Update " + img.table + " Set " + img.FLock + "='0' Where " + img.pkField + "='" + imgId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String VoidImage(String imgId, String sfId)
        {
            String sql = "", chk = "";

            sql = "Update " + img.table + " Set " + img.Active + "='3', " +
                img.sfVoidId+"='"+sfId+"' "+
                
                "Where " + img.Id + "='" + imgId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String UpdateSale(String imgId, String saleId)
        {
            String sql = "", chk = "";

            sql = "Update " + img.table + " Set " + img.saleId + "='"+saleId+"', "+img.dateMove+"="+img.dateGenDB+","+img.saleOldId+"="+img.saleId+" " +
                "Where " + img.Id + "='" + imgId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String selectMaxRowNumberByPeriod(String yearId, String monthId, String periodId)
        {
            Image1 item = new Image1();
            String sql = "";
            int cnt = 0;
            DataTable dt = new DataTable();
            sql = "Select max(" + img.rowNumber + ") as " + img.rowNumber + " From " + img.table + " Where " + img.yearId + "='" + yearId + "' and " +
                img.monthId + "='" + monthId + "' and " + img.periodId + "='" + periodId+"'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][img.rowNumber] != null)
                {
                    if (dt.Rows[0][img.rowNumber].ToString().Equals(""))
                    {
                        cnt = 10000;
                    }
                    else
                    {
                        cnt = int.Parse(dt.Rows[0][img.rowNumber].ToString())+1;
                    }
                }
                else
                {
                    cnt = 10000;
                }
            }
            else
            {
                cnt = 10000;
            }
            return cnt.ToString();
        }
    }
}
