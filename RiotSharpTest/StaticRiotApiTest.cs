﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class StaticRiotApiTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static StaticRiotApi api = StaticRiotApi.GetInstance(apiKey);

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampion_Test()
        {
            var champ = api.GetChampion(Region.euw, 1, ChampionData.none);

            Assert.AreEqual(champ.Name, "Annie");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champ = api.GetChampionAsync(Region.euw, 1, ChampionData.none);

            Assert.AreEqual(champ.Result.Name, "Annie");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampions_Test()
        {
            var champs = api.GetChampions(Region.euw, ChampionData.none);

            Assert.IsNotNull(champs.Champions);
            Assert.IsTrue(champs.Champions.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champs = api.GetChampionsAsync(Region.euw, ChampionData.none);

            Assert.IsNotNull(champs.Result.Champions);
            Assert.IsTrue(champs.Result.Champions.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItem_Test()
        {
            var item = api.GetItem(Region.euw, 1001, ItemData.none);

            Assert.AreEqual(item.Name, "Boots of Speed");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemAsync_Test()
        {
            var item = api.GetItemAsync(Region.euw, 1001, ItemData.none);

            Assert.AreEqual(item.Result.Name, "Boots of Speed");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItems_Test()
        {
            var items = api.GetItems(Region.euw, ItemData.none);

            Assert.IsNotNull(items.Items);
            Assert.IsTrue(items.Items.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemsAsync_Test()
        {
            var items = api.GetItemsAsync(Region.euw, ItemData.none);

            Assert.IsNotNull(items.Result.Items);
            Assert.IsTrue(items.Result.Items.Count > 0);
        }
    }
}
