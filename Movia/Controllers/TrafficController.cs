using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movia.Data;
using Movia.Models;
using System.Net;

namespace Movia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TrafficController : Controller
    {
        public readonly TrafficContext dbContext;
        public TrafficController(TrafficContext dbContext)
        {
            this.dbContext = dbContext;
        }
 

        [HttpGet("GetByLine")]
        public async Task<IActionResult> GetLineTraffic(String line)
        {
            var trafficLine = dbContext.Traffic.Where(x => x.Line == line).OrderByDescending(x => x.Date).ToListAsync();

            if (trafficLine == null)
            {
                return NotFound();
            }

            Console.WriteLine("At " + DateTime.Now + " " + ", You searched for: " + line);
            return Ok(trafficLine);
        }

        [HttpGet("GetDate")]
        public async Task<IActionResult> GetDateTraffic(DateTime startDate, DateTime endDate)
        {
            var trafficDate = dbContext.Traffic.Where(x => x.Date > startDate && x.Date < endDate).OrderByDescending(x => x.Date).ToListAsync();
            if (trafficDate == null)
            {
                return NotFound();
            }
            Console.WriteLine("At " + DateTime.Now+ "" +
                "\nYou searched for the start date: " + startDate.ToString() +" and end date: " + endDate.ToString());
            return Ok(trafficDate);
        }

        [HttpPost]

        public async Task<IActionResult> AddTraffic(TrafficData addTrafficData)
        {
            var trafficData = new TrafficData()
            {
                Line = addTrafficData.Line,
                Date = DateTime.Now,
                Message = addTrafficData.Message
            };

            await dbContext.Traffic.AddAsync(trafficData);
            await dbContext.SaveChangesAsync();
            return Ok(trafficData);
        }
    }
}
