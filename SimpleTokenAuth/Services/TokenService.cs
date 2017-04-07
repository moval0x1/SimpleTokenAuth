using SimpleTokenAuth.Domain.Contracts;
using SimpleTokenAuth.Domain.Entities;
using SimpleTokenAuth.Repository;
using System.Collections.Generic;

namespace SimpleTokenAuth.Services {

    /// <summary>
    /// Token service interface
    /// </summary>
    public class TokenService : ITokenService {

        /// <summary>
        /// Account repositpry
        /// </summary>
        private readonly AccountRepository _accountRepository;

        /// <summary>
        /// Token library
        /// </summary>
        private readonly ITokenLibrary _tokenLibrary;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="tokenLibrary">biblioteca de token</param>
        /// <param name="accountList">lista de contas</param>
        public TokenService(ITokenLibrary tokenLibrary, IAccountList accountList) {
            //Define repository
            _accountRepository = new AccountRepository(accountList);
            //Define library
            _tokenLibrary = tokenLibrary;
        }

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>user token data</returns>
        public AuthAccount GetAccount(string login) {
            //Get account
            return _accountRepository.GetAccount(login);
        }

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="token">token data</param>
        /// <returns>user token data</returns>
        public AuthAccount GetAccount(string login, string token) {
            //Get account
            return _accountRepository.GetAccount(login, token);
        }

        /// <summary>
        /// Get user token data
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password</param>
        /// <returns>user token data</returns>
        public bool PasswordValidate(string login, string password) {
            //Validate repository
            return _accountRepository.PasswordValidate(login, password);
        }

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns>user token data list</returns>
        public IEnumerable<AuthAccount> GetAllAccounts() {
            //Get all accounts
            return _accountRepository.GetAllAccounts();
        }

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns>user token data list</returns>
        public IEnumerable<AuthAccount> GetAllAccountsWithValidToken() {
            //Get all accounts
            return _accountRepository.GetAllAccountsWithValidToken(_tokenLibrary.Validation);
        }

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password data</param>
        /// <returns>AuthAccount</returns>
        public AuthAccount Insert(string login, string password) {
            //Insere um novo usuário
            return _accountRepository.Insert(login, password);
        }

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>success flag</returns>
        public bool Delete(string login) {
            //Remove um login
            return _accountRepository.Delete(login);
        }

        /// <summary>
        /// Insere uma nova conta
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>account</returns>
        public AuthAccount UpdatePassword(string login, string oldPassword, string newPassword) {
            //Atualiza senha
            return _accountRepository.UpdatePassword(login, oldPassword, newPassword);
        }
    }
}