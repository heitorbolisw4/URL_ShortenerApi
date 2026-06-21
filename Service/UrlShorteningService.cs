using Data;
using Microsoft.EntityFrameworkCore;
using URL_ShortnetApi.Entities;

namespace URL_ShortnetApi.Service
{
    public class UrlShorteningService(AppDbContext dbContext)
    {
        private readonly Random _random = new();

        public async Task<string> GenerateUniqueCode()
        {
            var codeChars = new char[ShortLinkSettings.Length];
            var maxValue = ShortLinkSettings.Alphabet.Length;

            while (true)
            {
                for(var i = 0; i < ShortLinkSettings.Length; i++)
                {
                    var randomIndex = _random.Next(maxValue);
                    codeChars[i] = ShortLinkSettings.Alphabet[randomIndex];
                }
                var code = new string(codeChars);

                if(!await dbContext.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }
        }
    }
}