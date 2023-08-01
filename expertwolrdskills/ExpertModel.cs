using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace expertwolrdskills
{
    internal class ExpertModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public string ParticipantFIO { get; set; }
        public bool status { get; set; }
        public ExpertModel(int iD, string name, string surname, string lastname, string participantfio, bool status)
        {

            ID = iD;
            Name = name;
            Surname = surname;
            Lastname = lastname;
            ParticipantFIO = participantfio;
            this.status = status;
        }
    }
}
