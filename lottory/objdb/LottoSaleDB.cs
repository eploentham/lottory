using lottory.object1;
using System;
using System.Collections.Generic;
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
    }
}
