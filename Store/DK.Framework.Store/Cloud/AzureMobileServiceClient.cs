//using DK.Framework.Store.Interfaces;
//using Microsoft.WindowsAzure.MobileServices;
//using System.Composition;
//using System.Threading.Tasks;

namespace DK.Framework.Store.Cloud
{
    /// <summary>
    /// Client for Windows Azure Mobile Services.
    /// </summary>
    //[Export(typeof(DK.Framework.Store.Interfaces.IMobileServiceClient))]
    //[Shared]
    //public class AzureMobileServiceClient : DK.Framework.Store.Interfaces.IMobileServiceClient
    //{
    //    MobileServiceClient _client;

    //    /// <summary>
    //    /// Initializes client.
    //    /// </summary>
    //    public AzureMobileServiceClient()
    //    {
    //        var clientSettings = Initializer.GetSingleExport<IMobileServiceSettings>();

    //        _client = new MobileServiceClient(clientSettings.ApplicationURL, clientSettings.ApplicationKey);
    //    }

    //    /// <summary>
    //    /// Retrieves a data table from the mobile service.
    //    /// </summary>
    //    /// <typeparam name="TTableEntity">The data entity the desired table contains.</typeparam>
    //    /// <returns>Mobile services table (if it exists).</returns>
    //    public IMobileServiceTable<TTableEntity> GetTable<TTableEntity>()
    //    {
    //        return _client.GetTable<TTableEntity>();
    //    }

    //    /// <summary>
    //    /// Authenticates the user with the specified provider.
    //    /// </summary>
    //    /// <param name="provider">The <see cref="MobileServiceAuthenticationProvider"/> to authenticate with.</param>
    //    /// <returns>A task for async execution.</returns>
    //    /// <remarks>Populates the mobile service user.</remarks>
    //    public async Task Authenticate(MobileServiceAuthenticationProvider provider)
    //    {
    //        User = await _client.LoginAsync(provider);
    //    }

    //    /// <summary>
    //    /// Gets whether a user has been authenticated with this client.
    //    /// </summary>
    //    public bool IsAuthenticated { get { return User != null; } }

    //    /// <summary>
    //    /// Gets the mobile service user.
    //    /// </summary>
    //    /// <value>User instance if authenticated; Otherwise null.</value>
    //    public MobileServiceUser User { get; private set; }
    //}
}
