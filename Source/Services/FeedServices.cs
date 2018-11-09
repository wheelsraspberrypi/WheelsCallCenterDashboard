using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WheelsCallCenterDashboard.Models;
using WheelsCallCenterDashboard.Services.Abstract;

namespace WheelsCallCenterDashboard.Services
{
    public class FeedServices : IFeedServices
    {
        public async Task<List<FeedData>> GetFeedDataAsync()
        {
            using (var client = new HttpClient())
            {
                var strData = await client.GetStringAsync("https://wheelspkodicalmlcstorage.blob.core.windows.net/app-updates/feed_data.json");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<FeedData>>(strData);
            }
        }
    }
}
