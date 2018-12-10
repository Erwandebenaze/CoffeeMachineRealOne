using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CoffeeMachine.Tests
{
    [TestClass]
    public class MakingDrinksTests
    {
        [TestMethod]
        public void CoffeeMachine_send_tea_with_1_sugar()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Tea);
            coffeeMachine.AddSugar(1);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send T:1:0 to drink maker", message);
        }

        [TestMethod]
        public void CoffeeMachine_send_chocolate_with_no_sugar()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Chocolate);
            coffeeMachine.AddSugar(0);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send H:: to drink maker", message);
        }
        [TestMethod]
        public void CoffeeMachine_send_coffee_with_2_sugars()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Coffee);
            coffeeMachine.AddSugar(2);
            string message = coffeeMachine.SendInstruction();
            // Assert
            Assert.AreEqual("Send C:2:0 to drink maker", message);
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
    }
}
