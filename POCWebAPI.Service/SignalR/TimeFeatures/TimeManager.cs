using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POCWebAPI.Service.TimeFeatures
{
    public class TimeManager
    {
        private Timer? _timer;
        private AutoResetEvent? _autoResetEvent;
        private Action? _action;

        public DateTime TimeStarted { get; set; }
        public bool IsTimerStarted { get; set; }

        public void PrepareTimer(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 100, 2000);
            TimeStarted = DateTime.Now;
            IsTimerStarted = true;
        }

        public void Execute(object? stateInfo)
        {
            _action();
            if((DateTime.Now - TimeStarted).Seconds > 60)
            {
                IsTimerStarted=false;
                _timer.Dispose();
            }
        }
    }
}
