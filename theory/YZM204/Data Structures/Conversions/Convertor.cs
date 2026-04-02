namespace Conversions
{
    public class Convertor
    {
        // Part 1: Unsigned Binary - Decimal
        // Method 1: Decimal => Unsigned Binary
        public static string DecimalToUnsignedBinary(uint number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException("Negative number is not valid!");
            // 0 - 255 = 256
            if (number > 255) number = 255;

            string binary = "";

            if (number == 0) return binary.PadLeft(8, '0');

            while (number > 0)
            {
                binary = (number % 2) + binary;
                number /= 2;
            }

            return binary.PadLeft(8, '0');
        }

        // Method 2: Unsigned Binary => Decimal
        public static uint UnsignedBinaryToDecimal(string binary)
        {
            int number = 0;
            int power = 0;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1') number += (int)Math.Pow(2, power);
                power++;
            }

            return (uint)number;
        }

        // Part 2: SignedBinary - Decimal
        // Method 1: Decimal => Signed Binary
        public static string DecimalToSignedBinary(int number)
        {
            if (number < -128) number = -128;
            if (number > 127) number = 127;

            string binary = DecimalToUnsignedBinary((uint)Math.Abs(number));
            if (number >= 0) return binary;

            char[] bits = binary.ToCharArray();

            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i] == '1') bits[i] = '0';
                else bits[i] = '1';
            }

            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i] == '0')
                {
                    bits[i] = '1';
                    break;
                }
                else
                    bits[i] = '0';
            }

            return new string(bits);
        }

        // Method 2: Signed Binary => Decimal
        public static int SignedBinaryToDecimal(string binary)
        {
            if (binary[0] == '0') return (int)UnsignedBinaryToDecimal(binary);

            char[] bits = binary.ToCharArray();

            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i] == '1')
                {
                    bits[i] = '0';
                    break;
                }
                else
                    bits[i] = '1';
            }

            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i] == '1') bits[i] = '0';
                else bits[i] = '1';
            }

            return (int)UnsignedBinaryToDecimal(new string(bits)) * -1;
        }
    }
}
