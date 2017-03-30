namespace SimpleTokenAuth.Domain.Entities {

    /// <summary>
    /// Authentication user account
    /// </summary>
    public class AuthAccount {

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