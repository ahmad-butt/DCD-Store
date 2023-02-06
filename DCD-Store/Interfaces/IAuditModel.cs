using System;
namespace DCD_Store.Interfaces
{
	public interface IAuditModel
	{
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

