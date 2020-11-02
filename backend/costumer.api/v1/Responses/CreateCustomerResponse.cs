
namespace costumer.api.v1.Responses
{
    public class CreateCustomerResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string Type { get; set; }
        public string Stage { get; set; }

        public CreateCustomerResponse(string name, string email, string cpfCnpj, string type, string stage)
        {
            Name = name;
            Email = email;
            CpfCnpj = cpfCnpj;
            Type = type;
            Stage = stage;
        }
    }
}
