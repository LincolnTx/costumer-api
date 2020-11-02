using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace costumer.api.Models
{
    [DataContract]
    public class CustomerEntity
    {
        [Column]
        [DataMember]
        [Key]
        public string Id { get; set; }

        [Column]
        [DataMember]
        public string Name { get; set; }

        [Column]
        [DataMember]
        public string Email { get; set; }

        [Column]
        [DataMember]
        public string CpfCnpj { get; set; }

        [Column]
        [DataMember]
        public string CompanyName { get; set; }

        [Column]
        [DataMember]
        public string ZipCode { get; set; }

        [Column]
        [DataMember]
        public int Stage { get; set; }

        [Column]
        [DataMember]
        public List<Phones> PhoneNumbers { get; set; }

        [Column]
        [DataMember]
        public int Type { get; set; }

        protected CustomerEntity()
        {

        }
        public CustomerEntity(string name, string email, string cpfCnpj, 
            string companyName, string zipCode, int stage, List<string> phones, int type )
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
            CpfCnpj = cpfCnpj;
            CompanyName = companyName;
            ZipCode = zipCode;
            Stage = stage;
            Type = type;
            InitializePhones(phones);
        }

        private void InitializePhones(List<string> phones)
        {
            PhoneNumbers = new List<Phones>();
            
            phones.ForEach(phone =>
            {
                var newPhone = new Phones(phone, Id);
                PhoneNumbers.Add(newPhone);
            });
        }
    }
}
