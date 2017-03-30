using System;

namespace SimpleTokenAuth.Domain.Entities {

    /// <summary>
    /// Token data information
    /// </summary>
    public class TokenData {

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Expiration token date
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}