using System;
using WheelsCallCenterDashboard.Services.Abstract;

namespace WheelsCallCenterDashboard.ViewModels.Abstract
{
    public class RootViewModel<T> : BaseViewModel<T>
    {
        protected readonly ITaskDispatcher dispatcher;
        protected void DispatchOnUI(Action action)
        {
            dispatcher.DispatchOnUI(action);
        }

        protected void DispatchOnBackground(Action action)
        {
            dispatcher.DispatchOnBackground(action);
        }

        public RootViewModel(ITaskDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
    }
}
