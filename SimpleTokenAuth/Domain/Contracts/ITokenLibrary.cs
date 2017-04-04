using SimpleTokenAuth.Domain.Entities;

namespace SimpleTokenAuth.Domain.Contracts {

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
        /// <returns>|flag for validation success</returns>
        bool Validation(TokenData tokenData);
    }
}