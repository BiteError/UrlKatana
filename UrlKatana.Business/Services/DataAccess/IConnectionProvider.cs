using System.Data;

namespace UrlKatana.Business.Services.DataAccess
{
    public interface IConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
