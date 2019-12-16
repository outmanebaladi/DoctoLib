using System.Collections.Generic;
using DoctoLib.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DoctoLib.Data
{
	public class SqlDoctorData : IDoctorData
	{
		private readonly DoctoLibDbContext db;
		public SqlDoctorData(DoctoLibDbContext db)
		{
			this.db = db;
		}
		public Doctor Add(Doctor newDoctor)
		{
			db.Add(newDoctor);
			return newDoctor;
		}

		public int Commit()
		{
			return db.SaveChanges();
		}

		public Doctor Delete(int id)
		{
			var doctor = GetById(id);
			if(doctor != null)
			{
				db.Doctors.Remove(doctor);
			}
			return doctor;
		}

		public Doctor GetById(int id)
		{
			return db.Doctors.Find(id);
		}

		public IEnumerable<Doctor> GetDoctorsByName(string name)
		{
			return from d in db.Doctors
				   where d.Name.StartsWith(name) || string.IsNullOrEmpty(name)
				   orderby d.Name
				   select d;
		}

		public Doctor Update(Doctor updatedDoctor)
		{
			var entity = db.Doctors.Attach(updatedDoctor);
			entity.State = EntityState.Modified;
			return updatedDoctor;
		}
	}
}
