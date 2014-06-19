using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.object1
{
    public class Thoo : Persistent
    {
        public String Id = "", Name = "", Active = "", Remark = "", Code = "", Color="", Limit1="", Default="", staffModiThooDefault="", dateModiThooDefault="", thooDefaultCnt="";
        public override string ToString()
        {
            return Name;
        }
    }
}
