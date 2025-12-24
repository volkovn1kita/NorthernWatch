using NorthernWatch.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernWatch.Domain.Entities
{
    public class EventOption
    {
        public string Text { get; set; }
        public string SuccessText { get; set; }
        public int MoraleChange { get; set; }
        public int WallStrengthChange { get; set; }
        public Resources ResourceChange { get; set; } = new();
        public int HealthDamage { get; set; }
        public NightWatchman NewBrother { get; set; } = new();
    }
}
