﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConverter.core
{
    public interface INumToWordConverter : IConverter
    {
        string ConvertToWord(List<NumberDescriptor> inputlist);
    }
}