﻿using Newtonsoft.Json;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.StatusEndpoint;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Misc;

namespace RiotSharp
{
    public class StatusRiotApi : IStatusRiotApi
    {
        #region Private Fields
        
        private const string StatusRootUrl = "/shards";

        private const string RegionUrl = "/{0}";

        private const string RootDomain = "status.leagueoflegends.com";

        private IRequester requester;

        private static StatusRiotApi instance;

        #endregion

        /// <summary>
        /// Get the instance of StatusRiotApi.
        /// </summary>
        /// <returns>The instance of StatusRiotApi.</returns>
        public static StatusRiotApi GetInstance()
        {
            return instance ?? (instance = new StatusRiotApi());
        }

        private StatusRiotApi()
        {
            Requesters.StatusApiRequester = new Requester();
            requester = Requesters.StatusApiRequester;
        }
       
        public List<Shard> GetShards()
        {
            var json = requester.CreateGetRequest(StatusRootUrl, RootDomain, null, false);
            return JsonConvert.DeserializeObject<List<Shard>>(json);
        }
      
        public async Task<List<Shard>> GetShardsAsync()
        {
            var json = await requester.CreateGetRequestAsync(StatusRootUrl, RootDomain, null, false);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Shard>>(json));
        }
      
        public ShardStatus GetShardStatus(Region region)
        {
            var json = requester.CreateGetRequest(StatusRootUrl + string.Format(RegionUrl, region.ToString()),
                RootDomain, null, false);
            return JsonConvert.DeserializeObject<ShardStatus>(json);
        }

        public async Task<ShardStatus> GetShardStatusAsync(Region region)
        {
            var json = await requester.CreateGetRequestAsync(StatusRootUrl + string.Format(RegionUrl, region.ToString()),
                RootDomain, null, false);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ShardStatus>(json));
        }
    }
}
