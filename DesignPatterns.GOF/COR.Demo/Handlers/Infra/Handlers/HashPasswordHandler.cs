using System.Security.Cryptography;
using System.Text;

namespace COR.Demo.Handlers.Infra.Handlers
{
    public class HashPasswordHandler : Handler<User>
    {

        public override void Handle(User request)
        {
            //if password is empty. throw an error

            request.HashedPassword = Encoding.UTF8.GetString(MD5.HashData(Encoding.UTF8.GetBytes(request.Password)));


            base.Handle(request);
        }
    }
}
