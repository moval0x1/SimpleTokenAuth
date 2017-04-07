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

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password data</param>
        /// <returns>success flag</returns>
        public AuthAccount Insert(string login, string password) {
            //Verify if is null
            if ((string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))) return null;

            //Create new account
            var authAccount = new AuthAccount(login, password);
            //Get one account
            var data = GetAccount(login);

            //Verify if is null
            if (data != null) return null;
            //Adding the account
            _accountList.AuthAccounts.Add(login, authAccount);

            //Return
            return authAccount;
        }

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>success flag</returns>
        public bool Delete(string login) {
            //Verify if is null
            if (string.IsNullOrEmpty(login)) return false;

            //Get one account
            var data = GetAccount(login);

            //Verify if is null
            return data != null && _accountList.AuthAccounts.Remove(login);
        }

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>success flag</returns>
        public AuthAccount UpdatePassword(string login, string oldPassword, string newPassword) {
            //Verify if is null
            if ((string.IsNullOrEmpty(login) || string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))) return null;

            //Get one account
            var account = GetAccount(login);

            //Verify if is null
            if (account == null) return null;

            //Verify if the password is valid
            if(!PasswordValidate(login, oldPassword)) return null;

            //Verifica se a senha é igual
            if(string.Compare(account.Password, oldPassword, StringComparison.Ordinal) != 0) return null;

            //Create new account
            var authAccount = new AuthAccount(login, newPassword);
            //Adding the account
            _accountList.AuthAccounts[login] = authAccount;

            //Return
            return authAccount;
        }
    }
}