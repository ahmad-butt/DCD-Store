using System;
using DCD_Store.Interfaces;

namespace DCD_Store.Models
{
	public abstract class FullAuditModel : IIdentityModel, IAuditModel, IActiveModel
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}

