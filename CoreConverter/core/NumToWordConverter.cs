using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace CoreConverter.core
{
    public class NumToWordConverter : INumToWordConverter
    {
        private WordNumberCollection _wordNumberCollection { get; set; }
        public NumToWordConverter()
        {
            _wordNumberCollection = new WordNumberCollection();
        }

        public string ConvertToWord(List<NumberDescriptor> inputlist,NumberDescriptor pointNum)
        {
            string res = "";
            foreach (NumberDescriptor number in inputlist)
            {
                res += $"{wg(number, inputlist.Count)}";
            }
            if (res.Contains("AND  AND")) {
                res = res.Replace("AND  AND", " AND ");
            }


            var parts=res.Split(' ');
            parts = parts.Where(x => string.IsNullOrEmpty(x) == false).Select(x => x.Trim()).ToArray();
            
            if (parts.Length>0&&parts[0].Contains("AND")) {

                res = string.Join(" ",parts.Skip(1).ToArray());
            }
            res += " DOLLARS ";
            if (pointNum!=null)
            res += $"AND {processPoint(pointNum)}";
            res = res.TrimStart();
            res = res.TrimEnd();
            return res;
        }

        public string WordGenerator(NumberDescriptor numberDescriptor)
        {
            numberDescriptor.number = numberDescriptor.number.PadLeft(3, '0');

            if (numberDescriptor.number.Length > 3)
            {
                throw new InvalidDataException("the length of part larger than 3");
            }
            string wordNumber = "";
            for (int i = 0; i < numberDescriptor.number.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        wordNumber += _wordNumberCollection.hundreds[numberDescriptor.number[i].ToString()];
                        break;
                    case 1:
                        if (numberDescriptor.number[i + 1].ToString() == "1")
                        {
                            wordNumber += _wordNumberCollection.teens[numberDescriptor.number[i].ToString()]=" ";
                        }
                        else
                        {
                            wordNumber += _wordNumberCollection.tens[numberDescriptor.number[i].ToString()];
                        }
                        break;
                    case 2:
                        if (numberDescriptor.number[i - 1].ToString() != "1")
                        {
                            wordNumber += _wordNumberCollection.ones[numberDescriptor.number[i].ToString()] + " ";
                        }

                        break;

                }
            }
            if (numberDescriptor.numberScale != NumberScaleEnum.HUNDRED)
            {

                if (numberDescriptor.number != "000")
                {
                    wordNumber += numberDescriptor.numberScale.ToString();
                }
            }

            return wordNumber;
        }


        public string wg(NumberDescriptor numberDescriptor,int countpart)
        {
            
            numberDescriptor.number = numberDescriptor.number.PadLeft(3, '0');
            string wordnum = "";
            bool hashunderd = false;
            int num = int.Parse(numberDescriptor.number);
            int originalnum = num;

            if (num == 0)
            {
                wordnum = " ";
                goto theend; ;
            }

            if (originalnum<100 ) {
                wordnum += " AND ";
            }
            if (num >= 100)
            {
                wordnum += " " + _wordNumberCollection.hundreds[numberDescriptor.number[0].ToString()];
                Console.WriteLine(wordnum);
                num=num-Convert.ToInt32(Math.Floor((decimal)num / 100))*100;
                if (num == 0)
                {
                    goto numscalelabel;
                }
                else
                {
                    wordnum += " AND ";
                }
            }
            if (num >= 1 && num < 10)
            {
                wordnum += _wordNumberCollection.ones[numberDescriptor.number[2].ToString()] + " ";
                goto numscalelabel;
            }
            if (num >= 10 && num < 20)
            {
                if (originalnum < 100 && countpart < 2) { 
                wordnum+= _wordNumberCollection.teens[numberDescriptor.number[2].ToString()]+" ";
                }
                else
                {
                    wordnum +=" AND "+ _wordNumberCollection.teens[numberDescriptor.number[2].ToString()];
                }
                
                goto numscalelabel;
            }
            if (num >= 20 && num < 100) {
                (wordnum, num) = generateTens(wordnum, numberDescriptor, num);
            }
        numscalelabel:
            if(numberDescriptor.numberScale!=NumberScaleEnum.HUNDRED)
            wordnum += " "+numberDescriptor.numberScale.ToString() + " ";

            theend:  
            return wordnum;
            
        }

        public string processPoint(NumberDescriptor numberDescriptor) {
            string wordnum = "";
            numberDescriptor.number = numberDescriptor.number.PadLeft(3, '0');

            int num = int.Parse(numberDescriptor.number);
            if (num > 100)
            {
                return "";
            }
            if (num < 10) {
                wordnum += _wordNumberCollection.ones[numberDescriptor.number[2].ToString()];
            }
            if (num >= 10 && num < 20)
            {
                wordnum+=_wordNumberCollection.teens[numberDescriptor.number[2].ToString()]+" ";
            }
            if (num>20&&num<100) {
                (wordnum, num) = generateTens(wordnum, numberDescriptor, num);
            }

            if (num > 1) {
                wordnum += " CENTS ";
            }
            return wordnum;
        }

        public (string,int) generateTens(string wordnum, NumberDescriptor numberDescriptor,int num) {
            wordnum += _wordNumberCollection.tens[numberDescriptor.number[1].ToString()] + "-";
            num = num - Convert.ToInt32(Math.Floor((decimal)num / 10));
            wordnum += _wordNumberCollection.ones[numberDescriptor.number[2].ToString()];
            return (wordnum,num);
        }

        public string ConvertToWord(List<NumberDescriptor> inputlist)
        {
            throw new NotImplementedException();
        }
    }
}