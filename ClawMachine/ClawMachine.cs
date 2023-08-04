using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claw_Machine
{
    internal class ClawMachine
    {
        //props
        public List<Reward> AllRewards { get; set; }
        public decimal CostToPlay { get; set; }

        //constructor
        public ClawMachine()
        {
            CostToPlay = 1.50m;
            AllRewards = new List<Reward>();
            AllRewards.Add(new Reward("Cheap candy", 0.50m));
            AllRewards.Add(new Reward("Cheap candy", 0.50m));
            AllRewards.Add(new Reward("Cheap candy", 0.50m));
            AllRewards.Add(new Reward("Candy Bar", 1.00m));
            AllRewards.Add(new Reward("Candy Bar", 1.00m));
            AllRewards.Add(new Reward("Stuffed Animal", 10.00m));
        }

        //method

        public Reward GetReward()
        {
            //Will randomly select a reward and will return it.
            Random rand = new Random();
            int randIndex = rand.Next(0,AllRewards.Count);
            return AllRewards[randIndex];
        }

        public bool MadeProfit(Reward reward) //This method will take in a reward as a parameter
        {
            if (reward.Value > CostToPlay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Play()
        {
            //This method will call GetReward and will save the reward in a variable
            Reward reward = GetReward();
            //Display the name of the item in the console
            Console.WriteLine($"You got a {reward.Name}");
            //Pass that reward into MadeProfit, if it returns true, display “You made a profit” in the console.
            //If it returns false, display “You lost money” in the console
            if (MadeProfit(reward) == true)
            {
                Console.WriteLine("You made a profit");
            }
            else
            {
                Console.WriteLine("You lost money");
            }
        }
    }
}
