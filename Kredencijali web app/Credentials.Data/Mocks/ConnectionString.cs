using Credentials.Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Credentials.Data.Mocks
{
    public class ConnectionString : IConnectionString
    {
        #region Dependecy Injection

        private readonly IConfiguration configuration;

        #endregion Dependecy Injection

        #region Constructrs

        public ConnectionString(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ConnectionString()
        {
        }

        #endregion Constructrs

        #region Functions

        /// <summary>
        /// Get db connection string
        /// </summary>
        /// <returns>Connection string</returns>
        public string GetDbConnectionString()
        {
            return configuration.GetSection("ConnectionStrings")["DefaultConnection"];
        }

        #endregion Functions
    }
}