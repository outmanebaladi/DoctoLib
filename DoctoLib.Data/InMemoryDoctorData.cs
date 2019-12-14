using DoctoLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctoLib.Data
{
	public class InMemoryDoctorData : IDoctorData
	{
		private readonly List<Doctor> doctors;
		public InMemoryDoctorData()
		{
			doctors = new List<Doctor>()
			{
				new Doctor() { Id = 1, Name = "Salah Mrani", Location = "Rouamzine, Meknes", Type = DoctorType.Dentist },
				new Doctor() { Id = 2, Name = "Safae Mrani", Location = "Hamria, Meknes", Type = DoctorType.Dentist },
				new Doctor() { Id = 3, Name = "Outmane Baladi", Location = "Marcher central, Casablanca", Type = DoctorType.Cardiologists}
			};
		}
		public IEnumerable<Doctor> GetDoctorsByName(string name)
		{
			return from d in doctors
				   where string.IsNullOrEmpty(name) || d.Name.StartsWith(name)
				   select d;
		}

		public Doctor GetById(int id)
		{
			return doctors.SingleOrDefault(d => d.Id == id);
		}
	}
}
