using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthernWatch.Domain.Enums;

namespace NorthernWatch.Domain.Entities
{
    public class NightWatchman
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Role Role { get; set; }

        [Range(1, 100)]
        public int Strength { get; set; }

        [Range(1, 100)]
        public int Stamina { get; set; }

        [Range(1, 100)]
        public int Intelligence { get; set; }

        [Range(0, 100)]
        public int Health { get; private set; } = 100;
        public bool IsDead => Health <= 0;
        public bool IsAssigned { get; private set; } = false;

        public void HealthChange(int change)
        {
            Health = Math.Clamp(Health + change, 0, 100);
        }

        public void AssignToMission()
        {
            IsAssigned = true;
        }

        public void ReturnFromMission()
        {
            IsAssigned = false;
        }

    }
}
