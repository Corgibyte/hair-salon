using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    public ActionResult Details(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      ViewData["clients"] = _db.Clients.Where(client => client.StylistId == id).ToList();
      return View(thisStylist);
    }

    public ActionResult Edit(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      _db.Entry(stylist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      List<Client> associatedClients = _db.Clients.Where(client => client.StylistId == id).ToList();
      List<Appointment> associatedAppts = _db.Appointments.Where(appt => appt.StylistId == id).ToList();
      foreach (Client client in associatedClients)
      {
        _db.Clients.Remove(client);
      }
      foreach (Appointment appt in associatedAppts)
      {
        _db.Appointments.Remove(appt);
      }
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult ViewClients(int id)
    {
      List<Client> clients = _db.Clients.Where(client => client.StylistId == id).ToList();
      ViewBag.StylistId = id;
      ViewBag.StylistName = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id).Name;
      return View(clients);
    }

    public ActionResult ViewAppts(int id)
    {
      List<Appointment> appts = _db.Appointments.Where(appt => appt.StylistId == id).ToList();
      ViewBag.StylistId = id;
      ViewBag.StylistName = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id).Name;
      return View(appts);
    }
  }
}