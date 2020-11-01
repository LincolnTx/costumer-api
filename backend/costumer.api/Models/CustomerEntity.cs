using System.Collections.Generic;

namespace costumer.api.Models
{
    public class CustomerEntity
    {
        // adicionar data annotations
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string CompanyName { get; set; }
        public string ZipCode { get; set; }
        public int Stage { get; set; }
        public List<string> Phone { get; set; }
        public int Type { get; set; }
    }
}
