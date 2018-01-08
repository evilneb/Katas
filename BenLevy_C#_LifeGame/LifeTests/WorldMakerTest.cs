using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeGame;
using System.Collections.Generic;

namespace LifeTests
{
    [TestClass]
    public class WorldMakerTest
    {
        [TestMethod]
        public void MakeCrittersTest()
        {
            WorldMaker testBang = new WorldMaker();

            List<char[]> testList = new List<char[]>()
            {
                { new char[] {'4',' ','y','9'} },
                { new char[] { } },
                { new char[] {'h','[',' '} },
                { new char[] {' ',' ',' '} }
            };

            Organism[,] actual = testBang.MakeCritters(testList);
            
            Assert.AreEqual('4', actual[1,1].Body);
            Assert.AreEqual(null, actual[0, 0]);
            Assert.AreEqual(null, actual[5, 5]);
            Assert.AreEqual(null, actual[0, 5]);
            Assert.AreEqual(null, actual[5, 0]);
            Assert.AreEqual(null, actual[0, 3]);
            Assert.AreEqual(null, actual[2, 0]);
            Assert.AreEqual('[', actual[3, 2].Body);
            Assert.AreEqual(' ', actual[2, 3].Body);
            Assert.AreEqual(' ', actual[2, 1].Body);
            Assert.AreEqual(' ', actual[3, 4].Body);
            Assert.AreEqual(' ', actual[4, 2].Body);
        }

        [TestMethod]
        public void CountNeighborsTest()
        {
            WorldMaker testBang = new WorldMaker();

            Organism[,] result = new Organism[6, 6]
            {
                { null, null, null, null, null, null },
                { null, new Organism() { Body = '4' }, new Organism() { Body = ' ' }, new Organism() { Body = 'y' }, new Organism() { Body = '9' }, null },
                { null, new Organism() { Body = 'r' }, new Organism() { Body = 't' }, new Organism() { Body = ' ' }, new Organism() { Body = 'h' }, null },
                { null, new Organism() { Body = 'h' }, new Organism() { Body = '[' }, new Organism() { Body = ' ' }, new Organism() { Body = ' ' }, null },
                { null, new Organism() { Body = ' ' }, new Organism() { Body = ' ' }, new Organism() { Body = ' ' }, new Organism() { Body = 'h' }, null },
                { null, null, null, null,null, null }
            };

            testBang.CountNeighbors(result);

            Assert.AreEqual(2, result[1, 1].NeighborCount);
            Assert.AreEqual(0, result[4, 4].NeighborCount);
            Assert.AreEqual(4, result[2, 1].NeighborCount);
            Assert.AreEqual(5, result[2, 3].NeighborCount);
        }
    }
}
