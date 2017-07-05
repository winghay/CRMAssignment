using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Repositories;
using System.Data.Entity;

namespace CRM.Managers
{
    public class CustomerManager
    {
        public List<Customer> GetCustomerList()
        {            
            using (var db = new TestEntities())
            {
                return db.Customers.Where(c => c.Deleted == false).ToList();
            }
        }

        public void AddCustomer(string firstName, string lastName, string contact)
        {
            using (var db = new TestEntities())
            {
                db.Customers.Add(new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Contact = contact
                });
                db.SaveChanges();
            }
        }

        public void UpdateCustomer(int customerId, string firstName, string lastName, string contact)
        {
            using (var db = new TestEntities())
            {
                Customer updateCustomer = new Customer
                {
                    CustomerId = customerId,
                    FirstName = firstName,
                    LastName = lastName,
                    Contact = contact,
                    Deleted = false
                };
                db.Customers.Attach(updateCustomer);
                var entry = db.Entry(updateCustomer);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var db = new TestEntities())
            {
                Customer deleteCustomer = db.Customers.Find(customerId);
                deleteCustomer.Deleted = true;
                db.Customers.Attach(deleteCustomer);
                var entry = db.Entry(deleteCustomer);
                entry.Property(d => d.Deleted).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}