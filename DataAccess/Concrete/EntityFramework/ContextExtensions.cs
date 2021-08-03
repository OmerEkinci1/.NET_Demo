﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public static class ContextExtensions
    {
        public static DbSet<T> Set<T>(this DbContext _context, Type t) where T : class
        {
            return (DbSet<T>)_context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(_context, null);
        }
        public static IQueryable<T> QueryableOf<T>(this DbContext _context, string typeName) where T : class
        {
            var type = _context.Model.GetEntityTypes(typeName).First();
            // once modelden gercek type'i coz
            var q = (IQueryable)_context
                .GetType()
                .GetMethod("Set")
                .MakeGenericMethod(type.ClrType)
                .Invoke(_context, null);
            return q.OfType<T>();
        }
    }
}
