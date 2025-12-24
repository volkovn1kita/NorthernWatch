using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthernWatch.Domain.Entities
{
    public class Resources
    {
        public int Food { get; private set; }
        public int Wood { get; private set; }
        public int Stone { get; private set; }
        public decimal Gold { get; private set; }
        public int Obsidian { get; private set; }

        public Resources(int food = 0, int wood = 0, int stone = 0, int gold = 0, int obsidian = 0)
        {
            Food = food;
            Wood = wood;
            Stone = stone;
            Gold = gold;
            Obsidian = obsidian;
        }

        public void AddResources(Resources other)
        {
            Food += other.Food;
            Wood += other.Wood;
            Stone += other.Stone;
            Gold += other.Gold;
            Obsidian += other.Obsidian;
        }
        public bool HasEnough(int food = 0, int wood = 0, int stone = 0, decimal gold = 0, int obsidian = 0)
        {
            return Food >= food && Wood >= wood && Stone >= stone && Gold >= gold && Obsidian >= obsidian;
        }

        public bool TrySpend(int food = 0, int wood = 0, int stone = 0, decimal gold = 0, int obsidian = 0)
        {
            if (!HasEnough(food, wood, stone, gold, obsidian))
                return false;

            Food -= food;
            Wood -= wood;
            Stone -= stone;
            Gold -= (decimal)gold;
            Obsidian -= obsidian;
            return true;
        }

    }
}
