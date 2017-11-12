﻿using System.Collections.Generic;

namespace ShoppingCart.Data.Database
{
    public interface IDatabase
    {
        List<T> Query<T>();
        T Save<T>(T record);
    }
}