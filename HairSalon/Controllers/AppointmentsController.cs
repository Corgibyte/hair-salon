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

    public ActionResult Index()
    {
      List<Appointment> model = _db.Appointments.Include(appt => appt.Client).Include(appt => appt.Stylist).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
      appointment.StylistId = _db.Clients.FirstOrDefault(client => client.ClientId == appointment.ClientId).Stylist.StylistId;
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

    public ActionResult Delete(int id)
    {
      Appointment thisAppt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
      return View(thisAppt);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Appointment thisAppt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
      _db.Appointments.Remove(thisAppt);
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = thisAppt.ClientId });
    }
  }
}
