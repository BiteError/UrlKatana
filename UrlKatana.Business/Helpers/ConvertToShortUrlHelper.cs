using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlKatana.Business.Helpers
{    
    public static class ConvertToShortUrlHelper
    {
        public static string GetShortUrl(int value)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < ConvertConstants.MaxNumberOfChars; i++)
            {
                char nextChar = GetNextChar((uint)value, i);
                stringBuilder.Append(nextChar);
            }

            return stringBuilder.ToString();
        }

        private static char GetNextChar(uint value, int index)
        {
            uint shiftedValue = ShiftValue(value, index);
            uint code = GetCharCodeFromInt(shiftedValue);
            return (char)code;            
        }

        private static uint ShiftValue(uint value, int index)
        {
            return value >> index * ConvertConstants.NumberOfBitsForOneSymbol << ConvertConstants.MaxNumberOfBits - ConvertConstants.NumberOfBitsForOneSymbol >> ConvertConstants.MaxNumberOfBits - ConvertConstants.NumberOfBitsForOneSymbol;
        }

        private static uint GetCharCodeFromInt(uint shiftedValue)
        {
            if (shiftedValue.IsForLetter())
            {
                return shiftedValue.GetOffsetForLetter();
            }

            if (shiftedValue.IsForDigit())
            {
                return shiftedValue.GetOffsetForDigit();
            }

            throw new ArgumentOutOfRangeException("shiftedValue", shiftedValue, "Значение параметра превышает максимально допустимое значение:" + ConvertConstants.MaxShiftedValue);
        }

        private static bool IsForLetter(this uint shiftedValue)
        {
            return shiftedValue <= ConvertConstants.MaxShiftedValueForLetters;
        }

        private static uint GetOffsetForLetter(this uint shiftedValue)
        {
            return shiftedValue + ConvertConstants.OffsetToLowLetterInASCII;
        }

        private static bool IsForDigit(this uint shiftedValue)
        {
            return shiftedValue > ConvertConstants.MaxShiftedValueForLetters && shiftedValue <= ConvertConstants.MaxShiftedValue;
        }

        private static uint GetOffsetForDigit(this uint shiftedValue)
        {
            return shiftedValue - ConvertConstants.MinShiftedValueForDigits + ConvertConstants.OffsetToDigitInASCII;
        }
    }
}
