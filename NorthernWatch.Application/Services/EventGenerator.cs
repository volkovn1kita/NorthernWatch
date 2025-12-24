using NorthernWatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernWatch.Application.Services
{
    public class EventGenerator
    {
        private readonly List<GameEvent> _allEvents;

        public EventGenerator()
        {
            _allEvents = new List<GameEvent>
            {
                new GameEvent
                {
                    Title = "Знайдено покинутий обоз",
                    Category = Domain.Enums.EventCategory.Expedition,
                    Description = "Ваші розвідники знайшли обоз, занесений снігом...",
                    Options = new List<EventOption>
                    {
                        new EventOption
                        {
                            Text = "Забрати все собі",
                            ResourceChange = new Resources (food: 50),
                            MoraleChange = 5,
                            SuccessText = "Ваші брати раді здобичі!"
                        },
                        new EventOption
                        {
                            Text = "Шукати вцілілих",
                            ResourceChange = new Resources (food: 20),
                            MoraleChange = 10,
                            NewBrother = new NightWatchman
                            {
                                Name = "Едвард",
                                Role = Domain.Enums.Role.Stewards,
                                Strength = 40,
                                Stamina = 50,
                                Intelligence = 60,
                            },
                            SuccessText = "Ви знайшли нового брата!"

                        }
                    }
                },
            };
        }

        public GameEvent GetRandomEvent()
        {
            var random = new Random();
            return _allEvents[random.Next(_allEvents.Count)];
        }

    }
}
