using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace organizerworldskills
{
    public partial class Participants
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string competition { get; set; }
        public string role { get; set; }
        public string statusOfAgreement { get; set; }
        public Participants(int id, string surname, string name, string lastname, string competition, string role, string statusOfAgreement)
        {
            this.id = id;
            this.surname = surname;
            this.name = name;  
            this.lastname = lastname;
            this.competition = competition;
            this.role = role;
            this.statusOfAgreement = statusOfAgreement;
        }
    }
}
