namespace COR.Demo.Handlers.Infra
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
        public override string ToString()
        {
            return $"id: {Id}, Email:{Email}, Age:{Age}, Country:{Country}, Password:{Password}, Hashed: {HashedPassword}";
        }

    }
}