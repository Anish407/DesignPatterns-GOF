using COR.Demo.Handlers.Core;

namespace COR.Demo.Handlers.Infra
{
    public abstract class Handler<T> : IHandler<T> where T : class
    {

        private IHandler<T> NextHandler { get; set; }
        public virtual void Handle(T request)
        {
            NextHandler?.Handle(request);
        }

        public IHandler<T> Next(IHandler<T> nextHandler)
        {
            NextHandler = nextHandler;
            return NextHandler;
        }
    }
}
