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
        bool _notEnoughtMoney = false;
        Drink _drinkSelected;

        public void SelectDrink(Drink drink)
        {
            _drinkSelected = drink;
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

        public void AddMoney(double paid)
        {
            if (_drinkSelected == Drink.Message) return;

            double missed = 0;
            switch (_drinkSelected)
            {
                case Drink.Coffee:
                    if (paid < 0.6)
                    {
                        missed = paid - 0.6;
                        _notEnoughtMoney = true;
                    }
                    break;
                case Drink.Tea:
                    if (paid < 0.4)
                    {
                        missed = paid - 0.4;
                        _notEnoughtMoney = true;
                    }
                    break;
                case Drink.Chocolate:
                    if (paid < 0.5)
                    {
                        missed = paid - 0.5;
                        _notEnoughtMoney = true;
                    }
                    break;
                default:
                    break;

            }
            if (_notEnoughtMoney)
            {
                _message = "It misses " + -missed + " euro to order your drink";
            }
        }

        public string SendInstruction(string message = null)
        {
            if (_isMessage)
            {
                _message = "M:" + message;
            }
            //Console.WriteLine("Send " + _message + " to drink maker");
            if (_notEnoughtMoney)
            {
                return _message;
            }
            else
            {
                return "Send " + _message + " to drink maker";
            }
        }
    }
}
