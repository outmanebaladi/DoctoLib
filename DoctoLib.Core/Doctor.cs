﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoctoLib.Core
{
	public class Doctor
	{
		public int Id { get; set; }
		[Required, StringLength(80)]
		public string Name { get; set; }
		[Required, StringLength(255)]
		public string Location { get; set; }
		public DoctorType Type { get; set; }
	}
}
