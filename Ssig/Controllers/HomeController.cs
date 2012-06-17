using System;
using System.Linq;
using System.Web.Mvc;
using Ssig.Models;
using Ssig.ViewModels;

namespace Ssig.Controllers {
    public class HomeController : RavenController {

        public ActionResult Index() {
            HomeViewModel vm = new HomeViewModel();    
            Meeting result = RavenSession.Query<Meeting>().OrderByDescending(x => x.MeetingDate).FirstOrDefault();

            vm.NextMeeting = result;
            
            return View(vm);
        }
    }
}
