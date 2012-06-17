using System;
using System.Linq;
using System.Web.Mvc;
using Ssig.Models;
using Ssig.ViewModels;

namespace Ssig.Controllers
{
    public class MeetingController : RavenController
    {
        //
        // GET: /Meeting/

        public ActionResult Index()
        {
            MeetingListViewModel meetings = new MeetingListViewModel();
            meetings.Meetings = RavenSession.Query<Meeting>().OrderByDescending(x => x.MeetingDate).ToList();
            return View(meetings);
        }

        //
        // GET: /Meeting/Details/5

        public ActionResult Details(int id)
        {
            MeetingDetailViewModel vm = new MeetingDetailViewModel();
            vm.Meeting = RavenSession.Load<Meeting>(id);
            return View(vm);
        }


    }
}
