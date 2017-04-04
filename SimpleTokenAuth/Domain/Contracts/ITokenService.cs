using SimpleTokenAuth.Domain.Entities;
using System.Collections.Generic;

namespace SimpleTokenAuth.Domain.Contracts {

    /// <summary>
    /// Token service interface
    /// </summary>
    public interface ITokenService {

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>user token data</returns>
        AuthAccount GetAccount(string login);

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="token">token data</param>
        /// <returns>user token data</returns>
        AuthAccount GetAccount(string login, string token);

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password</param>
        /// <returns>user token data</returns>
        bool PasswordValidate(string login, string password);

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns>user token data list</returns>
        IEnumerable<AuthAccount> GetAllAccounts();

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns>user token data list</returns>
        IEnumerable<AuthAccount> GetAllAccountsWithValidToken();
    }
}