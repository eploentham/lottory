﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottory.object1
{
    public class ComboBoxItem
    {
        public String Text { get; set; }
        public String Value { get; set; }

        public override String ToString()
        {
            return Text;
        }
    }
}
