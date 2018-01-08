using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeGame;
using System.Collections.Generic;

namespace LifeTests
{
    [TestClass]
    public class OrganismTest
    {
        [TestMethod]
        public void ChangeStateTest()
        {
            //checks that an Alive object with 5 Neighbors will become !Alive
            Organism org = new Organism()
            {
                Body = 'm',
                Neighbors = new List<char>()
                {
                    { 'r' },
                    { '[' },
                    { '4' },
                    { '`' },
                    { 'f' }
                }
            };

            Assert.AreEqual(true, org.Alive);
            Assert.AreEqual(5, org.NeighborCount);

            org.ChangeState();

            Assert.AreEqual(false, org.Alive);

            //checks that a !Alive object with 2 Neighbors will remain !Alive
            Organism deadOrg = new Organism()
            {
                Neighbors = new List<char>()
                {
                    { 'w' },
                    { 't' }
                }
            };

            Assert.AreEqual(false, deadOrg.Alive);
            Assert.AreEqual(' ', deadOrg.Body);
            Assert.AreEqual(2, deadOrg.NeighborCount);

            deadOrg.ChangeState();

            Assert.AreEqual(false, deadOrg.Alive);
            Assert.AreEqual(' ', deadOrg.Body);

            //checks that a !Alive object with 3 Neighbors will become Alive
            //and be assigned a body which is not ' ' 
            Organism liveOrg = new Organism()
            {
                Neighbors = new List<char>()
                {
                    { 'p' },
                    { '9' },
                    { '#' }
                }
            };

            Assert.AreEqual(false, liveOrg.Alive);
            Assert.AreEqual(' ', liveOrg.Body);
            Assert.AreEqual(3, liveOrg.NeighborCount);

            liveOrg.ChangeState();

            Assert.AreEqual(true, liveOrg.Alive);
            Assert.AreNotEqual(' ', liveOrg.Body);

            //checks that an Alive object with 1 Neighbor will become !Alive
            Organism orgKill = new Organism()
            {
                Body = 'k',
                Neighbors = new List<char>()
                {
                    { 'x' }
                }
            };

            Assert.AreEqual(true, orgKill.Alive);
            Assert.AreEqual(1, orgKill.NeighborCount);

            orgKill.ChangeState();

            Assert.AreEqual(false, orgKill.Alive);

            //checks that an Alive object with 2 Neighbors will remain Alive
            Organism orgForever = new Organism()
            {
                Body = 'o',
                Neighbors = new List<char>()
                {
                    { '4' },
                    { 'e' }
                }
            };

            Assert.AreEqual(true, orgForever.Alive);
            Assert.AreEqual(2, orgForever.NeighborCount);

            orgForever.ChangeState();

            Assert.AreEqual(true, orgForever.Alive);
        }
    }
}
