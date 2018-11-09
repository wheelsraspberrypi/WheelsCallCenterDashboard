using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelsCallCenterDashboard.Services.Abstract
{
    public interface ITaskDispatcher
    {
        void DispatchOnBackground(Action action);
        void DispatchOnUI(Action action);
    }
}
