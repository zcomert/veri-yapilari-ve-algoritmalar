namespace DataTypeConsoleAppTests;

public class DataTypeConsoleAppTest
{
    [Fact]
    public void Check_Value_Type()
    {
        // Test | 3A

        // arrange
        int a = 5;
        int b = a;

        // act
        a = a + 1;

        // assert
        Assert.Equal(6, a);    
    }

    [Fact]
    public void Check_Value_RefType() { 
        //Arrange
        var list1= new List<int>() { 1, 2, 3 };
        var list2 = list1;

        //act
        list1.Add(55);

        //assert
        Assert.True(list1.Count == list2.Count);


    }
}