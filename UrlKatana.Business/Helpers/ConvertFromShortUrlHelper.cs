using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlKatana.Business.Helpers
{
    public static class ConvertFromShortUrlHelper
    {
        public static int GetId(string shortUrl)
        {
            CheckForUrlLength(shortUrl);
            uint result = 0;
            
            for (int i = 0; i < shortUrl.Length; i++)
            {
                var charCode = (uint)shortUrl[i];
                uint valueFromChar = GetIntFromCharCode(charCode);
                uint shiftedValue = ShiftValue(valueFromChar, i);
                result += shiftedValue;
            }

            return (int)result;
        }

        private static void CheckForUrlLength(string shortUrl)
        {
            if (shortUrl.Length > ConvertConstants.MaxNumberOfChars)
            {
                throw new ArgumentOutOfRangeException("shortUrl", shortUrl, "Длина параметра url превышает максимально допустимое число символов" + ConvertConstants.MaxNumberOfChars);
            }
        }
        private static uint GetIntFromCharCode(uint charCode)
        {
            if (charCode.IsLetter())
            {
                return charCode.RemoveOffsetForLetter();
            }
            if (charCode.IsDigit())
            {
                return charCode.RemoveOffsetForDigit();
            }

            throw new ArgumentOutOfRangeException("charCode", charCode, "Недопустимый код символа");
        }

        private static bool IsLetter(this uint charCode)
        {
            return charCode >= ConvertConstants.OffsetToLowLetterInASCII && charCode <= ConvertConstants.OffsetToLowLetterInASCII + ConvertConstants.NumberOfLetters;
        }

        private static uint RemoveOffsetForLetter(this uint charCode)
        {
            return charCode - ConvertConstants.OffsetToLowLetterInASCII;
        }

        private static bool IsDigit(this uint charCode)
        {
            return charCode >= ConvertConstants.OffsetToDigitInASCII && charCode <= ConvertConstants.OffsetToDigitInASCII + ConvertConstants.NumberOfDigit;
        }

        private static uint RemoveOffsetForDigit(this uint charCode)
        {
            return charCode - ConvertConstants.OffsetToDigitInASCII + ConvertConstants.NumberOfLetters; 
        }

        private static uint ShiftValue(uint value, int index)
        {
            return value << index * ConvertConstants.NumberOfBitsForOneSymbol;
        }
    }
}
