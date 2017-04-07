using System;

namespace SimpleTokenAuth.Domain.Entities {

    /// <summary>
    /// Authentication user account
    /// </summary>
    public class AuthAccount {

        /// <summary>
        /// Dados da conta
        /// </summary>
        /// <param name="login">usuário</param>
        /// <param name="password">senha</param>
        public AuthAccount(string login, string password) {
            //User login
            Login = login;
            //User password
            Password = password;
            //Totken data initilization
            TokenData = new TokenData() {
                //Expiration totken data
                ExpirationDate = DateTime.UtcNow,
                //Set token to null
                Token = null
            };
        }

        /// <summary>
        /// Login name
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User token data
        /// </summary>
        public TokenData TokenData { get; set; }
    }
}