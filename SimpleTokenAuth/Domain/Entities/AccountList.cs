using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTokenAuth.Domain.Contracts;

namespace SimpleTokenAuth.Domain.Entities {

    /// <summary>
    /// Account client list
    /// </summary>
    public class AccountList : IAccountList {

        /// <summary>
        /// constructor method
        /// </summary>
        public AccountList() {
            //List inititalize
            AuthAccounts = new ConcurrentDictionary<string, AuthAccount>();
        }

        /// <summary>
        /// Authorization accounts
        /// </summary>
        public IDictionary<string, AuthAccount> AuthAccounts { get; set; }
    }
}
