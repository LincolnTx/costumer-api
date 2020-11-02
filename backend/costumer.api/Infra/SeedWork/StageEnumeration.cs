using System;
using System.Collections.Generic;
using System.Linq;

namespace costumer.api.Infra.SeedWork
{
    public class StageEnumeration : Enumeration
    {
        public static readonly StageEnumeration Active = new StageEnumeration(1, nameof(Active));
        public static readonly StageEnumeration Inactive = new StageEnumeration(2, nameof(Inactive));

        public StageEnumeration(int id, string name) : base(id, name) { }

        public static IEnumerable<StageEnumeration> List() =>
            new[] { Active, Inactive };

        public static StageEnumeration FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCulture));

            if (state == null)
            {
                throw new Exception($"Possible values for Stage: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static StageEnumeration FromId(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for Stage: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
