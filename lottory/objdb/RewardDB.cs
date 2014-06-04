using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class RewardDB
    {
        ConnectDB conn;
        Reward rw;
        public RewardDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            rw = new Reward();
            rw.dateCancel = "date_cancel";
            rw.dateCreate = "date_create";
            rw.dateModi = "date_modi";
            rw.dateReward = "date_reward";
            rw.reward1 = "reward1";
            rw.rewardDown2 = "reward_down2";
            rw.monthId = "month_id";
            rw.yearId = "year_id";
            rw.rewardDown31 = "reward_down31";
            rw.rewardDown32 = "reward_down32";
            rw.rewardDown33 = "reward_down33";
            rw.rewardDown34 = "reward_down34";
            rw.periodId = "period1";
            rw.Remark = "remark";
            rw.rewardId = "reward_id";
            
            rw.staffCancel = "staff_cancel";
            rw.staffCreate = "staff_create";
            rw.staffId = "staff_id";
            rw.staffModi = "staff_modi";
            rw.statusApprove = "status_approve";
            rw.dateApprove = "date_approve";
            rw.staffApprove = "staff_approve";

            rw.table = "t_reward";
            rw.pkField = "reward_id";
        }
        private Reward setData(Reward item, DataTable dt)
        {
            item.dateCancel = dt.Rows[0][rw.dateCancel].ToString();
            item.dateCreate = dt.Rows[0][rw.dateCreate].ToString();
            item.dateModi = dt.Rows[0][rw.dateModi].ToString();
            item.dateReward = dt.Rows[0][rw.dateReward].ToString();
            item.reward1 = dt.Rows[0][rw.reward1].ToString();
            item.rewardDown2 = dt.Rows[0][rw.rewardDown2].ToString();
            item.monthId = dt.Rows[0][rw.monthId].ToString();
            item.yearId = dt.Rows[0][rw.yearId].ToString();
            item.rewardDown31 = dt.Rows[0][rw.rewardDown31].ToString();
            item.rewardDown32 = dt.Rows[0][rw.rewardDown32].ToString();
            item.rewardDown33 = dt.Rows[0][rw.rewardDown33].ToString();
            item.rewardDown34 = dt.Rows[0][rw.rewardDown34].ToString();
            item.periodId = dt.Rows[0][rw.periodId].ToString();
            item.Remark = dt.Rows[0][rw.Remark].ToString();
            item.rewardId = dt.Rows[0][rw.rewardId].ToString();

            item.staffCancel = dt.Rows[0][rw.staffCancel].ToString();
            item.staffCreate = dt.Rows[0][rw.staffCreate].ToString();
            item.staffId = dt.Rows[0][rw.staffId].ToString();
            item.staffModi = dt.Rows[0][rw.staffModi].ToString();

            item.tod31 = item.reward1.Substring(item.reward1.Length - 3,1) + item.reward1.Substring(item.reward1.Length - 2,1) + item.reward1.Substring(item.reward1.Length);
            item.tod32 = item.reward1.Substring(item.reward1.Length - 2) + item.reward1.Substring(item.reward1.Length - 3, 1) + item.reward1.Substring(item.reward1.Length);
            item.tod33 = item.reward1.Substring(item.reward1.Length) + item.reward1.Substring(item.reward1.Length - 2, 1) + item.reward1.Substring(item.reward1.Length-3,1);

            item.tod34 = item.reward1.Substring(item.reward1.Length) + item.reward1.Substring(item.reward1.Length - 3, 1) + item.reward1.Substring(item.reward1.Length-2,1);
            item.tod35 = item.reward1.Substring(item.reward1.Length - 2, 1) + item.reward1.Substring(item.reward1.Length) + item.reward1.Substring(item.reward1.Length-3,1);
            item.tod36 = item.reward1.Substring(item.reward1.Length - 3, 1) + item.reward1.Substring(item.reward1.Length) + item.reward1.Substring(item.reward1.Length-2,1);

            item.statusApprove = dt.Rows[0][rw.statusApprove].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + rw.table + " ";
            dt = conn.selectData(sql);

            return dt;
        }
        public Reward selectByPk(String saleId)
        {
            Reward item = new Reward();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + rw.table + " Where " + rw.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public Reward selectByPeriod(String yearId, String monthId, String periodId)
        {
            Reward item = new Reward();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + rw.table + " Where " +
                rw.yearId + "='" + yearId + "' and " +
                rw.monthId + "='" + monthId + "' and " + rw.periodId + "='" + periodId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private String insert(Reward p)
        {
            String sql = "", chk = "";
            if (p.rewardId.Equals(""))
            {
                p.rewardId = p.getGenID();
            }
            //p.Name = p.Name.Replace("''", "'");
            p.dateCreate = p.dateTimetoDB();
            p.staffCreate = p.staffId;
            p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + rw.table + " (" + rw.pkField + "," + rw.dateReward + "," + rw.staffId + "," +
                rw.reward1 + "," + rw.monthId + "," + rw.periodId + "," +
                rw.rewardDown2 + "," + rw.rewardDown31 + "," + rw.Remark + "," +
                rw.dateCreate + "," + rw.dateModi + "," +
                rw.dateCancel + "," + rw.staffCreate + "," + rw.staffModi + "," +
                rw.staffCancel + "," + rw.yearId + "," + rw.rewardDown32 + "," + rw.rewardDown33 + "," + rw.rewardDown34 + ") " +
                "Values('" + p.rewardId + "','" + p.dateReward + "','" + p.staffId + "','" +
                p.reward1 + "','" + p.monthId + "','" + p.periodId + "','" +
                p.rewardDown2 + "','" + p.rewardDown31 + "','" + p.Remark + "','" +
                p.dateCreate + "',''," +
                 "'','" + p.staffCreate + "',''," +
                "'','" + p.yearId + "','" + p.rewardDown32 + "','" + p.rewardDown33 + "','" + p.rewardDown34 + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.rewardId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Reward");
            }
            finally
            {
            }
            return chk;
        }
        private String update(Reward p)
        {
            String sql = "", chk = "";

            p.Remark = p.Remark.Replace("''", "'");
            p.dateModi = p.dateGenDB;
            p.staffModi = p.staffId;
            sql = "Update " + rw.table + " Set " + rw.dateReward + "='" + p.dateReward + "', " +
                rw.reward1 + "='" + p.reward1 + "', " +
                rw.rewardDown2 + "='" + p.rewardDown2 + "', " +
                rw.rewardDown31 + "='" + p.rewardDown31 + "', " +
                rw.yearId + "='" + p.yearId + "', " +
                rw.monthId + "='" + p.monthId + "', " +
                rw.periodId + "='" + p.periodId + "', " +
                rw.staffId + "='" + p.staffId + "', " +
                rw.staffModi + "='" + p.staffModi + "', " +
                rw.dateModi + "='" + p.dateModi + "', " +
                //rw.rewardDown31 + "='" + p.rewardDown31 + "', " +
                rw.rewardDown32 + "='" + p.rewardDown32 + "', " +
                rw.rewardDown33 + "='" + p.rewardDown33 + "', " +
                rw.rewardDown34 + "='" + p.rewardDown34 + "' " +
                "Where " + rw.pkField + "='" + p.rewardId + "'";
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
        public String insertReward(Reward p)
        {
            Reward item = new Reward();
            String chk = "";
            item = selectByPk(p.rewardId);
            if (item.rewardId == "")
            {
                chk = insert(p);
            }
            else
            {
                chk = update(p);
            }
            return chk;
        }
        public String updateStatusApprove(String rowId, String staffId)
        {
            String sql = "", chk = "";
            sql = "Update " + rw.table + " Set " + rw.statusApprove + "='1'," + 
                rw.dateApprove + "="+ rw.dateGenDB + ","+rw.staffApprove+"='"+staffId+"' "+
                "  Where " + rw.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);

            return chk;
        }
    }
}
