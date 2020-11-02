using System;
using System.Collections.Generic;
using costumer.api.Infra.SeedWork;

namespace costumer.api.v1.Responses
{
    public class CustomersResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string CompanyName { get; set; }
        public string ZipCode { get; set; }
        public string Stage { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Type { get; set; }

      
        public CustomersResponse(string name, string email, string cpfCnpj, 
            string companyName, string zipCode, int stage, int type, List<string> phones)
        {
            Name = name;
            Email = email;
            CpfCnpj = cpfCnpj;
            CompanyName = companyName;
            ZipCode = zipCode;
            Stage = StageEnumeration.FromId(stage).Name;
            Type = CustomerTypeEnumeration.FromId(type).Name;
            PhoneNumbers = phones;
        }
    }
}