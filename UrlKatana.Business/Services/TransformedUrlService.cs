using System;
using UrlKatana.Business.Helpers;
using UrlKatana.Business.Services.DataAccess;
using UrlKatana.Domain;

namespace UrlKatana.Business.Services
{
    public class TransformedUrlService : ITransformedUrlService
    {
        ITransformedUrlRepository repository;
        public TransformedUrlService(ITransformedUrlRepository repository)
        {
            this.repository = repository;
        }

        public TransformedUrl GetTransformedUrl(string shortUrl)
        {
            var id = ConvertFromShortUrlHelper.GetId(shortUrl);
            return repository.Get(id);
        }


        public string GetShortUrl(string longUrl)
        {
            TransformedUrl transformedUrl = CreateTransformedUrl(longUrl);
            string shortUrl = ConvertToShortUrlHelper.GetShortUrl(transformedUrl.Id);
            return shortUrl;
        }

        public TransformedUrl CreateTransformedUrl(string longUrl)
        {
            var transformedUrl = new TransformedUrl { LongUrl = longUrl };
            repository.Save(transformedUrl);
            return transformedUrl;
        }
    }
}
