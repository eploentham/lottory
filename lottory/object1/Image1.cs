using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.object1
{
    public class Image1:Persistent
    {
        public String Id = "", saleId="", custId="", staffId="", pathFilename="", Active="", yearId="", monthId="", periodId="", statusInput="", FLock="";
        public String staffInputId = "", staffInputName = "", dateInput = "", dateCreate = "", rowNumber = "", thooId = "", saleOldId="", dateMove="", SfMoveId="", sfVoidId="";
        public String SfCheck1Id = "", SfCheck2Id = "", StatusCheck1 = "", StatusCheck2 = "", Amt = "", AmtCheck1 = "", AmtCheck2 = "";
        public override string ToString()
        {
            return Id;
        }
    }
}
