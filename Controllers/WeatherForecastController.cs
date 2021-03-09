using Microsoft.AspNetCore.Mvc;
using Bogus;
using WebApiPagination.Models;
using System;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApiPagination.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUriService uriService;

        public WeatherForecastController(IUriService uriService)
        {
            this.uriService = uriService;
        }
        [HttpGet]
        public IActionResult Index(int pg=1)
        {
            var path=uriService.GetPageUri(Request.Path.Value).ToString();
            var pager=new Pager(pg,GenerateData(),path);
            
            return Ok(pager);
        }
        public List<PersonModel> GenerateData()
        {
            var fakePersonData=new Faker<PersonModel>()
            .RuleFor(x=>x.Id,f=> Guid.NewGuid())
            .RuleFor(x=>x.FirstName,x=>x.Person.FirstName)
            .RuleFor(x=>x.LastName,x=>x.Person.LastName)
            .RuleFor(x=>x.DOB,x=>x.Date.Past(20));

            List<PersonModel> result =new List<PersonModel>();
            for(int i=0;i<100;i++){
               result.Add(fakePersonData.Generate());
            }
            return result;
        }
    }
}
