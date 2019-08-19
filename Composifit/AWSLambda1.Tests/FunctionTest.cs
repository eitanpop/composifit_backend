using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

namespace Composifit.Lambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {
            string testString = "hello World";
            Function function = new Function();
            string result = function.FunctionHandler(testString, null);
        
            Assert.Equal( "HELLO WORLD", result);
        }
    }
}
