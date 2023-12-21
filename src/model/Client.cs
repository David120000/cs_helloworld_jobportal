namespace Bredex1.controller.model
{
    public class Client
    {
        public string? Name { get; set; }
        public string? Email { get; set; }


        public override string ToString()
        {
            return "[Name = " + Name + ", Email = " + Email + "]";
        }
    }
}