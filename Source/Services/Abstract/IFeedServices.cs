using System.Collections.Generic;
using System.Threading.Tasks;
using WheelsCallCenterDashboard.Models;

namespace WheelsCallCenterDashboard.Services.Abstract
{
    public interface IFeedServices
    {
        Task<List<FeedData>> GetFeedDataAsync();
    }
}
