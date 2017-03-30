using SimpleTokenAuth.Domain.Entities;
using System;

namespace SimpleTokenAuth.Library {

    /// <summary>
    /// Library for token generation
    /// </summary>
    internal class SimpleTokenLibrary {

        /// <summary>
        /// Expiration time in minutes
        /// </summary>
        private readonly int _expirationInMinutes;

        /// <summary>
        /// Contrsuctor method
        /// </summary>
        /// <param name="expirationInMinutes">expiration time in minutes</param>
        public SimpleTokenLibrary(int expirationInMinutes) {
            //Set expiration time
            _expirationInMinutes = expirationInMinutes;
        }

        /// <summary>
        /// Generate new token
        /// </summary>
        /// <returns></returns>
        public TokenData NewToken() {
            //New token entitiy
            var tokenDate = new TokenData() {
                //Create token key
                Token = Guid.NewGuid().ToString(),
                //Set expiration date
                ExpirationDate = DateTime.UtcNow.AddMinutes(_expirationInMinutes)
            };

            //Return
            return tokenDate;
        }

        /// <summary>
        /// Token validation library
        /// </summary>
        /// <param name="tokenData">token data</param>
        /// <param name="error">error message</param>
        /// <returns>|flag for validation success</returns>
        public bool Validation(TokenData tokenData, out string error) {
            //Initialize
            error = null;

            //Verify if token data is null
            if (tokenData == null) {
                //Set error
                error = "Token data is null";

                //Return
                return false;
            }

            //Verify if token is valid
            if (tokenData.ExpirationDate <= DateTime.UtcNow) return true;

            //Set error
            error = "Token expired";

            //Return
            return false;
        }
    }
}