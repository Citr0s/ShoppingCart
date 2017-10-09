﻿using System;
using ShoppingCart.Core.Communication;
using ShoppingCart.Data.Database;

namespace ShoppingCart.Data.Topping
{
    public class GetToppingRepository : IGetToppingRepository
    {
        private readonly IDatabase _database;

        public GetToppingRepository(IDatabase database)
        {
            _database = database;
        }

        public GetToppingsResponse GetAll()
        {
            var response = new GetToppingsResponse();

            try
            {
                response.Toppings = _database.Query<ToppingRecord>();
            }
            catch (Exception)
            {
                response.AddError(new Error
                {
                    Message = "Something went wrong when retrieving ToppingRecord from database."
                });
            }

            return response;
        }
    }
}