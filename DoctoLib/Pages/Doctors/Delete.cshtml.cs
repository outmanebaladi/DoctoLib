using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctoLib.Core;
using DoctoLib.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoctoLib.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
		private readonly IDoctorData doctorData; 

		public Doctor Doctor { get; set; }
		public DeleteModel(IDoctorData doctorData)
		{
			this.doctorData = doctorData;
		}
        public IActionResult OnGet(int doctorId)
        {
			Doctor = doctorData.GetById(doctorId);
			if(Doctor == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
        }

		public IActionResult OnPost(int doctorId)
		{
			var doctor = doctorData.Delete(doctorId);
			doctorData.Commit();

			if(doctor == null)
			{
				return RedirectToPage("./NotFound");
			}

			TempData["Message"] = $"{doctor.Name} deleted";
			return RedirectToPage("./List");
		}
    }
}
