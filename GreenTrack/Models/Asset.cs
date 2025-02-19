using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTrack.Models
{
    public class Asset
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public decimal CarbonSavings { get; set; }
        public required string PurchaseDate { get; set; }
        public string? LastMaintenance { get; set; }
        public required int UserId { get; set; }
    }
}
