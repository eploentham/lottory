using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class NumberLimitDB
    {
        ConnectDB conn;
        public NumberLimit nl;
        public NumberLimitDB(ConnectDB c)
        {
            conn = c;
            initConfig();
            
        }
        private void initConfig()
        {
            nl = new NumberLimit();
            nl.Active = "num_limit_active";
            nl.dateCancel = "date_cancel";
            nl.dateCreate = "date_create";
            nl.dateModi = "date_modi";
            nl.dateStart = "date_start";
            nl.Id = "num_limit_id";
            nl.monthId = "month_id";
            nl.number = "number1";
            nl.periodId = "period1";
            nl.remark = "num_limit_remark";
            nl.staffCancel = "staff_cancel";
            nl.staffCreate = "staff_create";
            nl.staffModi = "staff_modi";
            nl.StatusStart = "status_start";
            nl.yearId = "year_id";
            nl.yearLimitId = "year_limit_id";
            nl.monthLimitId = "month_limit_id";
            nl.periodLimitId = "period1_limit";
            nl.dateEnd = "date_end";

            nl.table = "t_number_limit";
            nl.pkField = "num_limit_id";
        }
        private NumberLimit setData(NumberLimit item, DataTable dt)
        {
            item.Active = dt.Rows[0][nl.Active].ToString();
            item.dateCancel = dt.Rows[0][nl.dateCancel].ToString();
            item.dateCreate = dt.Rows[0][nl.dateCreate].ToString();
            item.dateModi = dt.Rows[0][nl.dateModi].ToString();
            item.dateStart = dt.Rows[0][nl.dateStart].ToString();
            item.Id = dt.Rows[0][nl.Id].ToString();
            item.monthId = dt.Rows[0][nl.monthId].ToString();
            item.number = dt.Rows[0][nl.number].ToString();
            item.periodId = dt.Rows[0][nl.periodId].ToString();
            item.remark = dt.Rows[0][nl.remark].ToString();
            item.staffCancel = dt.Rows[0][nl.staffCancel].ToString();
            item.staffModi = dt.Rows[0][nl.staffModi].ToString();
            item.StatusStart = dt.Rows[0][nl.StatusStart].ToString();
            item.yearId = dt.Rows[0][nl.yearId].ToString();
            item.yearLimitId = dt.Rows[0][nl.yearLimitId].ToString();
            item.monthLimitId = dt.Rows[0][nl.monthLimitId].ToString();
            item.periodLimitId = dt.Rows[0][nl.periodLimitId].ToString();
            item.dateEnd = dt.Rows[0][nl.dateEnd].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            try
            {
                sql = "Select * From " + nl.table + " Where " + nl.Active + "='1'";
                dt = conn.selectData(sql);
            }
            catch (Exception ex)
            {

            }
            

            return dt;
        }
        public NumberLimit selectByPk(String saleId)
        {
            NumberLimit item = new NumberLimit();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + nl.table + " Where " + nl.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(NumberLimit p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }
            p.dateCreate = p.dateGenDB;
            p.remark = p.remark.Replace("''", "'");
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + nl.table + " (" + nl.pkField + "," + nl.Active + "," + nl.dateCancel + "," +
                nl.dateCreate + "," + nl.dateModi + "," + nl.dateStart + "," +
                nl.monthId + "," + nl.number + "," + nl.periodId + "," +
                nl.remark + "," + nl.staffCancel + "," + nl.staffModi + "," +
                nl.StatusStart + "," + nl.yearId + "," + nl.yearLimitId + "," +
                nl.monthLimitId + "," + nl.periodLimitId + "," + nl.dateEnd + ") " +
                "Values('" + p.Id + "','" + p.Active + "','" + p.dateCancel + "'," +
                p.dateCreate + ",'" + p.dateModi + "','" + p.dateStart + "','" +
                p.monthId + "','" + p.number + "','" + p.periodId + "','" +
                p.remark + "','" + p.staffCancel + "','" + p.staffModi + "','" +
                p.StatusStart + "','" + p.yearId + "','" + p.yearLimitId + "','" +
                p.monthLimitId + "','" + p.periodLimitId + "','" + p.dateEnd + "')";
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
        private String update(NumberLimit p)
        {
            String sql = "", chk = "";

            p.remark = p.remark.Replace("''", "'");
            //p.saleName = p.saleName.Replace("''", "'");
            p.dateModi = p.dateGenDB;
            sql = "Update " + nl.table + " Set " + nl.dateCancel + "='" + p.dateCancel + "', " +
                //nl.dateCreate + "='" + p.dateCreate + "', " +
                nl.dateModi + "=" + p.dateModi + ", " +
                //nl.dateStart + "='" + p.dateStart + "', " +
                nl.monthId + "='" + p.monthId + "', " +
                nl.number + "='" + p.number + "', " +
                nl.periodId + "='" + p.periodId + "', " +
                nl.remark + "='" + p.remark + "', " +
                //nl.staffCancel + "='" + p.staffCancel + "', " +
                //nl.staffModi + "='" + p.staffModi + "', " +
                //nl.StatusStart + "='" + p.StatusStart + "', " +
                nl.yearId + "='" + p.yearId + "', " +
                nl.yearLimitId + "='" + p.yearLimitId + "', " +
                nl.monthLimitId + "='" + p.monthLimitId + "', " +
                nl.periodLimitId + "='" + p.periodLimitId + "' " +
                "Where " + nl.pkField + "='" + p.Id + "'";
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
        public String insertNumberLimit(NumberLimit p)
        {
            NumberLimit item = new NumberLimit();
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
            sql = "Delete From " + nl.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String VoidNUmberLimit(String saleId)
        {
            String sql = "", chk = "";
            //p.dateCreate = p.dateGenDB;
            sql = "Update " + nl.table + " Set " + nl.Active + "='3' " +
                nl.dateCancel+"="+nl.dateGenDB+" "+
                "Where " + nl.pkField + "='" + saleId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
