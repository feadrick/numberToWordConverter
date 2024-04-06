using CoreConverter;
using CoreConverter.core;
using CoreConverter.preprocessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterUnitTest
{
    public class ConverterUnitTest
    {
        NumToWordConverter converter;
        [SetUp]
        public void setup() {
            converter = new NumToWordConverter();
        }

        public string baseProcess(string input) {
            (List<NumberDescriptor> listpart, NumberDescriptor decimalpoint) = input.splitNumber();
            string result = converter.ConvertToWord(listpart, decimalpoint);
            return result;
        }

        [Test]
        public void convertNumberWithDecimal_Test() {
            string actual = baseProcess("123.45");
            Assert.That(actual, Is.EqualTo("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"));
        }
        [Test]
        public void convertNumberOnes_Test()
        {
            string actual = baseProcess("5");
            Assert.That(actual, Is.EqualTo("FIVE DOLLARS"));
        }

        [Test]
        public void convertNumberTeens() {
            string actual = baseProcess("16");
            Assert.That(actual, Is.EqualTo("SIXTEEN DOLLARS"));
        }

        [Test]
        public void ConvertNumberTens()
        {
            string actual = baseProcess("45");
            Assert.That(actual, Is.EqualTo("FORTY-FIVE DOLLARS"));
        }

        [Test]
        public void convertNumberHundreds() {
            string actual = baseProcess("100");
            Assert.That(actual, Is.EqualTo("ONE HUNDRED DOLLARS"));
        }

        [Test]
        public void convertNumberThousands()
        {
            string actual = baseProcess("1000");
            Assert.That(actual, Is.EqualTo("ONE THOUSAND DOLLARS"));
        }
        [Test]
        public void convertNumberMillions()
        {
            string actual = baseProcess("1000000");
            Assert.That(actual, Is.EqualTo("ONE MILLION DOLLARS"));
        }

        //largest number
        [Test]
        public void convertNumberDuosexagintillion()
        {
            string actual = baseProcess("1".PadRight(190,'0'));
            Assert.That(actual, Is.EqualTo("ONE DUOSEXAGINTILLION DOLLARS"));
        }
    }
}
