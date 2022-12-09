using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Movia.Controllers;
using Movia.Data;
using Movia.Models;
using System.Net;

namespace UnitTestMovia
{
    public class UnitTest1
    {

        TrafficController trafficController;

        [Fact]
        public void AssertEmptyTrafficData()
        {
            TrafficData addTrafficData = new TrafficData();
            Assert.True(addTrafficData != null);
        }


        [Fact]
        public void TestCreatingTrafficData()
        {

            TrafficData addTrafficData = new TrafficData();
            addTrafficData.Line = "1A";
            addTrafficData.Date = DateTime.Now;
            addTrafficData.Message = "Bus";
             
           var result = trafficController.AddTraffic(addTrafficData);
          //  var okResult = result as StatusCodeResult;

          //  Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public void TestGetTrafficDataByLine ( )
        {
            String line;

        }


        [Fact]
        public void TestGetTrafficDataByDate( )
        {
            String Date;

        }


    }
}