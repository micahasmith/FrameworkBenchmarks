using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;

using Benchmarks.AspNet.Models;
using System.Threading.Tasks;

namespace Benchmarks.AspNet.Controllers
{
    public class EntityFrameworkController : AsyncController
    {
        public async Task<ActionResult> Index(string providerName, int? queries)
        {
            List<World> worlds = new List<World>(queries ?? 1);

            using (EntityFramework db = new EntityFramework(providerName))
            {
                Random random = new Random();
                
                for (int i = 0; i < worlds.Capacity; i++)
                {
                    int randomID = random.Next(0, 10000) + 1;
                    worlds.Add(await db.Worlds.FindAsync(randomID));
                }
            }

            return queries != null ? Json(worlds, JsonRequestBehavior.AllowGet)
                                   : Json(worlds[0], JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Fortunes(string providerName)
        {
            List<Fortune> fortunes = new List<Fortune>();

            using (EntityFramework db = new EntityFramework(providerName))
            {
                fortunes.AddRange(await db.Set<Fortune>().ToArrayAsync());
            }

            fortunes.Add(new Fortune { ID = 0, Message = "Additional fortune added at request time." });
            fortunes.Sort();

            return View("Fortunes", fortunes);
        }
    }
}