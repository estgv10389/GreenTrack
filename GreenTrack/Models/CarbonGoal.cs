using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTrack.Models
{
   public class CarbonGoal
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public decimal TargetEmission { get; set; }
        public int UserId { get; set; }

    }
}
