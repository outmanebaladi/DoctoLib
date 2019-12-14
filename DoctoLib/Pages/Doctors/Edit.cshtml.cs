using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctoLib.Core;
using DoctoLib.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctoLib.Pages.Doctors
{
    public class EditModel : PageModel
    {
		private readonly IDoctorData doctorData;
		private readonly IHtmlHelper htmlHelper;
	
		public IEnumerable<SelectListItem> Types { get; set; }
		[BindProperty]
		public Doctor Doctor { get; set; }
		public EditModel(IDoctorData doctorData, IHtmlHelper htmlHelper)
		{
			this.doctorData = doctorData;
			this.htmlHelper = htmlHelper;
		}
		public IActionResult OnGet(int doctorId)
		{
			Types = htmlHelper.GetEnumSelectList<DoctorType>();
			Doctor = doctorData.GetById(doctorId);
			if(Doctor == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				Types = htmlHelper.GetEnumSelectList<DoctorType>();
				return Page();
			}
			doctorData.Update(Doctor);
			doctorData.Commit();
			return RedirectToPage("./Detail", new { doctorId = Doctor.Id });
		}


    }
}