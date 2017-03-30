using System.Collections.Generic;
using SimpleTokenAuth.Domain.Entities;

namespace SimpleTokenAuth.Domain.Contracts {

    /// <summary>
    /// List of account for authentication process
    /// </summary>
    public interface IAccountList {

        /// <summary>
        /// User name list
        /// </summary>
        IDictionary<string, AuthAccount> AuthAccounts { get; set; }
    }
}