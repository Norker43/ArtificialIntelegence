using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Lab_4;
using Lab_4.Models;

namespace UnitTests
{
    [TestClass]
    public class TestSimpson
    {
        [TestMethod]
        public void TestSimpsonMethod()
        {
            int alternatinves = 3;
            Simpson simpson = new Simpson();
            List<Expert> experts = new List<Expert>();
            Expert expert1 = new Expert("Эксперт 1", alternatinves);
            Expert expert2 = new Expert("Эксперт 2", alternatinves);
            Expert expert3 = new Expert("Эксперт 3", alternatinves);
            Expert expert4 = new Expert("Эксперт 4", alternatinves);
            Expert expert5 = new Expert("Эксперт 5", alternatinves);
            Expert expert6 = new Expert("Эксперт 6", alternatinves);
            expert1.Preferences = new int[] { 1, 2, 3 };
            expert2.Preferences = new int[] { 2, 3, 1 };
            expert3.Preferences = new int[] { 3, 2, 1 };
            expert4.Preferences = new int[] { 1, 2, 3 };
            expert5.Preferences = new int[] { 1, 3, 2 };
            expert6.Preferences = new int[] { 1, 2, 3 };
            experts.AddRange(new Expert[] { expert1, expert2, expert3, expert4, expert5, expert6 });
            simpson.Experts = experts;

            Assert.AreEqual("Альтернатива 1", simpson.Execute());
        }
    }
}