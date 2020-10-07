using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakfastForLumberjacksCh8
{
    class Lumberjack
    {
        private string name;
        public string Name { get { return name; } }
        private Stack<Flapjack> meal;

        public Lumberjack(string name)
        {
            this.name = name;
            meal = new Stack<Flapjack>();
        }

        public int FlapjackCount { get { return meal.Count; } }

        public void EatFlapjacks()
        {
            if (meal.Count > 0)
            {
                Console.WriteLine(Name.ToString() + "'s eating flapjacks");
                Console.WriteLine(Name + " ate a " + meal.Peek().ToString().ToLower() + " flapjack"); 
            }
            else
            {
                return;
            }
        }

        public void TakeFlapjacks(Flapjack food, int value)
        {
            for (int i = 0; i < value; i++)
            {
                meal.Push(food);
            }
        }
    }

    enum Flapjack
    {
        Crispy,
        Soggy,
        Browned,
        Banana
    }
}
