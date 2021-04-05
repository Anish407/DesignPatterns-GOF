using System;

namespace COR.Demo.Handlers.Infra
{
    public class AgeHandler:Handler<User>
    {
        public override void Handle(User request)
        {
            if (request.Age < 18) throw new Exception("User age should be greater than 18");

            // Go to the database and perform some action

            base.Handle(request);
        }
    }
}
