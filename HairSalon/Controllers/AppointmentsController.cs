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

    //TODO: Figure out if I need an Index

    public ActionResult Create()
    {
      ViewData["stylistList"] = new SelectList(_db.Stylists, "StylistId", "Name");
      ViewData["clientsList"] = new SelectList(_db.Clients, "ClientId", "Name");
      return View();
    }

    public ActionResult Details(int id)
    {
      Appointment thisAppt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
      return View(thisAppt);
    }

    public ActionResult Edit(int id)
    {
      ViewData["stylistList"] = new SelectList(_db.Stylists, "StylistId", "Name");
      ViewData["clientsList"] = new SelectList(_db.Clients, "ClientId", "Name");
      Appointment thisAppt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
      return View(thisAppt);
    }

    [HttpPost]
    public ActionResult Edit(Appointment appt)
    {
      _db.Entry(appt).State = EntityState.Modified;
      _db.SaveChanges();
      //TODO: Not sure this will work
      return RedirectToAction("Index", "Clients", appt.ClientId);
    }

    [HttpPost]
    public ActionResult Create(Appointment appt)
    {
      _db.Appointments.Add(appt);
      _db.SaveChanges();
      return RedirectToAction("Index", "Clients", appt.ClientId);
    }

    public ActionResult Delete(int id)
    {
      Appointment thisAppt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
      _db.Appointments.Remove(thisAppt);
      return RedirectToAction("Index", "Clients", thisAppt.ClientId);
    }
  }
}