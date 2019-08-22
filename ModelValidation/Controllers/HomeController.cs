using System;
using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() =>
            View("MakeBooking", new Appointment { Date = DateTime.Now });

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {

            /// Rem После применения атрибутов в классе МОДЕЛИ !!!
            /// 
            ///
            /*if (string.IsNullOrEmpty(appt.ClientName))
            {
                ModelState.AddModelError(nameof(appt.ClientName), "Enter Your Name");
                // Введите свое имя
            }

            if(ModelState.GetValidationState("Date") == ModelValidationState.Valid && DateTime.Now > appt.Date)
            {
                ModelState.AddModelError(nameof(appt.Date), "Please enter a data in future");
            }

            if(!appt.TermsAccepted)
            {
                ModelState.AddModelError(nameof(appt.TermsAccepted),"Please Accept Terms");
            }*/

            if (ModelState.GetValidationState(nameof(appt.Date))
                    == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(appt.ClientName))
                    == ModelValidationState.Valid
                && appt.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase)
                && appt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("",
                    "Joe cannot book appointments on Mondays");
            }


            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View();
            }           

        }
    }
}
