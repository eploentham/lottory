using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.object1
{
    public class Image1:Persistent
    {
        public String Id = "", saleId="", custId="", staffId="", pathFilename="", Active="", yearId="", monthId="", periodId="", statusInput="";
        public override string ToString()
        {
            return Id;
        }
    }
}
