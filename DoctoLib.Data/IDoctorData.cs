using System;
using System.Collections.Generic;
using System.Text;
using DoctoLib.Core;

namespace DoctoLib.Data
{
	public interface IDoctorData
	{
		IEnumerable<Doctor> GetDoctorsByName(string name);
		Doctor GetById(int id);
	}
}
