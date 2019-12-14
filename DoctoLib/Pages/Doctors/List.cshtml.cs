using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctoLib.Core;
using DoctoLib.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DoctoLib.Pages.Doctors
{
    public class ListModel : PageModel
    {
		private readonly IConfiguration config;
		private readonly IDoctorData doctorData;

		public IEnumerable<Doctor> Doctors { get; set; }
		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }

		public string Message { get; set; }
		public ListModel(IConfiguration config, IDoctorData doctorData)
		{
			this.config = config;
			this.doctorData = doctorData;
		}
        public void OnGet()
        {
			Message = config["Message"];
			Doctors = doctorData.GetDoctorsByName(SearchTerm);
        }
    }
}