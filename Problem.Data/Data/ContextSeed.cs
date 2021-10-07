using Faker;
using Microsoft.Extensions.Logging;
using Problem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.Data.Data
{
   public class ContextSeed
    {
        public static async Task SeedAsync(BuildingDbContext context, ILoggerFactory loggerFactory)
        {
            DateTime start = new(2020, 1, 1, 0, 0, 0);

            // start= start.AddMinutes(1);
            //  string a =start.ToString();
           // short n = 1;
           // short obj = 1;
           // short dat = 1;
           try
            {
                //  if (!context.Buildings.Any())
                //  {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 730; j++) //365*2
                    {
                        for (int k = 0; k < 24; k++)
                        {
                            for (int l = 0; l < 60; l++)
                            {
                                for (int m =0;m<10;m++)
                                    {
                                        Building building = new()
                                        {
                                        //    Id=  1,
                                            Name=Name.FullName(),
                                            Location=Address.City().Trim()
                                        };
                                        Problem2.Models.Object objectt = new()
                                        {
                                          //  Id= obj,
                                            Name=Name.First()
                                        };
                                        DataField dataField = new()
                                        {
                                          //  Id= dat,
                                            Name=Name.Last()
                                        };
                                        
                                        context.Buildings.Add(building);
                                        context.Objects.Add(objectt);
                                        context.DataFields.Add(dataField);
                                        await context.SaveChangesAsync();
                                        Reading reading = new()
                                        {
                                           // Id=n,
                                            BuildingId = building.Id,
                                            ObjectId = objectt.Id,
                                            DataFieldId = dataField.Id,
                                            Value =(decimal)RandomNumber.Next(0, 200)/10,
                                            TimeStamp = start
                                        };
                                        context.Readings.Add(reading);
                                        await context.SaveChangesAsync();
                                    //n++;
                                  //  obj++;
                                  //  dat++;
                                    }
                                   start= start.AddMinutes(1);
                               }
                    }
                }
           }
            //  await context.SaveChangesAsync();
             // }
             }
catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BuildingDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
