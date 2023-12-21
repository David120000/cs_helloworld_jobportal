using System.Text.RegularExpressions;

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
    }
}