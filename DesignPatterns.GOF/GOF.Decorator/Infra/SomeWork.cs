using GOF.Decorator.Core;
using System;
using System.Threading.Tasks;

namespace GOF.Decorator.Infra
{
    public class SomeWork : ISomeWork
    {
        public async Task DoSomeMoreWork()
        {
            await Task.Delay(3000);
        }

        public async Task<string> DoSomeWork(int time)
        {
            await Task.Delay(time);
            return await new ValueTask<string>("Completed");
        }
    }
}
