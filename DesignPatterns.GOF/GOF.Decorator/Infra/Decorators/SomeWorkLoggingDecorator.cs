using GOF.Decorator.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GOF.Decorator.Infra.Decorators
{
    public class SomeWorkLoggingDecorator : ISomeWork
    {
        //1.  implement the same interface as the object to be decorated
        //2.  constructor injects the same interface
        public SomeWorkLoggingDecorator(ISomeWork someWork, ILoggerFactory loggerFactory)
        {
            SomeWork = someWork;
            logger = loggerFactory.CreateLogger(nameof(SomeWorkLoggingDecorator));
        }

        public ISomeWork SomeWork { get; }

        private readonly ILogger logger;

        public async Task DoSomeMoreWork() => await CalculateTime(async () => await SomeWork.DoSomeMoreWork());

        public async Task<string> DoSomeWork(int time) => await CalculateTimeWithReturn(async () => await SomeWork.DoSomeWork(time));


        public async Task<T> CalculateTimeWithReturn<T>(Func<Task<T>> operation)
        {
            var clock = new Stopwatch();
            clock.Start();
            T response = await operation();
            clock.Stop();
            logger.LogInformation($"time taken: {clock.ElapsedMilliseconds}");
            return response;
        }

        public async Task CalculateTime(Func<Task> operation)
        {
            var clock = new Stopwatch();
            clock.Start();
            await operation();
            clock.Stop();
            logger.LogInformation($"time taken: {clock.ElapsedMilliseconds}");
        }
    }


}
