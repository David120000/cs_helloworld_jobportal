namespace Bredex1.controller.model
{
    public class AuthenticationReponse(Client client, string apiKey)
    {
        private Client Client { get; } = client;
        private string ApiKey { get; } = apiKey;


        public override string ToString()
        {
            return "[client = " + Client + ", apiKey = " + ApiKey + "]";
        }

    }
}