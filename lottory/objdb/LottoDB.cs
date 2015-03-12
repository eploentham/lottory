using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class LottoDB
    {
        ConnectDB conn;
        public Lotto lot;
        String sql = "";
        Double[] reward = new Double[2] { 0, 0 };
        public LottoDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lot = new Lotto();
            lot.dateCancel = "date_cancel";
            lot.dateCreate = "date_create";
            lot.dateModi = "date_modi";
            lot.down = "down1";
            lot.Active = "lotto_active";
            lot.lottoId = "lotto_id";
            lot.monthId = "month_id";
            lot.yearId = "year_id";
            lot.number = "number1";
            lot.periodId = "period1";
            lot.Remark = "remark";
            lot.rowId = "row_id";
            lot.saleId = "sale_id";
            lot.staffCancel = "staff_cancel";
            lot.staffCreate = "staff_create";
            lot.staffId = "staff_id";
            lot.staffModi = "staff_modi";
            lot.thooId = "thoo_id";
            lot.tod = "tod";
            lot.up="up1";
            lot.rowNumber = "row_number";
            lot.OLUp = "over_limit_up";
            lot.use1 = "use1";
            lot.statusOverLimit = "status_over_limit";
            lot.rateId = "rate_id";
            lot.staffApproveId = "staff_approve_id";
            lot.thooTranferId = "thoo_tranfer_id";
            lot.dateApprove = "date_approve";
            lot.statusApprove = "status_approve";
            lot.rUp = "reward_up";
            lot.rUpRate = "reward_up_rate";
            lot.rDown = "reward_down";
            lot.rDownRate = "reward_down_rate";
            lot.r2Up = "reward_2up";
            lot.r2UpRate = "reward_2up_rate";
            lot.r2Down = "reward_2down";
            lot.r2DownRate = "reward_2down_rate";
            //lot.r2Up = "reward_2tod";
            lot.r2UpRate = "reward_2tod_rate";
            lot.r2Tod = "reward_2tod";
            lot.r2TodRate = "reward_2tod_rate";
            lot.r3Up = "reward_3up";
            lot.r3UpRate = "reward_3up_rate";
            lot.r3Down = "reward_3down";
            lot.r3DownRate = "reward_3down_rate";
            lot.r3Tod = "reward_3tod";
            lot.r3TodRate = "reward_3tod_rate";
            lot.CDbl = "cdbl";
            lot.statusInput = "status_input";
            lot.imgId = "img_id";
            lot.log = "log";
            lot.OLTod = "over_limit_tod";
            lot.OLDown = "over_limit_down";
            lot.StatusVoid = "status_void";
            lot.statusInputApprove = "status_input_approve";
            lot.number2 = "number2";
            lot.saleOldId = "sale_old_id";
            lot.SfMoveId = "staff_move_id";
            lot.dateMove = "date_move";

            lot.SfCheck1Id = "staff_check1_id";
            lot.SfCheck2Id = "staff_check2_id";
            lot.StatusCheck1 = "status_check1";
            lot.StatusCheck2 = "status_check2";
            lot.todOld = "tod_old";
            lot.upOld = "up1_old";
            lot.downOld = "down1_old";
            lot.numberOld = "number1_old";

            lot.table = "t_lottory";
            lot.pkField = "row_id";
        }
        private Lotto setData(Lotto item, DataTable dt)
        {
            item.dateCancel = dt.Rows[0][lot.dateCancel].ToString();
            item.dateCreate = dt.Rows[0][lot.dateCreate].ToString();
            item.dateModi = dt.Rows[0][lot.dateModi].ToString();
            item.down = dt.Rows[0][lot.down].ToString();
            item.Active = dt.Rows[0][lot.Active].ToString();
            item.lottoId = dt.Rows[0][lot.lottoId].ToString();
            item.monthId = dt.Rows[0][lot.monthId].ToString();
            item.yearId = dt.Rows[0][lot.yearId].ToString();
            item.number = dt.Rows[0][lot.number].ToString();
            item.periodId = dt.Rows[0][lot.periodId].ToString();
            item.Remark = dt.Rows[0][lot.Remark].ToString();
            item.rowId = dt.Rows[0][lot.rowId].ToString();
            item.saleId = dt.Rows[0][lot.saleId].ToString();
            item.staffCancel = dt.Rows[0][lot.staffCancel].ToString();
            item.staffCreate = dt.Rows[0][lot.staffCreate].ToString();
            item.staffId = dt.Rows[0][lot.staffId].ToString();
            item.staffModi = dt.Rows[0][lot.staffModi].ToString();
            item.thooId = dt.Rows[0][lot.thooId].ToString();
            item.tod = dt.Rows[0][lot.tod].ToString();
            item.up = dt.Rows[0][lot.up].ToString();
            item.rowNumber = dt.Rows[0][lot.rowNumber].ToString();
            item.OLUp = dt.Rows[0][lot.OLUp].ToString();
            item.statusOverLimit = dt.Rows[0][lot.statusOverLimit].ToString();
            item.use1 = dt.Rows[0][lot.use1].ToString();
            item.rateId = dt.Rows[0][lot.rateId].ToString();
            item.statusInput = dt.Rows[0][lot.statusInput].ToString();
            item.imgId = dt.Rows[0][lot.imgId].ToString();

            item.OLDown = dt.Rows[0][lot.OLDown].ToString();
            item.OLTod = dt.Rows[0][lot.OLTod].ToString();
            item.StatusVoid = dt.Rows[0][lot.StatusVoid].ToString();
            item.statusInputApprove = dt.Rows[0][lot.statusInputApprove].ToString();
            item.number2 = dt.Rows[0][lot.number2].ToString();

            item.saleOldId = dt.Rows[0][lot.saleOldId].ToString();
            item.SfMoveId = dt.Rows[0][lot.SfMoveId].ToString();
            item.dateMove = dt.Rows[0][lot.dateMove].ToString();

            item.SfCheck1Id = dt.Rows[0][lot.SfCheck1Id].ToString();
            item.SfCheck2Id = dt.Rows[0][lot.SfCheck2Id].ToString();
            item.StatusCheck1 = dt.Rows[0][lot.StatusCheck1].ToString();
            item.StatusCheck2 = dt.Rows[0][lot.StatusCheck2].ToString();
            item.todOld = dt.Rows[0][lot.todOld].ToString();
            item.upOld = dt.Rows[0][lot.upOld].ToString();
            item.downOld = dt.Rows[0][lot.downOld].ToString();
            item.numberOld = dt.Rows[0][lot.numberOld].ToString();
            
            return item;
        }
        public String selectDateDBtoShow()
        {
            String sql = "", date="";
            DataTable dt = new DataTable();
            sql = lot.getdDateDBtoShow;
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                date = dt.Rows[0]["date1"].ToString();
            }

            return date;
        }
        public String selectCDbl()
        {
            String sql = "", date = "";
            DataTable dt = new DataTable();
            sql = "Select CDbl(Now()) as cdbl;";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                date = dt.Rows[0]["cdbl"].ToString();
            }

            return date;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lot.table + " Where " + lot.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public Lotto selectByPk(String rowId)
        {
            Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lot.table + " Where " + lot.pkField + "='" + rowId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public DataTable selectByLot(String lotId)
        {
            Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lot.table + " Where " + lot.lottoId + "='" + lotId + "' and " + lot.Active + "='1' ";
            dt = conn.selectData(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    item = setData(item, dt);
            //}
            return dt;
        }
        public DataTable selectByImg(String imgId)
        {
            Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lot.table + " Where " + lot.imgId + "='" + imgId + "' and " + lot.Active + "='1' Order By "+lot.rowNumber;
            dt = conn.selectData(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    item = setData(item, dt);
            //}
            return dt;
        }
        public Lotto selectByLRowId(String lotId)
        {
            Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lot.table + " Where " + lot.rowId + "='" + lotId + "' and " + lot.Active + "='1' ";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public DataTable selectDistinctByThooTranfer(String yearId, String monthId, String periodId, String thooId)
        {
            //Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select sum(up1) as up11, sum(tod) as tod1, sum(down1) as down11, " + lot.lottoId + " From " + lot.table + " Where " + lot.thooTranferId + "='" + thooId + "' and " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' " +
                "Group By " + lot.thooTranferId + "," + lot.Active + "," + lot.lottoId;
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByThooTranfer(String yearId, String monthId, String periodId, String thooId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lot.table + " Where " + lot.thooTranferId + "='" + thooId + "' and " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByStaff(String yearId, String monthId, String periodId, String staffId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lot.table + " Where " + lot.staffId + "='" + staffId + "' and " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "'";
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByStaffGroupLot(String yearId, String monthId, String periodId, String staffId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select distinct "+lot.lottoId+","+lot.staffId+","+lot.CDbl+","+lot.statusInput+","+lot.imgId+" From " + lot.table + " Where " + lot.staffId + "='" + staffId + "' and " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' "+
                " Order By " + lot.CDbl;
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByPeriod(String yearId, String monthId, String periodId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select lot.*, sa.sale_name "+
                "From " + lot.table + " as lot "+
                "Inner Join b_sale sa on sa.sale_id = lot.sale_id "+
                "Where  lot." +
                lot.Active + "='1' and lot." + lot.yearId + "='" + yearId + "' and lot." +
                lot.monthId + "='" + monthId + "' and lot." + lot.periodId + "='" + periodId + "' " +
                "Order By lot." + lot.CDbl + ",lot." + lot.rowNumber;
            
            dt = conn.selectData(sql);

            return dt;            
        }
        public DataTable selectByPeriodSale(String yearId, String monthId, String periodId, String saleId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select lot.*, sa.sale_name " +
                "From " + lot.table + " as lot " +
                "Inner Join b_sale sa on sa.sale_id = lot.sale_id " +
                "Where  lot." +
                lot.Active + "='1' and lot." + lot.yearId + "='" + yearId + "' and lot." +
                lot.monthId + "='" + monthId + "' and lot." + lot.periodId + "='" + periodId + "' and lot." + lot.saleId + "='" + saleId + "' " +
                "Order By lot." + lot.CDbl + ",lot." + lot.rowNumber;

            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByPeriod2(String yearId, String monthId, String periodId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select lot."+lot.number +", sum("+lot.up+") as up, sum("+lot.down+") as down " +
                "From " + lot.table + " as lot " +                
                "Where  lot." +
                lot.Active + "='1' and lot." + lot.yearId + "='" + yearId + "' and lot." +
                lot.monthId + "='" + monthId + "' and lot." + lot.periodId + "='" + periodId + "' and len("+lot.number+") =2 " +
                "Group By lot." + lot.number+" Order By lot." + lot.number;

            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByPeriod3(String yearId, String monthId, String periodId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select lot." + lot.number + ", sum( lot." + lot.up + ") as up, sum( lot." + lot.down + ") as down, sum( lot." + lot.tod + ") as tod " +
                "From " + lot.table + " as lot " +
                "Where  lot." +
                lot.Active + "='1' and lot." + lot.yearId + "='" + yearId + "' and lot." +
                lot.monthId + "='" + monthId + "' and lot." + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") =3 " +
                "Group By lot." + lot.number + " Order By lot." + lot.number;

            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByPeriod(String yearId, String monthId, String periodId, String number)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select lot.*, sa.sale_name " +
                "From " + lot.table + " as lot " +
                "Inner Join b_sale sa on sa.sale_id = lot.sale_id " +
                "Where  lot." +
                lot.Active + "='1' and lot." + lot.yearId + "='" + yearId + "' and lot." +
                lot.monthId + "='" + monthId + "' and lot." + lot.periodId + "='" + periodId + "' and "+lot.number+"='"+number+"' " +
                "Order By lot." + lot.CDbl + ",lot." + lot.rowNumber;

            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByPeriodSale(String yearId, String monthId, String periodId, String number, String saleId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select lot.*, sa.sale_name " +
                "From " + lot.table + " as lot " +
                "Inner Join b_sale sa on sa.sale_id = lot.sale_id " +
                "Where  lot." +
                lot.Active + "='1' and lot." + lot.yearId + "='" + yearId + "' and lot." +
                lot.monthId + "='" + monthId + "' and lot." + lot.periodId + "='" + periodId + "' and " + lot.number + "='" + number + "' and lot."+lot.saleId+"='"+saleId+"' " +
                "Order By lot." + lot.CDbl + ",lot." + lot.rowNumber;

            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectBySale(String yearId, String monthId, String periodId, String saleId)
        {
            String sql = "";
            DataTable dt3 = new DataTable();
            sql = "Select * From " + lot.table + " Where " + lot.saleId + "='" + saleId + "' and " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' "+
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            dt3 = conn.selectData(sql);

            return dt3;
        }
        public DataTable selectApprovedByPeriod(String yearId, String monthId, String periodId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.statusApprove + "='1' " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByReward(String yearId, String monthId, String periodId, String rateId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            if (rateId.Equals("up"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.rUp + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("down"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.rDown + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("2down"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r2Down + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            //else if (rateId.Equals("2tod"))
            //{
            //    sql = "Select * From " + lot.table + " Where  " +
            //    lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
            //    lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r2Up + " >0 " +
            //    "Order By " + lot.CDbl + "," + lot.rowNumber;
            //}
            else if (rateId.Equals("2up"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r2Up + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("3down"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r3Down + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("3tod"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r3Tod + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("3up"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r3Up + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else 
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "'  " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
           
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectByLenNumber(String yearId, String monthId, String periodId, String rateId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            if (rateId.Equals("up"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 1 and " + lot.up + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("down"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 1 and " + lot.down + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("2down"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 2 and " + lot.down + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("2tod"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 2 and " + lot.tod + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("2up"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 2 and " + lot.up + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("3down"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 3 and " + lot.down + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("3tod"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 3 and " + lot.tod + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else if (rateId.Equals("3up"))
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 3 and " + lot.up + " >0 " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }
            else
            {
                sql = "Select * From " + lot.table + " Where  " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "'  " +
                "Order By " + lot.CDbl + "," + lot.rowNumber;
            }

            dt = conn.selectData(sql);

            return dt;
        }

        public DataTable selectSumByStaff(String yearId, String monthId, String periodId, String staffId)
        {
            //Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select sum(up1) as up11, sum(tod) as tod1, sum(down1) as down11, "+lot.lottoId+","+lot.saleId+","+lot.CDbl+
                " From " + lot.table + " Where " + lot.staffId + "='" + staffId + "' and " +
                lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' "+
                "Group By "+lot.staffId+","+lot.Active+","+lot.lottoId+","+lot.saleId+","+lot.CDbl+
                " Order By "+lot.CDbl;
            dt = conn.selectData(sql);
            
            return dt;
        }
        public DataTable selectSumBySale(String yearId, String monthId, String periodId)
        {
            //Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select sum(up1) + sum(tod) + sum(down1) as amt, " + lot.saleId + " From " + lot.table + 
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' " +
                "Group By " + lot.saleId ;
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectSumBySale(String yearId, String monthId, String periodId, String saleId)
        {
            //Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select sum(" + lot.r3Up + ") as " + lot.r3Up + ", sum(" + lot.r3Tod + ") as " + lot.r3Tod + ", sum(" + lot.r3Down + ") as " + lot.r3Down +
                ", sum(" + lot.r2Up + ") as " + lot.r2Up + ", sum(" + lot.r2Tod + ") as " + lot.r2Tod + ", sum(" + lot.r2Down + ") as " + lot.r2Down + ", " + lot.saleId + 
                " From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and "+lot.saleId+" ='"+saleId+"' " +
                "Group By " + lot.saleId;
            dt = conn.selectData(sql);

            return dt;
        }
        public Double[] selectSumByRateReward(String yearId, String monthId, String periodId, String rateId)
        {
            //Lotto item = new Lotto();
            //Double[] reward = new Double[2] { 0, 0 };
            //String sql = "";
            //DataTable dt = new DataTable();
            //Double reward = 0;
            if (rateId.Equals("up"))
            {
                sql = "Select sum(" + lot.up + ") as amt, sum(" + lot.rUp + ") as reward From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and "+lot.rUp+">0 ";
            }
            else if (rateId.Equals("down"))
            {
                sql = "Select sum(" + lot.down + ") as amt, sum(" + lot.rDown + ") as reward From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.rDown + ">0 ";
            }
            else if (rateId.Equals("2down"))
            {
                sql = "Select sum(" + lot.down + ") as amt, sum(" + lot.r2Down + ") as reward From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r2Down + ">0 ";
            }
            else if (rateId.Equals("2up"))
            {
                sql = "Select sum(" + lot.up + ") as amt, sum(" + lot.r2Up + ") as reward From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r2Up + ">0 ";
            }
            else if (rateId.Equals("2tod"))
            {
                sql = "Select sum(" + lot.tod + ") as amt, sum(" + lot.r3Tod + ") as reward From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r2Up + ">0 ";
            }
            else if (rateId.Equals("3down"))
            {
                sql = "Select sum(" + lot.down + ") as amt, sum(" + lot.r3Down + ") as reward From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r3Down + ">0 ";
            }
            else if (rateId.Equals("3tod"))
            {
                sql = "Select sum(" + lot.tod + ") as amt, sum(" + lot.r3Tod + ") as reward From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r3Tod + ">0 ";
            }
            else if (rateId.Equals("3up"))
            {
                sql = "Select sum(" + lot.up + ") as amt, sum(" + lot.r3Up + ") as reward From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and " + lot.r3Up + ">0 ";
            }
            conn.selectDataN(sql);
            if (conn.dt.Rows.Count > 0)
            {
                if (conn.dt.Rows[0]["reward"] != null)
                {
                    reward[0] = lot.NumberNull(conn.dt.Rows[0]["amt"]);
                    reward[1] = lot.NumberNull(conn.dt.Rows[0]["reward"]);
                }                
            }
            return reward;
        }
        public Double selectSumByRate(String yearId, String monthId, String periodId, String rateId)
        {
            //Lotto item = new Lotto();
            //Double[] reward = new Double[2] { 0, 0 };
            //String sql = "";
            //DataTable dt = new DataTable();
            Double amt = 0;
            if (rateId.Equals("up"))
            {
                sql = "Select sum(" + lot.up + ") as amt From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 1 and " + lot.up + " >0";
            }
            else if (rateId.Equals("down"))
            {
                sql = "Select sum(" + lot.down + ") as amt From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 1 and " + lot.down + " >0 ";
            }
            else if (rateId.Equals("2down"))
            {
                sql = "Select sum(" + lot.down + ") as amt From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 2 and " + lot.down + " >0 ";
            }
            else if (rateId.Equals("2up"))
            {
                sql = "Select sum(" + lot.up + ") as amt From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 2 and " + lot.up + " >0 ";
            }
            else if (rateId.Equals("2tod"))
            {
                sql = "Select sum(" + lot.tod + ") as amt From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 2 and " + lot.tod + " >0 ";
            }
            else if (rateId.Equals("3down"))
            {
                sql = "Select sum(" + lot.down + ") as amt From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 3 and " + lot.down + " >0";
            }
            else if (rateId.Equals("3tod"))
            {
                sql = "Select sum(" + lot.tod + ") as amt From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len(" + lot.number + ") = 3 and " + lot.tod + " >0";
            }
            else if (rateId.Equals("3up"))
            {
                sql = "Select sum(" + lot.up + ") as amt From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' and len("+lot.number+") = 3 and "+lot.up+" >0";
            }
            conn.selectDataN(sql);
            if (conn.dt.Rows.Count > 0)
            {
                if (conn.dt.Rows[0]["reward"] != null)
                {
                    amt = lot.NumberNull(conn.dt.Rows[0]["amt"]);
                    //reward[1] = lot.NumberNull(conn.dt.Rows[0]["reward"]);
                }
            }
            return amt;
        }
        public DataTable selectSumByThooTranfer(String yearId, String monthId, String periodId)
        {
            //Lotto item = new Lotto();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select sum(up1) + sum(tod) + sum(down1) as amt, " + lot.thooTranferId + " From " + lot.table +
                " Where " + lot.Active + "='1' and " + lot.yearId + "='" + yearId + "' and " +
                lot.monthId + "='" + monthId + "' and " + lot.periodId + "='" + periodId + "' " +
                "Group By " + lot.thooTranferId;
            dt = conn.selectData(sql);

            return dt;
        }
        private String insert(Lotto p)
        {
            String sql = "", chk = "";
            if (p.rowId.Equals(""))
            {
                p.rowId = p.getGenID();
                if (p.rowId.Equals(p.lottoId))
                {
                    p.rowId = p.getGenID();
                }
            }
            p.statusApprove = "";
            p.thooTranferId = "";
            p.dateApprove = "";
            p.staffApproveId = "";
            //p.Name = p.Name.Replace("''", "'");
            //p.dateCreate = System.DateTime.Now.ToString();
            p.dateCreate = p.dateGenDB;
            p.staffCreate = p.staffId;
            p.Remark = p.Remark.Replace("''", "'");
            p.statusInputApprove = "";
            //sql = "Insert Into " + lot.table + " (" + lot.pkField + "," + lot.lottoId + "," + lot.staffId + "," +
            //    lot.number + "," + lot.up + "," + lot.tod + "," + 
            //    lot.down + "," + lot.monthId + "," + lot.periodId + "," + 
            //    lot.saleId + "," + lot.thooId + "," + lot.Remark + "," + 
            //    lot.Active + "," + lot.dateCreate + "," + lot.dateModi + "," + 
            //    lot.dateCancel + "," + lot.staffCreate + "," + lot.staffModi + "," +
            //    lot.staffCancel + "," + lot.yearId + "," + lot.rowNumber+","+
            //    lot.statusApprove+","+lot.thooTranferId+","+lot.dateApprove+","+
            //    lot.staffApproveId + "," + lot.CDbl + "," + lot.statusInput + "," + lot.imgId + ") " +
            //    "Values('" + p.rowId + "','" + p.lottoId + "','" + p.staffId + "','" +
            //    p.number + "','" + p.up + "','" + p.tod + "','" + 
            //    p.down + "','" + p.monthId + "','" + p.periodId + "','" + 
            //    p.saleId + "','" + p.thooId + "','" + p.Remark + "','" + 
            //    p.Active + "'," + p.dateCreate + ",''," + 
            //     "'','" + p.staffCreate + "',''," +
            //    "'','" + p.yearId + "','" + p.rowNumber + "','"+
            //    p.statusApprove+"','"+p.thooTranferId+"','"+p.dateApprove+"','"+
            //    p.staffApproveId + "','" + p.CDbl + "','" + p.statusInput + "','" + p.imgId + "')";
            sql = "Insert Into " + lot.table + " (" + lot.pkField + "," + lot.lottoId + "," + lot.staffId + "," +
                lot.number + "," + lot.up + "," + lot.tod + "," +
                lot.down + "," + lot.monthId + "," + lot.periodId + "," +
                lot.saleId + "," + lot.thooId + "," + lot.Remark + "," +
                lot.Active + "," + lot.dateCreate + "," + lot.dateModi + "," +
                lot.dateCancel + "," + lot.staffCreate + "," + lot.staffModi + "," +
                lot.staffCancel + "," + lot.yearId + "," + lot.rowNumber + "," +
                lot.statusApprove + "," + lot.thooTranferId + "," + lot.dateApprove + "," +
                lot.staffApproveId + "," + lot.CDbl + "," + lot.statusInput + "," +
                lot.imgId + "," + lot.log + "," + lot.statusInputApprove + ") " +
                "Values('" + p.rowId + "','" + p.lottoId + "','" + p.staffId + "','" +
                p.number + "'," + p.up + "," + p.tod + "," +
                p.down + ",'" + p.monthId + "','" + p.periodId + "','" +
                p.saleId + "','" + p.thooId + "','" + p.Remark + "','" +
                p.Active + "'," + p.dateCreate + ",''," +
                 "'','" + p.staffCreate + "',''," +
                "'','" + p.yearId + "','" + p.rowNumber + "','" +
                p.statusApprove + "','" + p.thooTranferId + "','" + p.dateApprove + "','" +
                p.staffApproveId + "','" + p.CDbl + "','" + p.statusInput + "','" + 
                p.imgId + "','','" + p.statusInputApprove+"')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.rowId;
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
        private String update(Lotto p)
        {
            String sql = "", chk = "";

            p.Remark = p.Remark.Replace("''", "'");
            //p.dateModi = System.DateTime.Now.ToString();
            p.dateModi = p.dateGenDB;
            p.staffModi = p.staffId;
            sql = "Update " + lot.table + " Set " + lot.number + "='" + p.number + "', " +
                lot.up + "=" + p.up + ", " +
                lot.tod + "=" + p.tod + ", " +
                lot.down + "=" + p.down + ", " +
                lot.yearId + "='" + p.yearId + "', " +
                lot.monthId + "='" + p.monthId + "', " +
                lot.periodId + "='" + p.periodId + "', " +
                lot.saleId + "='" + p.saleId + "', " +
                lot.thooId + "='" + p.thooId + "', " +
                lot.staffId + "='" + p.staffId + "', " +
                lot.staffModi + "='" + p.staffModi + "', " +
                lot.dateModi + "=" + p.dateModi + ", " +
                lot.Remark + "='" + p.Remark + "' " +
                "Where " + lot.pkField + "='" + p.rowId + "'";
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
        public String updateCheck(Lotto p)
        {
            String sql = "", chk = "";

            p.Remark = p.Remark.Replace("''", "'");
            //p.dateModi = System.DateTime.Now.ToString();
            p.dateModi = p.dateGenDB;
            p.staffModi = p.staffId;
            sql = "Update " + lot.table + " Set " + lot.number + "='" + p.number + "', " +
                lot.up + "=" + p.up + ", " +
                lot.tod + "=" + p.tod + ", " +
                lot.down + "=" + p.down + ", " +
                lot.upOld + "=" + lot.up + ", " +
                lot.todOld + "=" + lot.tod + ", " +
                lot.downOld + "=" + lot.down + ", " +
                lot.numberOld + "=" + lot.number + ", " +
                //lot.thooId + "='" + p.thooId + "', " +
                lot.SfCheck1Id + "='" + p.SfCheck1Id + "' " +
                //lot.staffModi + "='" + p.staffModi + "', " +
                //lot.dateModi + "=" + p.dateModi + ", " +
                //lot.Remark + "='" + p.Remark + "' " +
                "Where " + lot.pkField + "='" + p.lottoId + "'";
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
        public String insertLotto(Lotto p)
        {
            Lotto item = new Lotto();
            String chk = "";
            item = selectByPk(p.rowId);
            if (item.rowId == "")
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
            sql = "Delete From " + lot.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateApprove(String rowId, String OLUp, String OLTod, String OLDown, String use1, String statusOL, String thooTranferId, String staffApproveId)
        {
            String sql = "", chk = "";

            sql = "Update "+lot.table+" Set "+lot.OLUp+"="+OLUp+", "+
                lot.use1 + "=" + use1 + ", " +
                lot.statusOverLimit+"='"+statusOL+"', "+
                lot.dateApprove+"="+lot.dateGenDB+","+
                lot.thooTranferId+"='"+thooTranferId+"', "+
                lot.staffApproveId + "='" + staffApproveId + "', " +
                lot.OLDown + "=" + OLDown + ", " +
                lot.OLTod + "=" + OLTod + ", " +
                lot.statusApprove+"='1' "+
                "Where "+lot.pkField+"='"+rowId+"'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateThoo(String rowId, String thooId)
        {
            String sql = "", chk = "";

            sql = "Update " + lot.table + " Set " + lot.thooId + "='" + thooId + "' " +
                "Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateThooTranfer(String rowId, String thooId)
        {
            String sql = "", chk = "";

            sql = "Update " + lot.table + " Set " + lot.thooTranferId + "='" + thooId + "' " +
                "Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateRewardUp(String rowId, String rate, String up)
        {
            String sql = "", chk="";
            sql = "Update "+lot.table +" Set "+lot.rUp+"='"+up+"',"+lot.rUpRate+"='"+rate+"' Where "+lot.pkField+"='"+rowId+"'";
            chk = conn.ExecuteNonQuery(sql);

            return chk;
        }
        public String updateRewardDown(String rowId, String rate, String down)
        {
            String sql = "", chk = "";
            sql = "Update " + lot.table + " Set " + lot.rDown + "='" + down + "'," + lot.rDownRate + "='" + rate + "' Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);

            return chk;
        }
        public String updateReward2Up(String rowId, String rate, String up)
        {
            String sql = "", chk = "";
            sql = "Update " + lot.table + " Set " + lot.r2Up + "='" + up + "'," + lot.r2UpRate + "='" + rate + "' Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);

            return chk;
        }
        public String updateReward2Down(String rowId, String rate, String down)
        {
            String sql = "", chk = "";
            sql = "Update " + lot.table + " Set " + lot.r2Down + "='" + down + "'," + lot.r2DownRate + "='" + rate + "' Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);

            return chk;
        }
        public String updateReward3Up(String rowId, String rate, String up)
        {
            String sql = "", chk = "";
            sql = "Update " + lot.table + " Set " + lot.r3Up + "='" + up + "'," + lot.r3UpRate + "='" + rate + "' Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);

            return chk;
        }
        public String updateReward3Down(String rowId, String rate, String down)
        {
            String sql = "", chk = "";
            sql = "Update " + lot.table + " Set " + lot.r3Down + "='" + down + "'," + lot.r3DownRate + "='" + rate + "' Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);

            return chk;
        }
        public String updateReward3Tod(String rowId, String rate, String tod)
        {
            String sql = "", chk = "";
            sql = "Update " + lot.table + " Set " + lot.r3Tod + "='" + tod + "'," + lot.r3TodRate + "='" + rate + "' Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);

            return chk;
        }
        public String VoidLotto(String lotId, String sfId)
        {
            String sql = "", chk = "";

            sql = "Update " + lot.table + " Set " + lot.Active + "='3', " +
                lot.dateCancel + "=" + lot.dateGenDB + ", " +
                lot.StatusVoid + "='2', " +
                lot.staffCancel + "=" + sfId + " " +
                "Where " + lot.lottoId + "='" + lotId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String VoidRowId(String rowId, String sfId)
        {
            String sql = "", chk = "";
            //p = p.dateGenDB;
            sql = "Update " + lot.table + " Set " + lot.Active + "='3', " +
                lot.dateCancel+"="+lot.dateGenDB+", "+
                lot.StatusVoid + "='1', " +
                lot.staffCancel + "=" + sfId + " " +
                "Where " + lot.pkField + "='" + rowId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String VoidImage(String imgId, String sfId)
        {
            String sql = "", chk = "";

            sql = "Update " + lot.table + " Set " + lot.Active + "='3', " +
                lot.dateCancel + "=" + lot.dateGenDB + ", " +
                lot.StatusVoid + "='2', " +
                lot.staffCancel + "=" + sfId + " " +
                "Where " + lot.imgId + "='" + imgId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String UpdateSaleFromImage(String imgId, String saleNewId, String sfId)
        {
            String sql = "", chk = "";

            sql = "Update " + lot.table + " Set " +
                lot.saleId + "='" + saleNewId + "', " +
                lot.saleOldId + "=" + lot.saleId + ", " +
                lot.SfMoveId + "='" + sfId + "' " +
                "Where " + lot.imgId + "='" + imgId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateInputApprove(String rowId, String sfId, String number, String up, String tod, String down)
        {
            String sql = "", chk = "";

            //p.Remark = p.Remark.Replace("''", "'");
            ////p.dateModi = System.DateTime.Now.ToString();
            //p.dateModi = p.dateGenDB;
            //p.staffModi = p.staffId;
            sql = "Update " + lot.table + " Set " + lot.number + "='" + number + "', " +
                lot.up + "=" + up + ", " +
                lot.tod + "=" + tod + ", " +
                lot.down + "=" + down + ", " +
                lot.dateModi + "=" + lot.dateGenDB + ", " +
                lot.staffModi + "=" + sfId + " " +

                "Where " + lot.pkField + "='" + rowId + "'";
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
        public String updateStatusInputApprove(String lotId)
        {
            String sql = "", chk = "";

            sql = "Update " + lot.table + " Set " + lot.statusInputApprove + "='1' " +
                "Where " + lot.lottoId + "='" + lotId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
