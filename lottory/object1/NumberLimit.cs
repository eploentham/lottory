using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.object1
{
    public class NumberLimit:Persistent
    {
        public String Id = "", number = "", StatusStart = "", yearId = "", monthId = "", periodId = "", Active = "", dateStart = "";
        public String dateCreate = "", dateModi = "", dateCancel = "", staffCreate = "", staffModi = "", staffCancel = "", remark="";
        public String yearLimitId = "", monthLimitId = "", periodLimitId = "", dateEnd = "";
    }
}
