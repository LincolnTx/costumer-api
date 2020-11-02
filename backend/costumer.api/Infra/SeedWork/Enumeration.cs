using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace costumer.api.Infra.SeedWork
{
    public abstract class Enumeration
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public
                                             | BindingFlags.Static | BindingFlags.DeclaredOnly);


            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public static T FromValue<T>(int value) where T : Enumeration
        {
            return Parse<T, int>(value, "value", item => item.Id == value);
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            return GetAll<T>().FirstOrDefault(predicate);
        }
    }
}
