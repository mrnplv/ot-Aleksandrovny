using SQLite;


namespace otAleksandrovny
{
    [Table("Customers")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int ID { get; set; }
        public string Name { get; set; }
        [Unique]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}

