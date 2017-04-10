using SimpleTokenAuth.Domain.Entities;
using SimpleTokenAuth.Library;
using SimpleTokenAuth.Repository;
using SimpleTokenAuth.Services;
using System;
using System.Linq;
using SimpleTokenAuth.Repository.InMemory;
using Xunit;

namespace SimpleTokenAuth.Tests.UnitTests {

    /// <summary>
    /// Token service Tests
    /// </summary>
    public class TokenServiceTests {

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]                      
        public void GetAccountSucess() {
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);
            
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

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);

            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);

            //Get one account
            var account = tokenService.GetAccount(login);

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
        public void GetAccountFail() {
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

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

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);

            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);

            //Get one account
            var account = tokenService.GetAccount("sss");

            //verify if is null
            Assert.Null(account);
        }

        /// <summary>
        /// Get all accounts with success
        /// </summary>
        [Fact]
        public void GetAccountWithLoginAndTokenSucess() {
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);
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

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);

            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);

            //Get one account
            var account = tokenService.GetAccount(login, tokenData.Token);

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
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

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

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);

            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);

            //Get one account
            var result = tokenService.PasswordValidate(login, password);

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
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

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

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);
            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);
            //Get one account
            var result = tokenService.GetAllAccounts();

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
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

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

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);
            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);

            //Get one account
            var result = tokenService.GetAllAccountsWithValidToken();

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
        /// Insert user account
        /// </summary>
        [Fact]
        public void InsertAccount() {
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

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

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);
            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);
            //Total before insertion
            var totalBeforeInsert = tokenService.GetAllAccounts().Count();
            //Inserted user account
            var authAccount = tokenService.Insert(login, password);
            //Total after insertion
            var totalAfteInsert = tokenService.GetAllAccounts().Count();

            //Verify if is null
            Assert.NotNull(authAccount);
            //Verify if are equals
            Assert.Equal(totalBeforeInsert, totalAfteInsert - 1);
        }

        /// <summary>
        /// Insert user account
        /// </summary>
        [Fact]
        public void DeleteAccount() {
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

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
                    {login, new AuthAccount(login, password) { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                    {"ijl", new AuthAccount("ijl", "000") { TokenData = new TokenData{ExpirationDate = DateTime.UtcNow.AddMinutes(30), Token = Guid.NewGuid().ToString()}}},
                }
            };

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);
            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);
            //Total before insertion
            var totalBeforeDelete = tokenService.GetAllAccounts().Count();
            //Inserted user account
            var authAccount = tokenService.Delete(login);
            //Total after insertion
            var totalAfterDelete = tokenService.GetAllAccounts().Count();

            //Verify if is null
            Assert.NotNull(authAccount);
            //Verify if are equals
            Assert.Equal(totalBeforeDelete - 1, totalAfterDelete);
        }

        /// <summary>
        /// Insert user account
        /// </summary>
        [Fact]
        public void UpdatePasswordAccount() {
            //Carrega biblioteca de manipulação de token
            var simpleTokenLibrary = new SimpleTokenLibrary(30);

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

            //Repositório
            var inMemoryAccountRepository = new InMemoryAccountRepository(accountList);
            //Create token service
            var tokenService = new TokenService(simpleTokenLibrary, inMemoryAccountRepository);
            //Total before insertion
            var newAuthAccount = tokenService.UpdatePassword(login, oldPassword, newPassword);
            
            //Verify if is null
            Assert.NotNull(newAuthAccount);
            //Verify if are equals
            Assert.Equal(newAuthAccount.Password, newPassword);
        }
    }
}