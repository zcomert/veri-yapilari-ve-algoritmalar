using InSystemDataStructure;

namespace InSystemDataStructureTest
{
    public class TestOfInSystem
    {
        [Fact]
        public void Add_Get_Test()
        {
            SystemDataStructure<int> dataStructure = new SystemDataStructure<int>();
            dataStructure.Add(1);
            dataStructure.Add(2);
            dataStructure.Add(3);
            dataStructure.Add(4);

            // 1 4 3 2
            Assert.Equal(1, dataStructure.GetValue("array"));
            Assert.Equal(4, dataStructure.GetValue("linkedlist"));
            Assert.Equal(4, dataStructure.GetValue("stack"));

            Assert.Equal(3, dataStructure.GetValueIndex(2, "array"));
            Assert.Equal(2, dataStructure.GetValueIndex(2, "linkedlist"));
            Assert.Equal(2, dataStructure.GetValueIndex(2, "stack"));
        }
    }
}