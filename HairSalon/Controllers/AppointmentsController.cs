using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class AppointmentsController : Controller
  {
    private readonly HairSalonContext _db;

    public AppointmentsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
      _db.Appointments.Add(appointment);
      _db.SaveChanges();
      return RedirectToAction("ViewAppts", "Clients", new { id = appointment.ClientId });
    }

    public ActionResult Details(int id)
    {
      Appointment thisAppt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
      return View(thisAppt);
    }

    public ActionResult Edit(int id)
    {
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name");
      Appointment thisAppt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
      return View(thisAppt);
    }

    [HttpPost]
    public ActionResult Edit(Appointment appointment)
    {
      _db.Entry(appointment).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = appointment.AppointmentId });
    }
  }
}
