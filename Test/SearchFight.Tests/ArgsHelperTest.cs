using SearchFight.Console.UI.Helper;
using Xunit;

namespace SearchFight.Tests
{
    public class ArgsHelperTest
    {
        [Fact]
        public void ExtractArgs_IncludeQuotedArg()
        {
            // Arrange
            string stringArgs = ".net java \"java script\"";
            // Act
            var args = ArgsHelper.ExtractArgs(stringArgs);
            // Assert
            Assert.Equal(3, args.Count);
        }
    }
}
