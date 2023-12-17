using System.Collections.Generic;
using SQLite;

namespace otAleksandrovny
{
    public class CustomerRepository
    {
        SQLiteConnection database;
        public CustomerRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Customer>();
        }
        public IEnumerable<Customer> GetItems()
        {
            return database.Table<Customer>().ToList();
        }
        //public Customer GetItem(int id)
        //{
        //    return database.Get<Customer>(id);
        //}
        //public int DeleteItem(int id)
        //{
        //    return database.Delete<Customer>(id);
        //}
        //public int SaveItem(Customer item)
        //{
        //    if (item.ID == 0)
        //    {
        //        return database.Insert(item);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        public bool LoginValidate(string email, string password)
        {
            var data = database.Table<Customer>();
            var d1 = data.Where(x => x.Email == email && x.Password == password).FirstOrDefault();

            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }
        public bool AddUser(Customer item)
        {
            var data = database.Table<Customer>();
            var d1 = data.Where(x => x.Email == item.Email).FirstOrDefault();
            if (d1 == null)
            {
                database.Insert(item);
                return true;
            }
            else
                return false;
        }
    }
}