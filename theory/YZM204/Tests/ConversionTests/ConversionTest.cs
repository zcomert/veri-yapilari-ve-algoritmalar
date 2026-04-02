using Conversions;

namespace ConversionTests
{
    public class ConversionTest
    {
        [Fact]
        public void DecimalToUnsignedBinaryTest()
        {
            // Arrange - Act - Assert
            var binary = Convertor.DecimalToUnsignedBinary(15);

            Assert.Equal("00001111", binary);
        }

        [Fact]
        public void UnsignedBinaryToDecimalTest()
        {
            var number = Convertor.UnsignedBinaryToDecimal("00001010");

            Assert.Equal((uint)10, number);
        }

        [Fact]
        public void DecimalToSignedBinaryTest()
        {
            var binary = Convertor.DecimalToSignedBinary(-5);

            Assert.Equal("11111011", binary);
        }

        [Fact]
        public void SignedBinaryToDecimalTest()
        {
            var binary = Convertor.SignedBinaryToDecimal("11111011");

            Assert.Equal(-5, binary);
        }
    }
}