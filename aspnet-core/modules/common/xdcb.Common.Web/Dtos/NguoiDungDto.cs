using System;
using System.Collections.Generic;
using System.Text;

namespace xdcb.Common
{
    public class NguoiDungDto
    {
        public Guid Id { get; set; }
        public  string UserName { get;  set; }

        public  string Name { get;  set; }

        public  string Surname { get;  set; }

        public  string Email { get;  set; }

        public  bool EmailConfirmed { get;  set; }

        public  string PhoneNumber { get;  set; }

        public  bool PhoneNumberConfirmed { get;  set; }
    }
}
