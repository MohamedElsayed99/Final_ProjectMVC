using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    public class PropertyController : Controller
    {
        RealStateDataContext CON;
        public PropertyController()
        {
            CON = new RealStateDataContext();
        }
        public IActionResult Index()
        {
            var properties = CON.Properties.ToList();
            return View(properties);
        }
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Property property)
        {
            CON.Properties.Add(property);
            CON.SaveChanges();
            return RedirectToAction("Index");
            //return View(property);
        }
        public IActionResult Details(int id)
        {
            var property = CON.Properties.FirstOrDefault(p => p.Id == id);
            return View(property);
        }
        public IActionResult Edit(int id)
        {

            var prop = CON.Properties.SingleOrDefault(x => x.Id == id);

            return View("Create", prop);
        }

        [HttpPost]
        public IActionResult Edit(int id, Property property)
        {
            var prop = CON.Properties.SingleOrDefault(p => p.Id == id);
            prop.LOGO = property.LOGO;
            prop.Address1 = property.Address1;
            prop.Address2 = property.Address2;
            prop.City = property.City;
            prop.NumBedrooms = property.NumBedrooms;
            prop.NumBathrooms = property.NumBathrooms;
            prop.PropertyStatus = property.PropertyStatus;
            prop.EmployeeId = property.EmployeeId;
            prop.Employee = property.Employee;
            prop.PropertySize = property.PropertySize;
            prop.PropertyStatusId = property.PropertyStatusId;
            prop.PropertyTypeId = property.PropertyTypeId;
            
            CON.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var property = CON.Properties.Find(id);
            CON.Properties.Remove(property);
            CON.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
