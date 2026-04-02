using System;
using System.Collections.Generic;
using Xunit;

namespace DataMinMaxTests
{
    public class DataMinMaxTests
    {
        [Fact]
        public void Decimal_MinMax_AreCorrect()
        {
            Assert.Equal(-79228162514264337593543950335m, decimal.MinValue);
            Assert.Equal(79228162514264337593543950335m, decimal.MaxValue);
        }

        [Fact]
        public void Float_MinMax_AreCorrect()
        {
            Assert.Equal(-3.40282347E+38f, float.MinValue);
            Assert.Equal(3.40282347E+38f, float.MaxValue);
        }

        [Fact]
        public void Int128_MinMax_AreCorrect()
        {
            Assert.Equal(Int128.Parse("-170141183460469231731687303715884105728"), Int128.MinValue);
            Assert.Equal(Int128.Parse("170141183460469231731687303715884105727"), Int128.MaxValue);
        }

        [Fact]
        public void UInt128_MinMax_AreCorrect()
        {
            Assert.Equal(UInt128.MinValue, UInt128.Parse("0"));
            Assert.Equal(UInt128.Parse("340282366920938463463374607431768211455"), UInt128.MaxValue);
        }

        [Fact]
        public void Int64_MinMax_AreCorrect()
        {
            Assert.Equal(-9223372036854775808L, Int64.MinValue);
            Assert.Equal(9223372036854775807L, Int64.MaxValue);
        }

        [Fact]
        public void Int32_MinMax_AreCorrect()
        {
            Assert.Equal(-2147483648, Int32.MinValue);
            Assert.Equal(2147483647, Int32.MaxValue);
        }

        [Fact]
        public void Int16_MinMax_AreCorrect()
        {
            Assert.Equal(-32768, Int16.MinValue);
            Assert.Equal(32767, Int16.MaxValue);
        }

        [Fact]
        public void UInt16_MinMax_AreCorrect()
        {
            Assert.Equal(0, UInt16.MinValue);
            Assert.Equal(65535, UInt16.MaxValue);
        }

        [Fact]
        public void Long_MinMax_AreCorrect()
        {
            Assert.Equal(long.MinValue, -9223372036854775808L);
            Assert.Equal(long.MaxValue, 9223372036854775807L);
        }

        [Fact]
        public void Byte_MinMax_AreCorrect()
        {
            Assert.Equal(0, Byte.MinValue);
            Assert.Equal(255, Byte.MaxValue);
        }

        [Fact]
        public void SByte_MinMax_AreCorrect()
        {
            Assert.Equal(-128, SByte.MinValue);
            Assert.Equal(127, SByte.MaxValue);
        }

        [Theory]
        [InlineData("00000000", 0)]
        [InlineData("00000001", 1)]
        [InlineData("00001111", 15)]
        [InlineData("10000000", -128)]
        [InlineData("10000001", -127)]
        [InlineData("11111111", -1)]
        public void SByte_BinaryString_Conversion_IsCorrect(string binary, sbyte expected)
        {
            var value = Convert.ToSByte(binary, 2);
            Assert.Equal(expected, value);
        }
    }
}
