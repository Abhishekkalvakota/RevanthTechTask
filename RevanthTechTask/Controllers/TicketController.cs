using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RevanthTechTask.Models;

namespace RevanthTechTask.Controllers
{
    public class TicketController : Controller
    {
        public ActionResult Index()
        {
            using(TicketDBEntities db = new TicketDBEntities())
            {

                List<tblTicket> List = db.tblTickets.ToList();
                return View(List);
            }
        }
  
        public ActionResult Registration()
        {

            var categories = new List<string> { "IT Software", "IT Hardware" };
            var priorities = new List<string> { "P1", "P2" };
            var assignmentTypes = new List<string> { "Group", "User" };
            var statuses = new List<string> { "Open", "Closed" };
            var contactTypes = new List<string> { "Phone", "Email" };
            var assigneeGroups = new List<string> { "IT Software", "IT Hardware" };
            var assigneeTo = new List<string> { "Ram", "Laxman", "Bharath" };


            ViewBag.Categories = new SelectList(categories);
            ViewBag.Priorities = new SelectList(priorities);
            ViewBag.AssignmentTypes = new SelectList(assignmentTypes);
            ViewBag.Statuses = new SelectList(statuses);
            ViewBag.ContactTypes = new SelectList(contactTypes);
            ViewBag.AssigneeGroups = new SelectList(assigneeGroups);
            ViewBag.AssigneeTo = new SelectList(assigneeTo);

            return View(new tblTicket());
           
        }

        [HttpPost]
        public ActionResult Registration(tblTicket Ticket)
        {

            if (ModelState.IsValid) {

                using (TicketDBEntities db = new TicketDBEntities())
                {
                    db.tblTickets.Add(Ticket);
                    db.SaveChanges();
                    var ticektNumber = Ticket.Id;
                    TempData["Message"] = $"Ticket Added Succesfully Number {ticektNumber}";
                    return RedirectToAction("Showinfo", new { id = ticektNumber });
                }

            }
            return View();

        }

        public ActionResult Showinfo(int id)
        {
            using (TicketDBEntities db = new TicketDBEntities())
            {
                tblTicket tkt = db.tblTickets.Find(id);

                var categories = new List<string> { "IT Software", "IT Hardware" };
                var priorities = new List<string> { "P1", "P2" };
                var assignmentTypes = new List<string> { "Group", "User" };
                var statuses = new List<string> { "Open", "Closed" };
                var contactTypes = new List<string> { "Phone", "Email" };
                var assigneeGroups = new List<string> { "IT Software", "IT Hardware" };
                var assigneeTo = new List<string> { "Ram", "Laxman", "Bharath" };

                ViewBag.Categories = new SelectList(categories);
                ViewBag.Priorities = new SelectList(priorities);
                ViewBag.AssignmentTypes = new SelectList(assignmentTypes);
                ViewBag.Statuses = new SelectList(statuses);
                ViewBag.ContactTypes = new SelectList(contactTypes);
                ViewBag.AssigneeGroups = new SelectList(assigneeGroups);
                ViewBag.AssigneeTo = new SelectList(assigneeTo);

              

                return View(tkt);
            }

           
        }
        [HttpPost]
        public ActionResult Edit(tblTicket model)
        {
            using (TicketDBEntities db = new TicketDBEntities())
            {
                var categories = new List<string> { "IT Software", "IT Hardware" };
                var priorities = new List<string> { "P1", "P2" };
                var assignmentTypes = new List<string> { "Group", "User" };
                var statuses = new List<string> { "Open", "Closed" };
                var contactTypes = new List<string> { "Phone", "Email" };
                var assigneeGroups = new List<string> { "IT Software", "IT Hardware" };
                var assigneeTo = new List<string> { "Ram", "Laxman", "Bharath" };

                ViewBag.Categories = new SelectList(categories);
                ViewBag.Priorities = new SelectList(priorities);
                ViewBag.AssignmentTypes = new SelectList(assignmentTypes);
                ViewBag.Statuses = new SelectList(statuses);
                ViewBag.ContactTypes = new SelectList(contactTypes);
                ViewBag.AssigneeGroups = new SelectList(assigneeGroups);
                ViewBag.AssigneeTo = new SelectList(assigneeTo);

                if (ModelState.IsValid)
                {

                    tblTicket tbl = db.tblTickets.Find(model.Id);
                    tbl.AdditionalInfo = model.AdditionalInfo;
                    tbl.AssigneeGroup = model.AssigneeGroup;
                   // tbl.AssigneeTo = model.AssigneeTo;
                    tbl.Category = model.Category;
                    tbl.ContactType = model.ContactType;
                    tbl.Priorityy = model.Priorityy;
                    tbl.RaisedBy = model.RaisedBy;
                    tbl.ShortDescription = model.ShortDescription;
                    tbl.Statuss = model.Statuss;
                    tbl.AssignmentType = model.AssignmentType;
                    tbl.Userr = model.Userr;
                    db.SaveChanges();

                }
                return RedirectToAction("Showinfo", new { id = model.Id });

            }


        }


        public ActionResult Delete(int id)
        {
            using (TicketDBEntities db = new TicketDBEntities())
            {

                db.tblTickets.Remove(db.tblTickets.Find(id));
                db.SaveChanges();
                TempData["Message"] = $"Ticket Deleted Succesfully Number {id}";
                return RedirectToAction("Index");
            }
  
        }

   }
}