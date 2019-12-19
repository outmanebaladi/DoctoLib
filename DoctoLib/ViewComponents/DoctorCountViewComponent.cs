using DoctoLib.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctoLib.ViewComponents
{
	public class DoctorCountViewComponent : ViewComponent
	{
		private readonly IDoctorData doctorData;
		public DoctorCountViewComponent(IDoctorData doctorData)
		{
			this.doctorData = doctorData;
		}
		public IViewComponentResult Invoke()
		{
			var count = doctorData.GetCountOfDoctors();
			return View(count);
		}
	}
}
