using System;
using System.Collections.Generic;
using System.Text;
using DoctoLib.Core;

namespace DoctoLib.Data
{
	interface IDoctorData
	{
		IEnumerable<Doctor> GetAll();
	}
}
