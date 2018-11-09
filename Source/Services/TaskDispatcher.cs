using System;
using System.Threading.Tasks;
using System.Windows;
using WheelsCallCenterDashboard.Services.Abstract;

namespace WheelsCallCenterDashboard.Services
{
    public class TaskDispatcher : ITaskDispatcher
    {
        public void DispatchOnUI(Action action)
        {
            Application.Current.Dispatcher.BeginInvoke(action, new object[0]);
        }

        public void DispatchOnBackground(Action action)
        {
            Task.Factory.StartNew(action);            
        }
    }
}
