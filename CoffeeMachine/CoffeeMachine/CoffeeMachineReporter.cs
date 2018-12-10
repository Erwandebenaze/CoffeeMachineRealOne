using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public static class CoffeeMachineReporter
    {
        public static string DrinksTaken;
        public static double MoneyEarned;


        public static string PrintReport()
        {
            StringBuilder sb = new StringBuilder();
            var drinksTaken = DrinksTaken.Split('/');
            foreach (string drink in drinksTaken)
            {
                if(!String.IsNullOrWhiteSpace(drink))
                {
                    sb.Append("Commande : ");
                    sb.AppendLine(drink);
                }
            }
            sb.AppendLine();
            sb.Append("Gain : ");
            sb.Append(MoneyEarned);

            return sb.ToString();
        }
    }
}
