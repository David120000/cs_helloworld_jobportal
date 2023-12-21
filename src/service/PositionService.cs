using System.Security;
using Bredex1.src.model;
using Bredex1.src.repository;
using Microsoft.AspNetCore.Authorization;

namespace Bredex1.src.service
{
    public class PositionService
    {
        private readonly EFInMemoryDBAccess DBAccess;
        private readonly AuthorizationService AuthService;

        public PositionService(EFInMemoryDBAccess dBAccess, AuthorizationService authService) 
        {
            DBAccess = dBAccess;
            AuthService = authService;
        }


        public PositionPersistResponse PersistNewPosition(string apiKey, Position position)
        {
            if(apiKey == null || (apiKey != null && AuthService.Authorize(apiKey) == false)) {

                throw new VerificationException("The provided API key (" + apiKey + ") is invalid or expired.");
            }

            PositionDBData positionToDB = new(position.Title, position.Location);
            DBAccess.AvailablePositions.Add(positionToDB);
            DBAccess.SaveChanges();
        

            PositionPersistResponse response = new(positionToDB.Id, positionToDB);

            return response;
        }

    }
}