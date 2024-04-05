using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConverter.validator
{
    public class StringNumberValidator
    {
        private bool _isNegative;
        private string _value;
        public StringNumberValidator(string input) {
        this._value = input;
        }

        public StringNumberValidator WithrestrictNegative()
        {
            if (this._value.IndexOf("-")==0)
            {
                _isNegative = true;
            }

            return this;
        }
    }
}
