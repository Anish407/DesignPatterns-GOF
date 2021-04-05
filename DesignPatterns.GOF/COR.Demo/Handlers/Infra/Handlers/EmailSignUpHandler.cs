namespace COR.Demo.Handlers.Infra.Handlers
{
    public class EmailSignUpHandler : Handler<User>
    {
        public override void Handle(User request)
        {
            // if email exists in database then throw error

            // SignUp user

            base.Handle(request);
        }

    }
}
