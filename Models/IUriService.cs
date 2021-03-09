using System;

namespace WebApiPagination.Models
{
    public interface IUriService
    {
        public Uri GetPageUri(string route);
    }
}