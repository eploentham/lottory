using lottory.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.objdb
{
    public class LottoThoDB
    {
        ConnectDB conn;
        public LottoTho lTho;
        public LottoThoDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lTho = new LottoTho();
            lTho.Active = "lto_tho_active";
            lTho.Amount = "amount";
            lTho.AmountPer = "amount_per";
            lTho.Id = "lot_tho_id";
            lTho.monthId = "month_id";
            lTho.periodId = "period1";
            lTho.rowNumber = "row_number";
            lTho.thoId = "tho_id";
            lTho.thoName = "tho_name";
            lTho.yearId = "year_id";

            lTho.table = "t_lottory_tho";
            lTho.pkField = "lot_tho_id";
        }
    }
}
