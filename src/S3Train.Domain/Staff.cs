using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class Staff : EntityBase
    {
        public Guid PositionId { get; set; }
        public string NameStaff { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual Position Position { get; set; }
    }
}
