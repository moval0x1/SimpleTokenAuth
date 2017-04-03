using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTokenAuth.Domain.Contracts;
using SimpleTokenAuth.Domain.Entities;
using SimpleTokenAuth.Repository;

namespace SimpleTokenAuth.Services {

    public class TokenService : ITokenService
    {

        private readonly AccountRepository _accountRepository;

        private readonly ITokenLibrary _tokenLibrary;

        public TokenService(ITokenLibrary tokenLibrary, IAccountList accountList)
        {
            _accountRepository = new AccountRepository(accountList);
            _tokenLibrary = tokenLibrary;
        }

        public AuthAccount GetAccount(string login)
        {
            return _accountRepository.GetAccount(login);
        }

        public AuthAccount GetAccount(string login, string token)
        {
            return _accountRepository.GetAccount(login, token);
        }

        public bool PasswordValidate(string login, string password)
        {
            return _accountRepository.PasswordValidate(login, password);
        }

        public IEnumerable<AuthAccount> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }

        public IEnumerable<AuthAccount> GetAllAccountsWithValidToken()
        {
            return _accountRepository.GetAllAccountsWithValidToken(_tokenLibrary.Validation);
        }
    }
}
