using DoctoLib.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctoLib.Data
{
	class InMemoryDoctorData : IDoctorData
	{
		private readonly List<Doctor> doctors;
		public InMemoryDoctorData()
		{
			doctors = new List<Doctor>()
			{
				new Doctor() { Name = "Salah Mrani", Location = "Rouamzine, Meknes", Type = DoctorType.Dentist },
				new Doctor() { Name = "Safae Mrani", Location = "Hamria, Meknes", Type = DoctorType.Dentist },
				new Doctor() { Name = "Outmane Baladi", Location = "Marcher central, Casablanca", Type = DoctorType.Cardiologists}
			};
		}
		public IEnumerable<Doctor> GetAll()
		{
			return doctors;
		}
	}
}
