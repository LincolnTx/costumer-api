namespace costumer.api.v1.Responses
{
    public class DeleteCustomerResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string Type { get; set; }

        public DeleteCustomerResponse(string name, string email, string cpfCnpj, string type)
        {
            Name = name;
            Email = email;
            CpfCnpj = cpfCnpj;
            Type = type;
        }
    }
}