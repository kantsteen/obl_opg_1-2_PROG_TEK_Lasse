using Microsoft.VisualStudio.TestTools.UnitTesting;
using obl_opg_1_PROG_TEK_Lasse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obl_opg_1_PROG_TEK_Lasse.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        private Trophy trophy;
        [TestInitialize()]
        public void TrophyInitialize()
        {
            trophy = new Trophy
            {
                Id = 1,
                Competition = "Football",
                Year = 2025
            };
        }


        [TestMethod()]
        public void CompetitionNullTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => trophy.Competition = null);
        }

        [TestMethod()]
        public void CompetitionLengthTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Competition = "FB");
        }



        [TestMethod()]
        public void Year1970Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 1969);
        }



        [TestMethod()]
        public void YearCurrentTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = DateTime.Now.Year + 1);
        }



        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Id: 1, Competition: Football, Year: 2025", trophy.ToString());
        }
    }
}