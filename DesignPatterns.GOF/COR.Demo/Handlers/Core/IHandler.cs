namespace COR.Demo.Handlers.Core
{
    public interface IHandler<T> where T:class
    {
        IHandler<T> Next(IHandler<T> request);
        void Handle(T request);
    }
}
