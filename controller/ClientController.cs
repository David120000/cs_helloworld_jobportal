using Bredex1.controller.model;
using Bredex1.service;
using Microsoft.AspNetCore.Mvc;

namespace Bredex1.controller
{   
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ClientService ClientService;

        public ClientController(ClientService clientService) {
            ClientService = clientService;
        }


        [HttpPost("/client")]
        public IActionResult AuthenticateClient(Client client) {

            AuthenticationReponse response = ClientService.AuthenticateUser(client);
            Console.WriteLine(response);
            
            return Ok(response);
        }


    }
}