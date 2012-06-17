using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ssig.Models;
using Ssig.ViewModels;

namespace Ssig.Controllers
{
    public class AdministrationController : RavenController
    {
        //
        // GET: /Administration/

        public ActionResult Index()
        {
            return View(RavenSession.Query<Meeting>().ToList());
        }

        //
        // GET: /Administration/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Administration/Create

        public ActionResult Create()
        {
            AdminCreateViewModel vm = new AdminCreateViewModel();
            return View(vm);
        }

        //
        // POST: /Administration/Create

        [HttpPost]
        public ActionResult Create(Meeting meeting)
        {
            try
            {
                // TODO: Add insert logic here
                RavenSession.Store(meeting);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administration/Edit/5

        public ActionResult Edit(int id)
        {
            AdminEditViewModel vm = new AdminEditViewModel();
            vm.Meeting = RavenSession.Load<Meeting>(id);

            return View(vm);
        }

        //
        // POST: /Administration/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Meeting meeting)
        {
            try
            {
                // TODO: Add update logic here
                Meeting currentMeeting = RavenSession.Load<Meeting>(id);
                currentMeeting.Description = meeting.Description;
                currentMeeting.Name = meeting.Name;
                currentMeeting.MeetingDate = meeting.MeetingDate;

                RavenSession.Store(currentMeeting);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administration/Delete/5

        public ActionResult Delete(int id)
        {
            AdminDeleteViewModel vm = new AdminDeleteViewModel();
            vm.Meeting = RavenSession.Load<Meeting>(id);

            return View(vm);
        }

        //
        // POST: /Administration/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Meeting meeting)
        {
            try
            {
                // TODO: Add delete logic here
                Meeting meetingToDelete = RavenSession.Load<Meeting>(id);
                RavenSession.Delete(meetingToDelete);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
