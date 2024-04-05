using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConverter
{
    internal  class WordNumberCollection
    {
        public  readonly Dictionary<string, string> ones = new Dictionary<string, string>()
        {
            {"0",""},
            {"1","ONE"},
            {"2","TWO"},
            {"3","THREE"},
            {"4","FOUR"},
            {"5","FIVE"},
            {"6","SIX"},
            {"7","SEVEN"},
            {"8","EIGHT"},
            {"9","NINE"}
        };


        public readonly Dictionary<string, string> tens = new Dictionary<string, string>
        {
            {"0",""},
            { "1", "TEN" },
            { "2", "TWENTY" },
            { "3", "THIRTY" },
            { "4", "FORTY" },
            { "5", "FIFTY" },
            { "6", "SIXTY" },
            { "7", "SEVENTY" },
            { "8", "EIGHTY" },
            { "9", "NINETY" }
        };

        public readonly Dictionary<string, string> hundreds = new Dictionary<string, string>()
        {
            {"0",""},
            {"1","ONE HUNDRED"},
            {"2","TWO HUNDRED"},
            {"3","THREE HUNDRED"},
            {"4","FOUR HUNDRED"},
            {"5","FIVE HUNDRED"},
            {"6","SIX HUNDRED"},
            {"7","SEVEN HUNDRED"},
            {"8","EIGHT HUNDRED"},
            {"9","NINE HUNDRED"}
        };
        public readonly Dictionary<string, string> teens = new Dictionary<string, string>
        {
            { "0", "TEN" },
            { "1", "ELEVEN" },
            { "2", "TWELVE" },
            { "3", "THIRTEEN" },
            { "4", "FOURTEEN" },
            { "5", "FIFTEEN" },
            { "6", "SIXTEEN" },
            { "7", "SEVENTEEN" },
            { "8", "EIGHTEEN" },
            { "9", "NINETEEN" }
        };


    }
}
