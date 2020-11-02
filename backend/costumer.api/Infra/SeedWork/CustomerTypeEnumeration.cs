using System;
using System.Collections.Generic;
using System.Linq;

namespace costumer.api.Infra.SeedWork
{
    public class CustomerTypeEnumeration : Enumeration
    {
        public static readonly CustomerTypeEnumeration Person = new CustomerTypeEnumeration(1, "Pessoa Física");
        public static readonly CustomerTypeEnumeration LegalEntity = new CustomerTypeEnumeration(2, "Pessoa Jurídica");

        public CustomerTypeEnumeration(int id, string name) : base(id, name) { }

        public static IEnumerable<CustomerTypeEnumeration> List() =>
            new[] { Person, LegalEntity };

        public static CustomerTypeEnumeration FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCulture));

            if (state == null)
            {
                throw new Exception($"Possible values for CustumerType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static CustomerTypeEnumeration FromId(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for CustumerType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
