using NorthernWatch.Domain.Entities;
using NorthernWatch.Domain.Enums;
using NorthernWatch.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace NorthernWatch.Application.Services
{
    public class GameEngine
    {
        public void ProcessDay(Castle castle, List<Expedition> expeditions)
        {
            castle.NextDay();
            castle.ConsumeResources(GameSettings.FoodPerBrother, IsWinter(castle.CurrentDay));
            UpdateExpeditions(expeditions);
            //Generator random events
        }

        public static bool IsWinter(int dayOfYear)
        {
            dayOfYear = ((dayOfYear - 1) % 365) + 1;

            if ((dayOfYear >= 1 && dayOfYear <= 59) || (dayOfYear >= 334 && dayOfYear <= 365))
                return true;

            return false;
        }


        public void UpdateExpeditions(List<Expedition> expeditions)
        {
            foreach (var expedition in expeditions)
            {
                if(expedition.Status == ExpeditionStatus.InTransit)
                {
                    expedition.DaysRemaining--;
                    if(expedition.DaysRemaining <= 0)
                    {
                        ExpeditionEnd(expedition);
                        //Generate report
                    }
                }
            }
        }

        public void ExpeditionEnd(Expedition expedition)
        {
            expedition.Status = ExpeditionStatus.Returned;
            foreach (var participant in expedition.Participants)
            {
                participant.ReturnFromMission();
            }
        }


    }
}
