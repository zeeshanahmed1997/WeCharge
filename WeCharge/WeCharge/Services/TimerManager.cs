using System;
using System.Threading;
using System.Threading.Tasks;

namespace WeCharge.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class TimerManager
    {
        private readonly TimeSpan _targetTime;
        private CancellationTokenSource _cancellationTokenSource;

        public event EventHandler<TimeSpan> TimerTick;

        public TimerManager(TimeSpan targetTime)
        {
            _targetTime = targetTime;
        }

        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => RunTimerAsync(_cancellationTokenSource.Token));
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async Task RunTimerAsync(CancellationToken cancellationToken)
        {
            var startTime = DateTime.Now;

            while (!cancellationToken.IsCancellationRequested && DateTime.Now < startTime + _targetTime)
            {
                var remainingTime = startTime + _targetTime - DateTime.Now;
                TimerTick?.Invoke(this, remainingTime);
                await Task.Delay(1000);
            }
        }
    }

}
