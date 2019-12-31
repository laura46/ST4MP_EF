using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ST4MPCRM.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ST4MPCRM
{
    public class InMemoryDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new ST4MPContext(serviceProvider.GetRequiredService<DbContextOptions<ST4MPContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;   
                }
                GetData(context);
                context.SaveChanges();
            }
        }
        public static void GetData(ST4MPContext context) 
        {
            String customerString = File.ReadAllText("./Data/customers.json");
            String shopsString = File.ReadAllText("./Data/shops.json");
            List<Customers> customers = JsonConvert.DeserializeObject<List<Customers>>(customerString);
            List<Shops> shops = JsonConvert.DeserializeObject<List<Shops>>(shopsString);
            context.AddRange(customers);
            context.AddRange(shops);
        }
    }
}
