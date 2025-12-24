using NorthernWatch.Domain.Entities;
using NorthernWatch.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernWatch.Application.Services
{
    public class EventService
    {
        public void ApplyChoice(Castle castle, GameEvent gameEvent, EventOption chosenOption, Expedition expedition = null)
        {
            if (chosenOption.MoraleChange != 0)
            {
                castle.UpdateMorale(chosenOption.MoraleChange);
            }

            if (chosenOption.HealthDamage != 0 && gameEvent.Category == EventCategory.Expedition)
            {
                if (expedition != null)
                {
                    var randomParticipant = expedition.Participants[Random.Shared.Next(expedition.Participants.Count)];
                    randomParticipant.HealthChange(-1 * chosenOption.HealthDamage);
                }
                else
                {
                    var randomBrother = castle.Brothers[Random.Shared.Next(castle.Brothers.Count)];
                    randomBrother.HealthChange(-1 * chosenOption.HealthDamage);
                }
            }

            if (chosenOption.WallStrengthChange != 0)
            {
                castle.UpdateWallStrength(chosenOption.WallStrengthChange);
            }

            if (chosenOption.ResourceChange != null)
            {
                castle.ResoursesAdd(chosenOption.ResourceChange);
            }

            if (chosenOption.NewBrother != null)
            {
                castle.Brothers.Add(chosenOption.NewBrother);
            }

        }
    }
}
