using Application.Common.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllEntities(int PageSize, int PageNumber, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";

            var modifiedUri = QueryHelpers.AddQueryString(baseUrl, "PageSize", PageSize.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "PageNumber", PageNumber.ToString());

            return new Uri(modifiedUri);
        }
    }
}
