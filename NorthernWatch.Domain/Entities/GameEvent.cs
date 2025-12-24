using NorthernWatch.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernWatch.Domain.Entities
{
    public class GameEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public EventCategory Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<EventOption> Options { get; set; } = new List<EventOption>();
    }
}
