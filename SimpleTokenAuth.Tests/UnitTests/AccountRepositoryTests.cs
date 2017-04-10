using SimpleTokenAuth.Domain.Entities;
using SimpleTokenAuth.Library;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;
using SimpleTokenAuth.Repository;
using SimpleTokenAuth.Repository.InMemory;

namespace SimpleTokenAuth.Tests.UnitTests {

    /// <summary>
    /// Summary description for AccountRepositoryTests
    /// </summary>
    public class AccountRepositoryTests {

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount(login, password) { TokenData = tokenData}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);
            //Get one account
            var account = accountRepository.GetAccount(login);

            //Verifiy if is null
            Assert.NotNull(account);
            //Verifiy if is null
            Assert.NotNull(account.TokenData);
            //Verifiy if is empty
            Assert.False(string.IsNullOrWhiteSpace(account.Login));
            //Verifiy if is empty
            Assert.False(string.IsNullOrWhiteSpace(account.Password));
            //Verifiy if are equal
            Assert.Equal(account.Login, login);
            //Verifiy if are equal
            Assert.Equal(account.Password, password);
            //Verifiy if are equal
            Assert.Equal(account.TokenData.Token, tokenData.Token);
        }

        [Fact]
        public void GetAccountFail() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount(login, password) { TokenData = tokenData}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);
            //Get invalid account
            var account = accountRepository.GetAccount("fff");

            //verify if is null
            Assert.Null(account);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountWithLoginAndTokenSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount(login, password) { TokenData = tokenData}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);
            //Get one account
            var account = accountRepository.GetAccount(login, tokenData.Token);

            //Verifiy if is null
            Assert.NotNull(account);
            //Verifiy if is null
            Assert.NotNull(account.TokenData);
            //Verifiy if is empty
            Assert.False(string.IsNullOrWhiteSpace(account.Login));
            //Verifiy if is empty
            Assert.False(string.IsNullOrWhiteSpace(account.Password));
            //Verifiy if are equal
            Assert.Equal(account.Login, login);
            //Verifiy if are equal
            Assert.Equal(account.Password, password);
            //Verifiy if are equal
            Assert.Equal(account.TokenData.Token, tokenData.Token);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountWithPassowrdValidateSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount(login, password) { TokenData = tokenData}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);
            //Get one account
            var result = accountRepository.PasswordValidate(login, password);

            //Verifiy if is null
            Assert.NotNull(result);
            //Verifiy if is null
            Assert.True(result);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountAllAccountsSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount(login, password) { TokenData = tokenData}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);
            //Get one account
            var result = accountRepository.GetAllAccounts();

            //Verifiy if is null
            Assert.NotNull(result);

            //convert type list to array
            var authAccounts = result as AuthAccount[] ?? result.ToArray();

            //Verifiy if is true
            Assert.True(authAccounts.Any());
            //Verifiy if is true
            Assert.True(authAccounts.Count() == accountList.AuthAccounts.Count);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountAllAccountsWithValidtokenSucess() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            //Totken data
            var tokenData = new TokenData {
                //Expiuration totken date
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                //Token data
                Token = Guid.NewGuid().ToString()
            };

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount(login, password) { TokenData = tokenData}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);
            //Get one account
            var result = accountRepository.GetAllAccountsWithValidToken(simpleTokenLibrary.Validation);

            //Verifiy if is null
            Assert.NotNull(result);

            //convert type list to array
            var authAccounts = result as AuthAccount[] ?? result.ToArray();

            //Verifiy if is true
            Assert.True(authAccounts.Any());
            //Verifiy if is true
            Assert.True(authAccounts.Count() == accountList.AuthAccounts.Count);
        }

        /// <summary>
        /// Insertion test
        /// </summary>
        [Fact]
        public void InsertAccount() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";
            
            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);

            //Total of account before insertion
            var accountsBeforeInsertion = accountRepository.GetAllAccounts().Count();
            
            //Insert account
            var newAccount = accountRepository.Insert(login, password);

            //Total of account after insertion
            var accountsAfterInsertion = accountRepository.GetAllAccounts().Count();

            //Verify if is true
            Assert.NotNull(newAccount);
            //Verify is is null
            Assert.NotNull(accountsBeforeInsertion);
            //Verify is is null
            Assert.NotNull(accountsAfterInsertion);
            //Verify if are equals
            Assert.Equal(accountsAfterInsertion, accountsBeforeInsertion + 1);
        }

        /// <summary>
        /// Insertion test
        /// </summary>
        [Fact]
        public void DeleteAccount() {
            //Login data
            const string login = "abc";
            //Password data
            const string password = "123";

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);

            //Total of account before insertion
            var accountsBeforeInsertion = accountRepository.GetAllAccounts().Count();

            //Insert account
            var newAccount = accountRepository.Insert(login, password);

            //Total of account after insertion
            var accountsAfterInsertion = accountRepository.GetAllAccounts().Count();

            //Insert account
            var newAccount2 = accountRepository.Delete(login);

            //Total of account after insertion
            var accountsAfterDeletion = accountRepository.GetAllAccounts().Count();

            //Verify if is true
            Assert.NotNull(newAccount);
            //Verify if is true
            Assert.NotNull(newAccount2);
            //Verify is is null
            Assert.NotNull(accountsBeforeInsertion);
            //Verify is is null
            Assert.NotNull(accountsAfterInsertion);
            //Verify if are equals
            Assert.Equal(accountsAfterInsertion, accountsBeforeInsertion + 1);
            //Verify if are equals
            Assert.Equal(accountsBeforeInsertion, accountsAfterDeletion);
        }

        /// <summary>
        /// Insertion test
        /// </summary>
        [Fact]
        public void UpdatePasswordAccountSuccess() {
            //Login data
            const string login = "abc";
            //Password data
            const string oldPassword = "123";
            //Password data
            const string newPassword = "456";

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount(login, oldPassword) { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);

            //Atualiza a senha
            var newAuthAccount = accountRepository.UpdatePassword(login, oldPassword, newPassword);

            //Verify is is null
            Assert.NotNull(newAuthAccount);
            //Verify if are equals
            Assert.Equal(login, newAuthAccount.Login);
            //Verify if are equals
            Assert.Equal(newPassword, newAuthAccount.Password);
        }

        /// <summary>
        /// Insertion test
        /// </summary>
        [Fact]
        public void UpdatePasswordAccountFail() {
            //Login data
            const string login = "abc";
            //Password data
            const string oldPassword = "123";
            //Password data
            const string newPassword = "456";
            //Password data
            const string wrongOldPassword = "aaa";

            //Account list
            var accountList = new AccountList {
                //Auth accoint list
                AuthAccounts ={
                    {"def", new AuthAccount("def", "456") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"fgh", new AuthAccount("fgh", "789") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {login, new AuthAccount(login, oldPassword) { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Account repository
            var accountRepository = new InMemoryAccountRepository(accountList);

            //Atualiza a senha
            var newAuthAccount = accountRepository.UpdatePassword(login, wrongOldPassword, newPassword);

            //Verify is is null
            Assert.Null(newAuthAccount);
        }
    }
}