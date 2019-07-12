using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EntityFramework6.Models;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace EntityFramework6.Controllers
{
    public class HomeController : Controller
    {
        private CloudFoundryServicesOptions CloudFoundryServices { get; set; }

        public HomeController(IOptions<CloudFoundryServicesOptions> servOptions)
        {
            if (servOptions != null)
                CloudFoundryServices = servOptions.Value;
        }

        public IActionResult Index([FromServices]TeamContext context)
        {
            var teams = 
                context
                    .Teams
                    .Select(c => new TeamViewModel
                        {
                            TeamName = c.TeamName,
                            Location = c.Location,
                            Mascot = c.Mascot,
                            Id = c.Id
                        })
                    .OrderBy(c => c.Id).ToList();
            return View(teams);
        }

        public IActionResult Services()
        {
            return View(CloudFoundryServices ?? new CloudFoundryServicesOptions());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
