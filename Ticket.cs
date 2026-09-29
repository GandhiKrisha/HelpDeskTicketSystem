using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskTicketSystem
{
    internal class Ticket //to start storing ticket
    {
        public int TicketId { get; set; }
        public string Name { get; set; }
        public string Issue { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}
