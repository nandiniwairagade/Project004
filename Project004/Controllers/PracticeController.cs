using Project004.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project004.Controllers
{
    public class PracticeController : Controller
    {
        // GET: Practice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PracticeIndex()
        {
            return View();
        }

        public ActionResult savereg(PracticeModel model)
        {
            try

            {
                return Json(new { Message = (new PracticeModel().savereg(model)) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new {model= ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPracticeList()
        {
            try

            {
                return Json(new { model = new PracticeModel().GetPracticeList() }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new {model= ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult deletePractice(int ID)
        {
            try

            {
                return Json(new { model = new PracticeModel().deletePractice(ID) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

    