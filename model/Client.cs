namespace Bredex1.controller.model
{
    public class Client(string name, string email)
    {
        public string Name { get; } = name;
        public string Email { get; } = email;


        public override string ToString()
        {
            return "[Name = " + Name + ", Email = " + Email + "]";
        }
    }
}