using System.ComponentModel.DataAnnotations;

namespace Bredex1.src.model
{
    public class ApiKeyCached
    {
        public ApiKeyCached()
        {
            // ApiKey = Guid.NewGuid().ToString();
            // Created = DateTime.UtcNow;
        }

        public ApiKeyCached(string apiKey)
        {
            ApiKey = apiKey;
            Created = DateTime.UtcNow;
        }

        [Key]
        public string ApiKey {get; set;}
        public DateTime Created {get; set;}


        public override string ToString()
        {
            return "[ApiKey=" + ApiKey + ", Created=" + Created + "]";
        }
    }
}