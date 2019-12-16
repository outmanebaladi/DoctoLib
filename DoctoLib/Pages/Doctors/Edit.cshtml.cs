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
		public IActionResult OnGet(int? doctorId)
		{
			Types = htmlHelper.GetEnumSelectList<DoctorType>();
			if (doctorId.HasValue)
			{
				Doctor = doctorData.GetById(doctorId.Value);
				if (Doctor == null)
				{
					return RedirectToPage("./NotFound");
				}
			}
			else
			{
				Doctor = new Doctor();
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
			if(Doctor.Id > 0)
			{
				doctorData.Update(Doctor);
			}
			else
			{
				doctorData.Add(Doctor);
			}
			doctorData.Commit();
			TempData["Message"] = "Doctor Saved";
			return RedirectToPage("./Detail", new { doctorId = Doctor.Id });
		}


    }
}