// Veri türü ve limit

Console.WriteLine($"Decimal {decimal.MinValue} - {decimal.MaxValue}");
Console.WriteLine($"Float {float.MinValue} - {float.MaxValue}");


Console.WriteLine($"Int128  {Int128.MinValue} - {Int128.MaxValue}");
Console.WriteLine($"UInt128 {UInt128.MinValue} - {UInt128.MaxValue}");

Console.WriteLine($"Int64  {Int64.MinValue} - {Int64.MaxValue}");
Console.WriteLine($"Int32  {Int32.MinValue} - {Int32.MaxValue}");
Console.WriteLine($"Int16  {Int16.MinValue} - {Int16.MaxValue}");
Console.WriteLine($"UInt16 {UInt16.MinValue} - {UInt16.MaxValue}");
Console.WriteLine($"Long   {long.MinValue} - {long.MaxValue}");

Console.WriteLine($"Byte {Byte.MinValue} - {Byte.MaxValue}");
Console.WriteLine($"Byte {SByte.MinValue} - {SByte.MaxValue}");

// sbyte 
var numbers = new List<String>()
{
    "00000000",     // 0
    "00000001",     // 1
    "00001111",     // 1 + 2 + 4 + 8 = 15
    "10000000",     // -128
    "10000001",     // -127
    "11111111"      // -127 + 1 + 2 + 4 + 8 + 16 + 32 + 64 = -1
};

foreach (var number in numbers)
{
    var value = Convert.ToSByte(number, 2);
    Console.WriteLine($"{number} = {value}");
}

Console.ReadKey();