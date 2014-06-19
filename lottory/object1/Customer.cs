using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.object1
{
    public class Customer:Persistent
    {
        public String Id = "", Name="", saleId="", thoId="", Active="", saleName="";
        public override string ToString()
        {
            return saleName+"."+Name;
        }
    }
}
