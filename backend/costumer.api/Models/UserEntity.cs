using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace costumer.api.Models
{
    [DataContract]
    public class UserEntity
    {
        [Column]
        [DataMember]
        [Key]
        public string Id { get; set; }
        
        [Column]
        [DataMember]
        public string Email { get; set; }

        [Column]
        [DataMember]
        public string Password { get; set; }
    }
}
