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
            // Injection af TrafficContext
            this.dbContext = dbContext;
          
        }
        

        [HttpGet("GetByLine")]
        public async Task<IActionResult> GetLineTraffic(String line)
        {
            var trafficLine = dbContext.Traffic.Where(x => x.Line == line).OrderByDescending(x => x.Date).ToListAsync();

            // Brug af LINQ til at foretage en query der søger efter en specifik Line String sorteret efter dato

            if (trafficLine == null)
            {
                return NotFound();
            }

            Console.WriteLine("At " + DateTime.Now + " " + ", You searched for: " + line);
            // Logger alle søgnigner i applikationens konsol
            return Ok(trafficLine);
            //Wrappes i et OK response

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

                // Parametre som der indtastes til domain objektet
            };

            await dbContext.Traffic.AddAsync(trafficData);
            await dbContext.SaveChangesAsync();
            // Keywordsne async og await bruges så
            // en opgave kan køre hvis ikke den afhænger af en anden opgave er færdig
            return Ok(trafficData);
        }
    }
}
