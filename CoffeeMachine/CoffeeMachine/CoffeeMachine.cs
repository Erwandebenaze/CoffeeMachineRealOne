using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        string _message = String.Empty;
        bool _isMessage = false;

        public void SelectDrink(Drink drink)
        {
            switch (drink)
            {
                case Drink.Coffee:
                    _message = "C";
                    break;
                case Drink.Tea:
                    _message = "T";
                    break;
                case Drink.Chocolate:
                    _message = "H";
                    break;
                case Drink.Message:
                    _message = "M";
                    _isMessage = true;
                    break;
                default:
                    break;
            }
        }

        public void AddSugar(int numberOfSugar)
        {
            if (numberOfSugar > 0)
            {
                _message += ":" + numberOfSugar + ":0";
            }
            else
            {
                _message += "::";
            }
        }

        public string SendInstruction(string message = null)
        {
            if (_isMessage)
            {
                _message = "M:" + message;
            }
            //Console.WriteLine("Send " + _message + " to drink maker");
            return "Send " + _message + " to drink maker";
        }
    }
}
