﻿using lottory.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory
{
    public class Reward : Persistent
    {
        public String Id = "", yearId="", monthId="", periodId="", reward1="", rewardDown2="", rewardDown31="", Remark="", dateReward="", staffCreate = "", staffModi = "", staffCancel = "";
        public String dateCreate = "", dateModi = "", dateCancel = "", staffId = "", rewardDown32 = "", rewardDown33 = "", rewardDown34 = "";
        public String up3 = "", down2 = "", tod31 = "", tod32 = "", tod33 = "", tod34 = "", tod35 = "", tod36 = "", statusApprove="", dateApprove="", staffApprove="", up2="";
        public override string ToString()
        {
            return Id;
        }
    }
}
