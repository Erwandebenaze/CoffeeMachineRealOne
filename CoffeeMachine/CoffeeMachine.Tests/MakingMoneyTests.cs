using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CoffeeMachine.Tests
{
    [TestClass]
    public class MakingMoneyTests
    {
        [TestMethod]
        public void CoffeeMachine_send_tea_with_1_sugar_with_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Tea);
            coffeeMachine.AddSugar(1);
            coffeeMachine.AddMoney(1.0);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send T:1:0 to drink maker", message);
        }
        [TestMethod]
        public void CoffeeMachine_send_tea_extra_hot_with_1_sugar_with_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Tea, true);
            coffeeMachine.AddSugar(1);
            coffeeMachine.AddMoney(1.0);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send Th:1:0 to drink maker", message);
        }

        [TestMethod]
        public void CoffeeMachine_send_tea_with_1_sugar_with_not_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Tea);
            coffeeMachine.AddSugar(1);
            coffeeMachine.AddMoney(0.3);
            string message = coffeeMachine.SendInstruction();

            // Assert
            Assert.AreEqual("It misses 0,1 euro to order your drink", message);
        }
        [TestMethod]
        public void CoffeeMachine_send_tea_extra_hot_with_1_sugar_with_not_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Tea, false);
            coffeeMachine.AddSugar(1);
            coffeeMachine.AddMoney(0.3);
            string message = coffeeMachine.SendInstruction();

            // Assert
            Assert.AreEqual("It misses 0,1 euro to order your drink", message);
        }

        [TestMethod]
        public void CoffeeMachine_send_chocolate_with_no_sugar_with_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Chocolate);
            coffeeMachine.AddSugar(0);
            coffeeMachine.AddMoney(1.0);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send H:: to drink maker", message);
        }
        [TestMethod]
        public void CoffeeMachine_send_chocolate_extra_hot_with_no_sugar_with_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Chocolate, true);
            coffeeMachine.AddSugar(0);
            coffeeMachine.AddMoney(1.0);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send Hh:: to drink maker", message);
        }
        [TestMethod]
        public void CoffeeMachine_send_chocolate_with_no_sugar_without_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Chocolate);
            coffeeMachine.AddSugar(0);
            coffeeMachine.AddMoney(0.3);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("It misses 0,2 euro to order your drink", message);
        }

        [TestMethod]
        public void CoffeeMachine_send_chocolate_extra_hot_with_no_sugar_without_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Chocolate, true);
            coffeeMachine.AddSugar(0);
            coffeeMachine.AddMoney(0.3);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("It misses 0,2 euro to order your drink", message);
        }
        [TestMethod]
        public void CoffeeMachine_send_coffee_with_2_sugars_with_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Coffee);
            coffeeMachine.AddSugar(2);
            coffeeMachine.AddMoney(1.0);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send C:2:0 to drink maker", message);
        }

        [TestMethod]
        public void CoffeeMachine_send_coffee_extra_hot_with_2_sugars_with_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Coffee, true);
            coffeeMachine.AddSugar(2);
            coffeeMachine.AddMoney(1.0);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send Ch:2:0 to drink maker", message);
        }

        [TestMethod]
        public void CoffeeMachine_send_coffee_with_2_sugars_without_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Coffee);
            coffeeMachine.AddSugar(2);
            coffeeMachine.AddMoney(0.3);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("It misses 0,3 euro to order your drink", message);
        }

        [TestMethod]
        public void CoffeeMachine_send_coffee_extra_hot_with_2_sugars_without_enought_money()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Coffee, true);
            coffeeMachine.AddSugar(2);
            coffeeMachine.AddMoney(0.3);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("It misses 0,3 euro to order your drink", message);
        }

        [TestMethod]
        public void CoffeeMachine_send_message()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Message);
            coffeeMachine.AddSugar(0);
            string message = coffeeMachine.SendInstruction("myMessage");
            // Assert
            Assert.AreEqual("Send M:myMessage to drink maker", message);
        }

        [TestMethod]
        public void ZCoffeeMachineReporter_print_report()
        {
            // Le test ne passe pas mais je vois pourtant le même texte.
            Assert.AreEqual("Commande : Tea\nCommande : Tea extra hot\nCommande : Chocolate\nCommande : Chocolate extra hot\nCommande : Coffee\nCommande : Coffee extra hot\n\nGain : 4", CoffeeMachineReporter.PrintReport());
        }
    }
}
