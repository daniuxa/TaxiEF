using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDBData;
using TaxiDomain;

namespace CarShowroomDB
{
    public class AsyncToDB
    {
        private DbContextOptions options;
        public AsyncToDB(DbContextOptions options)
        {
            this.options = options;
        }
        public async Task AsyncAdd()
        {
            using (TaxiDBContext context = new TaxiDBContext(options))
            {
                for (int i = 0; i < 10; i++)
                {
                    await context.Clients.AddAsync(new Client { LName = "Client " + i });
                    await context.SaveChangesAsync();
                }         
            }
        }

        public async Task AsyncRead()
        {
            using (TaxiDBContext context = new TaxiDBContext(options))
            {
                var list = await context.Clients.ToListAsync();
                foreach (var item in list)
                {
                    Console.WriteLine(item.LName);
                }
            }
        }
    }
}
