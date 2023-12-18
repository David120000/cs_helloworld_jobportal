using Bredex1.controller.model;
using Bredex1.service.utility;

namespace Bredex1.service
{
    public class ClientService
    {
        private readonly ClientInputChecker InputChecker;

        public ClientService(ClientInputChecker inputChecker) {
            InputChecker = inputChecker;
        }


        public AuthenticationReponse AuthenticateUser(Client client) {

            if(InputChecker.ValidateName(client.Name) == false || InputChecker.ValidateEmail(client.Email) == false) {
                throw new ArgumentException("Username or email invalid.");
            }

            return new(client, Guid.NewGuid().ToString());
        }

    }
}