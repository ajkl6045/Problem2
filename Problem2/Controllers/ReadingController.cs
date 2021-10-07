using Microsoft.AspNetCore.Mvc;
using Problem2.Data.Services.Interfaces;
using Problem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IReadingService _readingService;
        public ReadingController(IReadingService readingService)
        {
            _readingService = readingService;
        }
        [HttpGet("getData")]
        public ActionResult<RedCast> GetMethods()
        {
            var list =  _readingService.GetReadingAll();
           
            Red model = new()
            {
                Label = "Building",
                Data = new List<decimal>(),
              //  DateTimesList = new List<DateTime>()
            };
            RedCast redCast = new()
            {
                RedList = new List<Red>(),
                ChartLabels = new List<string>()
            };
          
            foreach (var app in list)
        
            {
                model.Data.Add(app.Value);
                redCast.ChartLabels.Add(app.TimeStamp.TimeOfDay.ToString());
            }
         
            redCast.RedList.Add(model);
         
            return Ok(redCast);
        }
        [HttpPost("search")]
        public ActionResult<RedCast> GetData(Search search)
        {
            DateTime start = Convert.ToDateTime(search.Start);
            DateTime end = Convert.ToDateTime(search.End);
            var list = _readingService.GetByRange(start,end);
            
            Red model = new()
            {
                Label = "Building",
                Data = new List<decimal>(),
                //  DateTimesList = new List<DateTime>()
            };
            RedCast redCast = new()
            {
                RedList = new List<Red>(),
                ChartLabels = new List<string>()
            };
           
            foreach (var app in list)
            // for(int i=1;i<7;i++)
            {
                model.Data.Add(app.Value);
                redCast.ChartLabels.Add(app.TimeStamp.TimeOfDay.ToString());
            }
            //  model.Data = DataList;
            
           
            redCast.RedList.Add(model);
           
            return Ok(redCast);
        }
        public class Red
        {
            public List<decimal> Data { get; set; }
           // public List<DateTime> DateTimesList { get; set; }
            public string Label { get; set; }
        }
        public class RedCast
        {
            public List<Red> RedList { get; set; }
            //  public List<string> ChartLabels { get; set; }
            public List<string> ChartLabels { get; set; }
        }
        public class Search
        {
            public string Start { get; set; }
            public string End { get; set; }
        }

    }
}
