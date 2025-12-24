using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthernWatch.Domain.Constants;

namespace NorthernWatch.Domain.Entities
{
    public class Castle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Castle Black";
        public Resources Stores { get; private set; } = new Resources();

        [Range(0, 100)]
        public int Morale { get; private set; } = 100;
        public int CurrentDay { get; private set; } = 1;

        [Range(0, 100)]
        public int WallStrength { get; private set; }
        public List<NightWatchman> Brothers { get; set; } = new List<NightWatchman>();

        public void NextDay()
        {
            CurrentDay++;
        }

        public void UpdateMorale(int change)
        {
            Morale = Math.Clamp(Morale + change, 0, 100);
        }

        public void ConsumeResources(int foodPerPerson, bool isWinter)
        {
            int totalFoodNeeded = Brothers.Count * foodPerPerson;

            if(!Stores.TrySpend(food: totalFoodNeeded))
            {
                UpdateMorale(GameSettings.MoralePenaltyForHunger);
            }

            if (isWinter)
            {
                int totalFirewoodNeeded = Brothers.Count * GameSettings.FirewoodNeededInWinter;
                if (!Stores.TrySpend(wood: totalFirewoodNeeded))
                {
                    UpdateMorale(GameSettings.MoralePenaltyForLackOfFirewoodInWinter);
                }
            }
        }

        public void ResoursesAdd(Resources resources)
        {
            Stores.AddResources(resources);
        }

        public void UpdateWallStrength(int change)
        {
            WallStrength = Math.Clamp(WallStrength + change, 0, 100);
        }

    }
}
