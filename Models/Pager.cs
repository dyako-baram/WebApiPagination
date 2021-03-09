using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Microsoft.AspNetCore.WebUtilities;

namespace WebApiPagination.Models
{
    public class Pager
    {
        public int PageSize { get; set; }=10;
        public int TotalPage { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }=1;
        public string NextPage {get;set;}
        public string PreviousPage { get; set; }
        public string LastPage { get; set; }
        public string FirstPage { get; set; }

        public List<PersonModel> Data { get; set; }
        public Pager(int curentPage,List<PersonModel> data,string url)
        {
            TotalRecords=data.Count();
            Data=data.Skip((curentPage-1)*PageSize).Take(PageSize).ToList();
            CurrentPage=curentPage;
            TotalPage=(int)Math.Ceiling(decimal.Divide(TotalRecords,PageSize));
            
            if(curentPage<TotalPage)
            NextPage=url+$"?pg={curentPage+1}";
            else
            NextPage=null;

            if(curentPage>1)
            PreviousPage=url+$"?pg={curentPage-1}";
            else
            NextPage=null;

            LastPage=url+$"?pg={TotalPage}";
            FirstPage=url+"?pg=1";
            
        }
        
    }
}
