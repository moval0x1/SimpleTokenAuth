using SimpleTokenAuth.Domain.Contracts;
using SimpleTokenAuth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTokenAuth.Repository {

    /// <summary>
    /// Use data repository
    /// </summary>
    internal class AccountRepository {

        /// <summary>
        /// Account user list
        /// </summary>
        private readonly IAccountList _accountList;

        /// <summary>
        /// constructor method
        /// </summary>
        /// <param name="accountList">user list data</param>
        public AccountRepository(IAccountList accountList) {
            //Set account list
            _accountList = accountList;
        }

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>user token data</returns>
        public AuthAccount GetAccount(string login) {
            //Find for user
            return _accountList.AuthAccounts.ContainsKey(login) ? _accountList.AuthAccounts[login] : null;
        }

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="token">token data</param>
        /// <returns>user token data</returns>
        public AuthAccount GetAccount(string login, string token) {
            //Find for user
            var account = _accountList.AuthAccounts.ContainsKey(login) ? _accountList.AuthAccounts[login] : null;

            //Verifica se o token é válido
            return (string.CompareOrdinal(account?.TokenData?.Token, token) == 0) ? account : null;
        }

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password</param>
        /// <returns>user token data</returns>
        public bool PasswordValidate(string login, string password) {
            //Find for user
            var account = _accountList.AuthAccounts.ContainsKey(login) ? _accountList.AuthAccounts[login] : null;

            //Verifica se o token é válido
            return (string.CompareOrdinal(account?.Password, password) == 0);
        }

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns>user token data list</returns>
        public IEnumerable<AuthAccount> GetAllAccounts() {
            //Find for user
            return _accountList.AuthAccounts.Select(s => s.Value);
        }

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns>user token data list</returns>
        public IEnumerable<AuthAccount> GetAllAccountsWithValidToken(Func<TokenData, bool> validation) {
            //Find for user
            var accounts = _accountList.AuthAccounts.Where(w => validation(w.Value.TokenData)).Select(s => s.Value);

            //Retorno
            return accounts;
        }
    }
}