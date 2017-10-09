﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ShoppingCart.Data.Pizza;
using ShoppingCart.Pizza;

namespace ShoppingCart.Tests.Pizza.GivenAPizzaService
{
    [TestFixture]
    public class WhenASuccessfulRequestIsProvided
    {
        private GetAllPizzasResponse _result;

        [SetUp]
        public void SetUp()
        {
            var getPizzaRepository = new Mock<IGetPizzaRepository>();
            getPizzaRepository.Setup(x => x.GetAll()).Returns(new GetPizzasResponse
            {
                Pizzas = new List<PizzaRecord>
                {
                    new PizzaRecord
                    {
                        Id = 1,
                        Name = "Original"
                    },
                    new PizzaRecord
                    {
                        Id = 2,
                        Name = "Veggie Delight"
                    }
                }
            });

            var subject = new PizzaService(getPizzaRepository.Object);
            _result = subject.GetAll();
        }

        [Test]
        public void ThenAListOfPizzaModelsIsReturned()
        {
            Assert.That(_result.Pizzas.Count, Is.EqualTo(2));
        }

        [TestCase(0, "Original")]
        [TestCase(1, "Veggie Delight")]
        public void ThenThePizzaNameIsMappedThroughCorrectly(int index, string name)
        {
            Assert.That(_result.Pizzas[index].Name, Is.EqualTo(name));
        }
    }
}