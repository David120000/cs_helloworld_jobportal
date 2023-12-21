using Bredex1.src.model;
using Bredex1.src.repository;

namespace Bredex1.src.service
{
    public class AuthorizationService
    {
        private readonly EFInMemoryDBAccess DBAccess;

        public AuthorizationService(EFInMemoryDBAccess dBAccess)
        {
            DBAccess = dBAccess;
        }

        public bool Authorize(string apiKey)
        {
            bool keyIsValid = false;

            ApiKeyCached? keyObject = DBAccess.AuthenticatedClients.Find(apiKey);

            if(keyObject != null && keyObject.Created.AddDays(1) > DateTime.UtcNow) {
                keyIsValid = true;
            }

            return keyIsValid;
        }
    }
}