using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace costumer.api.Models
{
    [DataContract]
    public class CustomerEntity
    {
        // adicionar data annotations
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
    }
}
