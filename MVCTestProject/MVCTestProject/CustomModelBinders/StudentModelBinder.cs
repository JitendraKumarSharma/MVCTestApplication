using MVCTestProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestProject.CustomModelBinders
{
    public class StudentModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(StudentViewModel))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
                int frmStudentId = Convert.ToInt32(request.Form.Get("StudentId").ToString());
                string frmAddress = request.Form.Get("Address");
                string frmCity = request.Form.Get("City");
                string frmState = request.Form.Get("State");

                string frmFName = request.Form.Get("FName");
                string frmMName = request.Form.Get("MName");
                string frmLName = request.Form.Get("LName");

                string frmDoorNo = request.Form.Get("DoorNo");
                string frmStreetNo = request.Form.Get("StreetNo");
                string frmAreaName = request.Form.Get("AreaName");

                string frmCountry = request.Form.Get("Country");
                int frmMarks = Convert.ToInt32(request.Form.Get("Marks").ToString());

                return new StudentViewModel
                {
                    StudentId = frmStudentId,
                    Address = frmDoorNo + " " + frmStreetNo + " " + frmAreaName,

                    City = frmCity,
                    State = frmState,
                    Name = frmFName + " " + frmMName + " " + frmLName,
                    Country = frmCountry,
                    Marks = frmMarks
                };

            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}