﻿using NUnit.Framework;
using ShoppingCart.Core.Money;
using ShoppingCart.Services.UserSession;

namespace ShoppingCart.Tests.Services.UserSession.GivenARequestToSetBasketForUser
{
    [TestFixture]
    public class WheTheSuccessfulRequestIsMade
    {
        private ShoppingCart.Services.UserSession.Basket _result;

        [OneTimeSetUp]
        public void SetUp()
        {
            var subject = new UserSessionService(null, null, null);
            var userToken = subject.NewUser();

            subject.SetBasketForUser(userToken, new ShoppingCart.Services.UserSession.Basket {Total = Money.From(5000)});
            _result = subject.GetBasketForUser(userToken);
        }

        [Test]
        public void ThenTheCorrectBasketIsSavedForTheUser()
        {
            Assert.That(_result.Total.InPence, Is.EqualTo(5000));
        }
    }
}