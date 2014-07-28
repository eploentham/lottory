using lottory.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.objdb
{
    public class LottoRateDB
    {
        ConnectDB conn;
        public LottoRate lRate;
        public LottoRateDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lRate = new LottoRate();
            lRate.Active = "lot_rate_actice";
            lRate.Amount = "amount";
            lRate.AmountR = "amount_reward";
            lRate.Description = "rate_description";
            lRate.Id = "lot_rate_id";
            lRate.limit1 = "limit1";
            lRate.monthId = "month_id";
            lRate.NetTotal = "nettotal";
            lRate.pay = "pay";
            lRate.periodId = "period1";
            lRate.rateId = "rate_id";
            lRate.Reward = "reward";
            lRate.rec = "rec";
            lRate.rowNumber = "row_number";
            lRate.yearId = "year_id";

            lRate.table = "t_lottory_rate";
            lRate.pkField = "lot_rate_id";
        }
    }
}
