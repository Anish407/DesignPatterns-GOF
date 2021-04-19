using System.Threading.Tasks;

namespace GOF.Decorator.Core
{
    public  interface ISomeWork
    {
        Task<string> DoSomeWork(int time);
        Task DoSomeMoreWork();
    }
}
