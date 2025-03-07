using Microsoft.VisualStudio.TestTools.UnitTesting;
using obl_opg_1_2_PROG_TEK_Lasse;
using obl_opg_1_PROG_TEK_Lasse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obl_opg_1_2_PROG_TEK_Lasse.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {

        private TrophiesRepository repository;
        private Trophy trophy; // maybe delete?
        private Trophy trophy2;
        [TestInitialize()]
        public void TrophyRepoInitialize()
        {
            /*Trophy*/
            trophy = new Trophy
            {
                Id = 0,
                Competition = "Football",
                Year = 2010
            };
            trophy2 = new Trophy
            {
                Id = 1,
                Competition = "Golf",
                Year = 2011
            };
            repository = new TrophiesRepository();
            repository.Add(trophy);
            repository.Add(trophy2);
        }

        [TestMethod()]
        public void GetTrophiesTest()
        {
            List<Trophy> trophies = repository.GetTrophies();
            Assert.AreEqual(2, trophies.Count);
        }

        [TestMethod()]
        public void GetTrophiesYearTest()
        {
            repository.Add(trophy2);

            var getTrophy = repository.GetTrophies(2011);

            Assert.IsTrue(getTrophy.Contains(trophy2));

            Assert.IsFalse(getTrophy.Contains(trophy));
        }

        [TestMethod()]
        public void GetTrophiesSortedByYearTest()
        {
            var yearSortedTrophiesAsc = repository.GetTrophiesSortedByYear();
            var yearSortedTrophiesDesc = repository.GetTrophiesSortedByYear(false);

            Assert.AreEqual(trophy.Year, yearSortedTrophiesAsc.ElementAt(0).Year);

            Assert.AreEqual(trophy2.Year, yearSortedTrophiesDesc.ElementAt(0).Year);
        }

        [TestMethod()]
        public void GetTrophiesSortedByCompTest()
        {
            var compSortedTrophiesAsc = repository.GetTrophiesSortedByComp();
            var compSortedTrophiesDesc = repository.GetTrophiesSortedByComp(false);

            Assert.AreEqual(trophy.Competition, compSortedTrophiesAsc.ElementAt(0).Competition);

            Assert.AreEqual(trophy2.Competition, compSortedTrophiesDesc.ElementAt(0).Competition);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var trophy1 = repository.GetById(0);
            var trophyNull = repository.GetById(10);

            Assert.AreEqual(trophy, trophy1);
            Assert.IsNull(trophyNull);
        }

        [TestMethod()]
        public void AddTest()
        {
            Trophy trophy3 = new Trophy
            {
                Id = 2,
                Competition = "Pool",
                Year = 2013
            };
            repository.Add(trophy3);
            var repo = repository.GetTrophies();

            Assert.AreEqual(3, repo.Count);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            // trophy 1 & 2 in repo
            var repo = repository.GetTrophies();
            Assert.AreEqual(2, repo.Count);

            //removed trpohy 1
            repository.Remove(0);
            var repo2 = repository.GetTrophies();
            Assert.AreEqual(1, repo2.Count);

            // removed nothing
            var noTrophy = repository.Remove(10);

            Assert.IsNull(noTrophy);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Trophy updateTrophy = new Trophy
            {
                Id = 10,
                Competition = "Ice hockey",
                Year = 2024
            };
            repository.Update(0, updateTrophy);

            Assert.AreEqual(trophy.Id, updateTrophy.Id);
            Assert.AreEqual(trophy.Competition, updateTrophy.Competition);
            Assert.AreEqual(trophy.Year, updateTrophy.Year);

        }

        [TestMethod()]
        public void UpdateNullTest()
        {
            Trophy updateTrophy = new Trophy
            {
                Id = 10,
                Competition = "Ice hockey",
                Year = 2024
            };

            var nullUpdate = repository.Update(100, updateTrophy);

            Assert.IsTrue(nullUpdate == null);
        }
    }
}