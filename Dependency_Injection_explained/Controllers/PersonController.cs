using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dependency_Injection_explained.Interfaces;
using Dependency_Injection_explained.Models;

namespace Dependency_Injection_explained.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPerson _PersonService;

        public PersonController(IPerson PassedObj)
        {
            this._PersonService = PassedObj;
        }

        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPersonForm()
        {
            return View();
        }

        public ActionResult ShowList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SavePerson(Person person)
        {

            string res = _PersonService.SavePersonData(person);
            return Json(res, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetAllPeople()
        {

            string res = _PersonService.GetAllPeopleData();
            return Json(res, JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdatePerson(Person obj)
        {
            string res = _PersonService.UpdatePersonData(obj);


            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePerson(int personID)
        {
            string res = _PersonService.DeletePersonData(personID);
            return Json(res, JsonRequestBehavior.AllowGet);

        }

        
        

    }
}