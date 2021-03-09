using System;
using Microsoft.AspNetCore.WebUtilities;

namespace WebApiPagination.Models
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetPageUri(string route)
        {
            return new Uri(string.Concat(_baseUri ,route));
        }
    }
}