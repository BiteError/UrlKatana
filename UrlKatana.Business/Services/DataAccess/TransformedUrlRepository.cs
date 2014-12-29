using UrlKatana.Domain;
using System.Data;
using System.Linq;
using Dapper;


namespace UrlKatana.Business.Services.DataAccess
{
    public class TransformedUrlRepository : ITransformedUrlRepository
    {
        IConnectionProvider provider { get; set; }

        public TransformedUrlRepository(IConnectionProvider provider)
        {
            this.provider = provider;
        }
        public TransformedUrl Get(int id)
        {
            using (var connection = provider.GetConnection())
            {
                if (connection == null)
                {
                    return null;
                }

                connection.Open();

                TransformedUrl result = connection.Query<TransformedUrl>(
                    @"SELECT Id, 
                    LongUrl FROM TransformedUrl
                    WHERE Id = @id", new { id }).FirstOrDefault();
                return result;
            }
        }
        public void Save(TransformedUrl transformedUrl)
        {
            using (var connection = provider.GetConnection())
            {
                if (connection == null)
                {
                    return;
                }

                connection.Open();
                transformedUrl.Id = connection.Query<int>(
                    @"INSERT INTO TransformedUrl 
                    (LongUrl) VALUES 
                    (@LongUrl);
                    select last_insert_rowid()", transformedUrl).First();
            }
        }
    }
}
