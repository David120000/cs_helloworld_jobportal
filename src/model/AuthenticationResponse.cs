using System.ComponentModel.DataAnnotations;

namespace Bredex1.controller.model
{
    public class AuthenticationReponse
    {
        public Client? Client { get; set; }
        [Key]
        public string? ApiKey { get; set; }


        public override string ToString()
        {
            return "[client = " + Client + ", apiKey = " + ApiKey + "]";
        }

    }
}