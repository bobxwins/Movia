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

            // Tester om TrafficData data modellen er tom ved initialiseringen
        }


        [Fact]
        public void TestCreatingTrafficData()
        {
            // Tester om TrafficData kan postes via HttPost

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
            //Tester om TrafficData kan findes via at søge efter en traffic line

            String line;

        }


        [Fact]
        public void TestGetTrafficDataByDate( )
        {
            //Tester om TrafficData kan findes via at søge mellem 2 datoer
            String Date;

        }


    }
}