using SimpleTokenAuth.Domain.Entities;
using SimpleTokenAuth.Library;
using System;
using Xunit;

namespace SimpleTokenAuth.Tests.UnitTests {

    /// <summary>
    ///     SimpleTokenLibrary testes
    /// </summary>
    public class SimpleTokenLibraryTests {

        /// <summary>
        ///     Test the new genereted Token
        /// </summary>
        [Fact]
        public void NewTokenSucess() {
            //Define expiration in munutes
            const int expirationInMinutes = 30;
            //Get new simple token
            var simpleTokenAuth = new SimpleTokenLibrary(expirationInMinutes);
            //Get new token
            var tokenData = simpleTokenAuth.NewToken();

            //Verify token
            Assert.NotNull(tokenData);
            //Get token
            Assert.NotNull(tokenData.Token);
            //Verifica if token is a Guid number
            Assert.True(Guid.TryParse(tokenData.Token, out Guid tokenKey));
            //Verify if is null
            Assert.NotNull(tokenKey);
            //Veriify if token is empty
            Assert.True(tokenKey != Guid.Empty);
            //Verify expiration token date
            Assert.NotNull(tokenData.ExpirationDate);
            //Verify is the date is valid
            Assert.NotNull(tokenData.ExpirationDate > DateTime.UtcNow.AddMinutes(expirationInMinutes * -1));
        }

        /// <summary>
        ///     Test the new genereted Token
        /// </summary>
        [Fact]
        public void ValidateNewToken() {
            //Define expiration time in minutes
            const int expirationInMinutes = 30;
            //Build the token library
            var simpleTokenLibrary = new SimpleTokenLibrary(expirationInMinutes);
            //Get new token data
            var tokenData = simpleTokenLibrary.NewToken();

            //Verify if is null
            Assert.NotNull(tokenData);

            //Get the p rocess result
            var result = simpleTokenLibrary.Validation(tokenData);

            //Verify if the result is null
            Assert.True(result);
        }

        /// <summary>
        ///     Verify if token is expired
        /// </summary>
        [Fact]
        public void ValidateTokenExpired() {
            //Define token data
            var tokenData = new TokenData();
            //Define the expiratiob time in minutes
            const int expirationInMinutes = 30;
            //Get the simple token library
            var simpleTokenLibrary = new SimpleTokenLibrary(expirationInMinutes);

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = simpleTokenLibrary.Validation(tokenData);

            //Verify if result processed with error
            Assert.False(result);
        }

        /// <summary>
        ///     Try to valid null token data
        /// </summary>
        [Fact]
        public void ValidateTokenIsNull() {
            //Define token data as null
            TokenData tokenData = null;
            //Define the expiratiob time in minutes
            const int expirationInMinutes = 30;

            //Get the simple token library
            var simpleTokenLibrary = new SimpleTokenLibrary(expirationInMinutes);

            //Process validation
            // ReSharper disable once ExpressionIsAlwaysNull
            var result = simpleTokenLibrary.Validation(tokenData);

            //Verify if result processed with error
            Assert.False(result);
        }
    }
}