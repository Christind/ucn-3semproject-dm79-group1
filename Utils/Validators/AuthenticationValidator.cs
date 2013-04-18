using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Validators
{
    public class AuthenticationValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == "test" && password == "test")
                return;
            throw new SecurityTokenException("Unknown Username or Password");
        }
    }
}
