using System.Text.RegularExpressions;
using Bredex1.src.model;

namespace Bredex1.service.utility
{
    public class ClientInputChecker
    {
        public bool ValidateName(string userName) {

            bool validName = true;

            if(userName.Length > 100 || userName.Length == 0) {
                validName = false;
            }

            return validName;
        }

        public bool ValidateEmail(string userEmail) {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(userEmail);

            return match.Success;
        }

        public bool ValidatePositionData(Position position) {

            bool validPositionData = true;

            if(position.Location.Length > 50 || position.Location.Length == 0 || position.Title.Length > 50 || position.Title.Length == 0) {
                validPositionData = true;
            }

            return validPositionData;
        }

        public bool ValidateSearchKeyword(string keyword) {

            bool validKeyword = true;

            if(keyword.Length > 50 || keyword.Length == 0) {
                validKeyword = false;
            }

            return validKeyword;
        }
    }
}