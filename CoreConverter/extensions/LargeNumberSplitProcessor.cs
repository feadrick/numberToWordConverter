using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConverter.preprocessor
{
    public static class stringExtension
    {

        public static (List<NumberDescriptor>,NumberDescriptor)  splitNumber(this string unsplittedinput, int characterPerPart=3) {
            string input = "";
            string pointInput = "";
            if (unsplittedinput.Contains('.'))
            {
                var parts = unsplittedinput.Split('.');
                input = parts[0];
                pointInput = parts[1];
            }
            else { 
            input = unsplittedinput;
            }

            List<NumberDescriptor> list = new List<NumberDescriptor>();
            var remainder = input.Count() % characterPerPart;
            int partCount = input.Count() / characterPerPart;
            if (remainder > 0) {
                var remainderinput = new string(input.Take(remainder).ToArray());
                list.Add(new NumberDescriptor() {  number= remainderinput,numberScale=(NumberScaleEnum)partCount+1});
            }
            var eventInput = input.Skip(remainder).Take(input.Count() - remainder).ToArray();
            int offset = 0;
            for (int i = partCount; i > 0; i--) {
                list.Add(new NumberDescriptor() {number=new string(eventInput.Skip(offset).Take(3).ToArray()),numberScale=(NumberScaleEnum)i});
                offset = offset + 3;
            }
            NumberDescriptor pointnum = null;
            
            if (!string.IsNullOrEmpty(pointInput)) {
                pointnum = new NumberDescriptor() { number = pointInput, numberScale = NumberScaleEnum.POINT };
            }
            return (list,pointnum);
        }
    }
}
