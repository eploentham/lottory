using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lottory.objdb
{
    public class LottoSaleDB
    {
        ConnectDB conn;
        LottoSale lSale;
        public LottoSaleDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lSale = new LottoSale();
            lSale.Active = "lot_sale_active";
            lSale.Amount = "amount";
            lSale.AmountPer = "amount_per";
            lSale.Id = "lot_sale_id";
            lSale.monthId = "month_id";
            lSale.periodId = "period1";
            lSale.rowNumber = "row_number";
            lSale.saleId = "sale_id";
            lSale.saleName = "sale_name";
            lSale.yearId = "year_id";

            lSale.table = "t_lottory_sale";
            lSale.pkField = "lot_sale_id";
        }
        private LottoSale setData(LottoSale item, DataTable dt)
        {
            item.Active = dt.Rows[0][lSale.Active].ToString();
            item.Amount = dt.Rows[0][lSale.Amount].ToString();
            item.AmountPer = dt.Rows[0][lSale.AmountPer].ToString();
            item.Id = dt.Rows[0][lSale.Id].ToString();
            item.monthId = dt.Rows[0][lSale.monthId].ToString();

            item.periodId = dt.Rows[0][lSale.periodId].ToString();
            item.rowNumber = dt.Rows[0][lSale.rowNumber].ToString();
            item.saleId = dt.Rows[0][lSale.saleId].ToString();
            item.saleName = dt.Rows[0][lSale.saleName].ToString();
            item.yearId = dt.Rows[0][lSale.yearId].ToString();

            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lSale.table + " Where " + lSale.Active + "='1' Order By " + lSale.saleName;
            dt = conn.selectData(sql);

            return dt;
        }
        public LottoSale selectByPk(String lThoId)
        {
            LottoSale item = new LottoSale();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + lSale.table + " Where " + lSale.pkField + "='" + lThoId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
    }
}
