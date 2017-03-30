using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTokenAuth.Domain.Entities;

namespace SimpleTokenAuth.Library {

    /// <summary>
    /// Token data library
    /// </summary>
    public interface ITokenLibrary {

        /// <summary>
        /// Generate new token
        /// </summary>
        /// <returns></returns>
        TokenData NewToken();

        /// <summary>
        /// Token validation library
        /// </summary>
        /// <param name="tokenData">token data</param>
        /// <param name="error">error message</param>
        /// <returns>|flag for validation success</returns>
        bool Validation(TokenData tokenData, out string error);
    }
}
