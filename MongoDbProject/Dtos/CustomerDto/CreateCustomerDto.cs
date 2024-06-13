using MongoDbProject.Entities;

namespace MongoDbProject.Dtos.CustomerServices
{
    public class CreateCustomerDto
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
