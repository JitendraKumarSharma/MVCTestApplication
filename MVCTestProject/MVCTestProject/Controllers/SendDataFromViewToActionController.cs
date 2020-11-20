using MVCTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCTestProject.Controllers
{
    public class SendDataFromViewToActionController : Controller
    {
        // GET: SendDataFromViewToAction
        public ActionResult SimpleInterest()
        {
            return View();
        }

        #region Using Traditional Approach
        ////By default POST request comes here
        //public ActionResult CalculateSimpleInterestResult()
        //{
        //    decimal principle = Convert.ToDecimal(Request["txtAmount"].ToString());
        //    decimal rate = Convert.ToDecimal(Request["txtRate"].ToString());
        //    int time = Convert.ToInt32(Request["txtYear"].ToString());

        //    decimal simpleInteresrt = (principle * time * rate) / 100;

        //    StringBuilder sbInterest = new StringBuilder();
        //    sbInterest.Append("<b>Amount :</b> " + principle + "<br/>");
        //    sbInterest.Append("<b>Rate :</b> " + rate + "<br/>");
        //    sbInterest.Append("<b>Time(year) :</b> " + time + "<br/>");
        //    sbInterest.Append("<b>Interest :</b> " + simpleInteresrt);
        //    return Content(sbInterest.ToString());
        //}
        #endregion

        #region Using FormCollection

        //public ActionResult CalculateSimpleInterestResult(FormCollection form)
        //{
        //    decimal principle = Convert.ToDecimal(form["txtAmount"].ToString());
        //    decimal rate = Convert.ToDecimal(form["txtRate"].ToString());
        //    int time = Convert.ToInt32(form["txtYear"].ToString());

        //    decimal simpleInteresrt = (principle * time * rate) / 100;

        //    StringBuilder sbInterest = new StringBuilder();
        //    sbInterest.Append("<b>Amount :</b> " + principle + "<br/>");
        //    sbInterest.Append("<b>Rate :</b> " + rate + "<br/>");
        //    sbInterest.Append("<b>Time(year) :</b> " + time + "<br/>");
        //    sbInterest.Append("<b>Interest :</b> " + simpleInteresrt);
        //    return Content(sbInterest.ToString());
        //}
        #endregion

        #region Using Parameters
        //[HttpPost]
        //public ActionResult CalculateSimpleInterestResult(string txtAmount, string txtRate, string txtYear)
        //{
        //    decimal principle = Convert.ToDecimal(txtAmount);
        //    decimal rate = Convert.ToDecimal(txtRate);
        //    int time = Convert.ToInt32(txtYear);

        //    decimal simpleInteresrt = (principle * time * rate) / 100;

        //    StringBuilder sbInterest = new StringBuilder();
        //    sbInterest.Append("<b>Amount :</b> " + principle + "<br/>");
        //    sbInterest.Append("<b>Rate :</b> " + rate + "<br/>");
        //    sbInterest.Append("<b>Time(year) :</b> " + time + "<br/>");
        //    sbInterest.Append("<b>Interest :</b> " + simpleInteresrt);
        //    return Content(sbInterest.ToString());
        //}
        #endregion

        public ActionResult SimpleInterestWithModel()
        {
            SimpleInterestModel model = new SimpleInterestModel();
            return View(model);
        }

        [HttpPost]
        [HandleError]
        public ContentResult CalculateSimpleInterestResult(SimpleInterestModel model)
        {
            Session["Name"] = "Helo";
            HttpContext.Session["jj"] = "lkl";
            decimal simpleInteresrt = (model.Amount * model.Year * model.Rate) / 100;
            StringBuilder sbInterest = new StringBuilder();
            sbInterest.Append("<b>Amount :</b> " + model.Amount + "<br/>");
            sbInterest.Append("<b>Rate :</b> " + model.Rate + "<br/>");
            sbInterest.Append("<b>Time(year) :</b> " + model.Year + "<br/>");
            sbInterest.Append("<b>Interest :</b> " + simpleInteresrt);
            return Content(sbInterest.ToString());
        }
    }
}