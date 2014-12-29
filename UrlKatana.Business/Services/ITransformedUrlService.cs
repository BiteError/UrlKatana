using System;
using UrlKatana.Domain;

namespace UrlKatana.Business.Services
{
    public interface ITransformedUrlService : IService
    {

        TransformedUrl GetTransformedUrl(string shortUrl);

        string GetShortUrl(string longUrl);
    }
}
