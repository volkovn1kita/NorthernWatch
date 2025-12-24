using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernWatch.Domain.Constants
{
    public static class GameSettings
    {
        public const int FoodPerBrother = 1;
        public const int BaseWallDamagePerDay = 1;
        public const int MoralePenaltyForHunger = -10;
        public const int MoralePenaltyForLackOfFirewoodInWinter = -5;
        public const int FirewoodNeededInWinter = 2;
    }
}
