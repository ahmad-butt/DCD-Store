﻿using System;
namespace DCD_Store.Models
{
	public class User
	{
        public double? Id { get; set;}
		public string? Username { get; set;}
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }
    }
}

