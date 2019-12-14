using System;
using System.Collections.Generic;
using System.Text;

namespace DoctoLib.Core
{
	public class Doctor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public DoctorType Type { get; set; }
	}
}
