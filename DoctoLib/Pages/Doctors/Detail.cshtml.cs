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
    public class DetailModel : PageModel
    {
		private readonly IDoctorData doctorData;

		public Doctor Doctor { get; set; } 
		[TempData]
		public string Message { get; set; }
		public DetailModel(IDoctorData doctorData)
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
    }
}