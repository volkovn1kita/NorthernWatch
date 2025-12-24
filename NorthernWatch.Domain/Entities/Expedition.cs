using NorthernWatch.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernWatch.Domain.Entities
{
    public class Expedition
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<NightWatchman> Participants { get; set; } = new List<NightWatchman>();
        public ExpeditionType Type { get; set; }
        public int DaysRemaining { get; set; }
        public ExpeditionStatus Status { get; set; }

        [Range(1, 10)]
        public int DangerLevel { get; set; }
        public string? NarrativeReport { get; set; }
    }
}
