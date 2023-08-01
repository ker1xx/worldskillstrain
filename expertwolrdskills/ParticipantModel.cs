using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expertwolrdskills
{
    public partial class ParticipantModel
    {
        public int? Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int FullYear { get; set; }
        public bool ConfirmationStatus { get; set; }
        public ParticipantModel(int? Id, string Surname, string Name, string Lastname, DateTime? BirthDate, int FullYear, bool ConfirmationStatus)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Lastname = Lastname;
            this.BirthDate = BirthDate;
            this.FullYear = FullYear;
            this.ConfirmationStatus = ConfirmationStatus;
        }
    }
}
