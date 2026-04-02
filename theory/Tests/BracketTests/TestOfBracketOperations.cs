using Brackets;

namespace BracketTests
{
    public class TestOfBracketOperations
    {
        [Fact]
        public void CorrectTest()
        {
            string code = "void main(){int a = 5; print(a);}";

            BracketOperations brackets = new BracketOperations();
            var result = brackets.Checker(code);

            Assert.True(result);
        }

        [Fact]
        public void FalseTest()
        {
            string code = "void main()int a = 5;} print(a);}";

            BracketOperations brackets = new BracketOperations();
            var result = brackets.Checker(code);

            Assert.False(result);
        }

        [Fact]
        public void CorrectAsNumberTest()
        {
            string code = "void main(){int a = 5; print(a);}";

            BracketOperations brackets = new BracketOperations();
            var result = brackets.CheckerAsNumber(code);

            Assert.Equal(0, result);
        }

        [Fact]
        public void FalseAsNumberTest()
        {
            string code = "void main()int a = 5;} print(a);}";

            BracketOperations brackets = new BracketOperations();
            var result = brackets.CheckerAsNumber(code);

            Assert.Equal(2, result);
        }
    }
}