using System;

namespace COR.Demo.Handlers.Infra.Handlers
{
    public class CountryHandler : Handler<User>
    {
        public override void Handle(User request)
        {
            if (request.Country.Equals("ind")) Console.WriteLine("Hello....");

            base.Handle(request);
        }
    }
}
