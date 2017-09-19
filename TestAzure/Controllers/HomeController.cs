using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAzure.Models;
using TestAzure.DBModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using eComplaints.Models.ReportViewModels;
using TestAzure.Models.ReportViewModels;
using Microsoft.AspNetCore.Http;

namespace TestAzure.Controllers
{
    public class HomeController : Controller
    {
        eComplaintsCTX ctx;
        private readonly IHttpContextAccessor _accesor;

        public HomeController(IHttpContextAccessor accesor)
        {
            ctx = new eComplaintsCTX();
            _accesor = accesor;
        }

        public IActionResult Index()
        {
            var context = _accesor.HttpContext;
            var host = context.Request.Host.Value;
            ViewBag.host = host;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Originator(string message = null)
        {
            ViewBag.Message = message;

            var Areas = ctx.Area.Where(x => x.DepartmentId == 2).ToList();
            var AreaList = new SelectList(Areas, "Id", "Name");
            ViewBag.AreaList = AreaList;


            var qCategories = ctx.Qcategory.Where(x => x.DepartmentId == 2).ToList();
            var Categorylist = new SelectList(qCategories, "Id", "Name");
            ViewBag.CategoryList = Categorylist;

            return View();
        }

        [HttpPost]
        public IActionResult Originator(MOriginatorReport model)
        {
            return Originator("Plangere creata cu succes");
        }

        public JsonResult RetrieveEquipment(int areaId)
        {
            var zones = ctx.Zone.Where(arr => arr.AreaId == areaId).ToList();

            List<Equipment> EquipmentList = new List<Equipment>();
            foreach (var z in zones)
            {
                var equipment = ctx.Equipment.Where(arr => arr.ZoneId == z.Id).ToList();
                foreach (var eq in equipment)
                {
                    if (!EquipmentList.Contains(eq))
                        EquipmentList.Add(eq);
                }
            }

            List<EquipmentJSON> json2Send = new List<EquipmentJSON>();
            foreach (var e in EquipmentList)
                json2Send.Add(new EquipmentJSON { Id = e.Id, EquipmentName = e.Name });

            return Json(json2Send);
        }

        public JsonResult RetrieveQuestions(int categoryId)
        {
            var Questions = ctx.Question.Where(x => x.CategoryId == categoryId).ToList();

            List<QuestionJSON> json2Send = new List<QuestionJSON>();
            foreach (var c in Questions)
                json2Send.Add(new QuestionJSON { Id = c.Id, QuestionName = c.Question1 });

            return Json(json2Send);
        }


    }
}
