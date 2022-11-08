using Microsoft.VisualStudio.TestTools.UnitTesting;
using _11_08;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_08.Tests
{
    [TestClass()]
    public class Program2Tests
    {
        [TestMethod()]
        public void NumarCifreTest()
        {
            // arrange
            int n = -25487;
            int expected = 5;

            // act 
            int actual = Program2.NumarCifre(n);
            
            // assert
            Assert.IsTrue(actual == expected);
            
        }
    }
}