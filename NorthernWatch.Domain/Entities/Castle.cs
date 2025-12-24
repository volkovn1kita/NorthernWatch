using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernWatch.Domain.Entities
{
    public class Castle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Castle Black";
        public Resources Stores { get; set; } = new Resources();

        [Range(0, 100)]
        public int Morale { get; set; } = 100;
        public int CurrentDay { get; set; } = 1;

        [Range(0, 100)]
        public int WallStrength { get; set; }
        public List<NightWatchman> Brothers { get; set; } = new List<NightWatchman>();

        public void NextDay(int foodConsumption)
        {
            CurrentDay++;
            Stores.Food -= foodConsumption;

            if (Stores.Food < 0)
            {
                Stores.Food = 0;
                UpdateMorale(-10); 
            }
        }

        public void UpdateMorale(int change)
        {
            Morale = Math.Clamp(Morale + change, 0, 100);
        }

    }
}
