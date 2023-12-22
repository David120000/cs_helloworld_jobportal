using System.Security;
using Bredex1.service.utility;
using Bredex1.src.model;
using Bredex1.src.repository;
using Microsoft.AspNetCore.Authorization;

namespace Bredex1.src.service
{
    public class PositionService
    {
        private readonly ClientInputChecker InputChecker;
        private readonly EFInMemoryDBAccess DBAccess;
        private readonly AuthorizationService AuthService;

        public PositionService(ClientInputChecker inputChecker, EFInMemoryDBAccess dBAccess, AuthorizationService authService) 
        {
            InputChecker = inputChecker;
            DBAccess = dBAccess;
            AuthService = authService;
        }


        public PositionPersistResponse PersistNewPosition(string apiKey, Position position)
        {
            CheckApiKeyValidity(apiKey);
            CheckPositionInputData(position);

            PositionDBData positionToDB = new(position.Title, position.Location);
            DBAccess.AvailablePositions.Add(positionToDB);
            DBAccess.SaveChanges();
        

            PositionPersistResponse response = new(positionToDB.Id, positionToDB);

            return response;
        }


        public PositionURLs SearchPositionsByKeyword(string apiKey, string keyword) {

            CheckApiKeyValidity(apiKey);
            CheckSearchKeywordValidity(keyword);
            Console.WriteLine("keyword: " + keyword);
            List<PositionDBData> positions = DBAccess.AvailablePositions
                                                            .Where(position => position.Title.Contains(keyword))
                                                            .ToList();
            
            List<string> urls = [];
            string baseURL = "http://localhost:5259/position/";

            for(int i = 0; i < positions.Count; i++) {
                Console.WriteLine("New URL generated: " + baseURL + positions[i].Id);
                urls.Add(baseURL + positions[i].Id);
            }

            PositionURLs positionUrls = new();
            {
                positionUrls.SearchKeyword = keyword;
                positionUrls.PositionURL_List = urls;
            }

            return positionUrls;
        }


        public PositionDBData GetPositionById(string apiKey, string id) {

            CheckApiKeyValidity(apiKey);

            PositionDBData position = DBAccess.AvailablePositions.Find(Guid.Parse(id));

            return position;                          
        }


        private void CheckApiKeyValidity(string apiKey)
        {
            if(apiKey == null || (apiKey != null && AuthService.Authorize(apiKey) == false)) {

                throw new VerificationException("The provided API key (" + apiKey + ") is invalid or expired.");
            }
        }


        private void CheckPositionInputData(Position position)
        {
            if(InputChecker.ValidatePositionData(position) == false) {

                throw new ArgumentException("The provided position data is invalid. The title and location data should be between 1 and 50 characters.");
            }
        }


        private void CheckSearchKeywordValidity(string keyword)
        {
            if(InputChecker.ValidateSearchKeyword(keyword) == false) {

                throw new ArgumentException("The provided search keyword is invalid. The keyword should be between 1 and 50 characters.");
            }
        }
    }
}