using SimpleTokenAuth.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SimpleTokenAuth.Domain.Contracts {

    /// <summary>
    /// Repositório de accounts
    /// </summary>
    public interface IAccountRepository {
        
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
        IEnumerable<AuthAccount> GetAllAccountsWithValidToken(Func<TokenData, bool> validation);

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password data</param>
        /// <returns>success flag</returns>
        AuthAccount Insert(string login, string password);

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>success flag</returns>
        bool Delete(string login);

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>success flag</returns>
        AuthAccount UpdatePassword(string login, string oldPassword, string newPassword);
         
    }
}
