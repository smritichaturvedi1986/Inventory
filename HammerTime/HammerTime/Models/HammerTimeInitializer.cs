using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HammerTime.Models
{
    public class HammerTimeInitializer:DropCreateDatabaseIfModelChanges<HTContext>
    {
        protected override void Seed(HTContext context)
        {
            var hammer = new List<Hammer>
            {
                new Hammer{Size=7,type="curve claw"},
                 new Hammer{Size=10,type="Ripe claw"},
                   new Hammer{Size=15,type="curve claw"},
                 new Hammer{Size=20,type="Ripe claw"}
             };

            foreach (var Temp in hammer)
            {
                context.Hammers.Add(Temp);
            }
            context.SaveChanges();
        }
    }
}