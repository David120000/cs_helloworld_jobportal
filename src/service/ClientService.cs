using Bredex1.controller.model;
using Bredex1.service.utility;
using Bredex1.src.model;
using Bredex1.src.repository;
using Microsoft.EntityFrameworkCore;

namespace Bredex1.service
{
    public class ClientService
    {
        private readonly ClientInputChecker InputChecker;
        private readonly EFInMemoryDBAccess DBAccess;

        public ClientService(ClientInputChecker inputChecker, EFInMemoryDBAccess dBAccess) {
            InputChecker = inputChecker;
            DBAccess = dBAccess;
        }


        public AuthenticationReponse AuthenticateUser(Client client) {

            if(InputChecker.ValidateName(client.Name) == false || InputChecker.ValidateEmail(client.Email) == false) {
                throw new ArgumentException("Username or email invalid.");
            }

            AuthenticationReponse response = new()
            {
                Client = client,
                ApiKey = Guid.NewGuid().ToString()
            };

            // ApiKeyCache.Add(response.ApiKey);
            DBAccess.AuthenticatedClients.Add(new ApiKeyCached(response.ApiKey));
            DBAccess.SaveChanges();

            return response;
        }

        
        // public List<ApiKeyCached> GetAllAuthorizedKeys()
        // {
        //     List<ApiKeyCached> list = DBAccess.AuthenticatedClients.ToList();

        //     Console.WriteLine("Keys cached: " + list.Count);
        //     for(int i = 0; i < list.Count; i++) {
        //         Console.WriteLine(list[i]);
        //     }

        //     return list;
        // }

    }
}