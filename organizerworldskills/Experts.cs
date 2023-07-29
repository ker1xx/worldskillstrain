using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerworldskills
{
    public partial class Experts
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string role { get; set; }
        public string competition { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Experts(int Id, string FIO, string role,string competition, string phone, string email)
        {
            this.Id = Id;
            this.FIO = FIO;
            this.role = role;
            this.competition = competition;
            this.phone = phone;
            this.email = email;
        }
    }
}
