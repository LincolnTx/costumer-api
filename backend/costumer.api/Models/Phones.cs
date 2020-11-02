using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace costumer.api.Models
{
    [DataContract]
    public class Phones
    {
        [Column]
        [DataMember]
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        [Column]
        [DataMember]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerEntity Customer { get; set; }

        protected Phones()
        {

        }
        public Phones(string number, string customerId)
        {
            PhoneNumber = number;
            CustomerId = customerId;
        }
    }
}
