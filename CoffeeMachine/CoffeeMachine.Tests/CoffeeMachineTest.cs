using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CoffeeMachine.Tests
{
    [TestClass]
    public class CoffeeMachineTest
    {
        [TestMethod]
        public void CoffeeMachineSendTeaWith1Sugar()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Tea);
            coffeeMachine.AddSugar(1);
            string message = coffeeMachine.SendInstruction();
            // Assert
            //coffeeMachine.Received().SendInstruction().Received();
            Assert.AreEqual("Send T:1:0 to drink maker", message);
        }

        [TestMethod]
        public void CoffeeMachineSendChocolatWithNoSugar()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Chocolate);
            coffeeMachine.AddSugar(0);
            string message = coffeeMachine.SendInstruction();
            // Assert
            //coffeeMachine.Received().SendInstruction().Received();
            Assert.AreEqual("Send H:: to drink maker", message);
        }
        [TestMethod]
        public void CoffeeMachineSendCoffeeWith2Sugars()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Coffee);
            coffeeMachine.AddSugar(2);
            string message = coffeeMachine.SendInstruction();
            // Assert
            //coffeeMachine.Received().SendInstruction().Received();
            Assert.AreEqual("Send C:2:0 to drink maker", message);
        }
        [TestMethod]
        public void CoffeeMachineSendMessage()
        {
            // Arrange
            var coffeeMachine = Substitute.For<CoffeeMachine>();

            // Act
            coffeeMachine.SelectDrink(Drink.Message);
            coffeeMachine.AddSugar(0);
            string message = coffeeMachine.SendInstruction("myMessage");
            // Assert
            //coffeeMachine.Received().SendInstruction().Received();
            Assert.AreEqual("Send M:myMessage to drink maker", message);
        }
    }
}
