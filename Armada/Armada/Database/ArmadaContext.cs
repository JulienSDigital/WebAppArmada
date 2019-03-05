using Armada.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Database
{
    public class ArmadaContext : DbContext // DropCreateDatabaseAlways
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ArmadaDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ArmadaDB2;Trusted_Connection=True;");
        }

        public void Init()
        {

            if (Users.Any())
            {
                return;
            }

            Users.AddRange(

            new List<User>()
                {
                    new User() {UserName = "clement22", Password = "password", Surname = "surname", Mail = "mail",
                        Messages = new List <Message> ()
                            {
                                new Message() { MessageDateCreate =  DateTime.Now ,Content = "blablala2" },
                                new Message() { MessageDateCreate =  DateTime.Now ,Content = "test222" },
                                new Message() { MessageDateCreate =  DateTime.Now ,Content = "apero :D222" }
                            },
                        },

                    new User() {UserName = "Test22", Password = "password", Surname = "surname", Mail = "mail"},
                    new User() {UserName = "Raida2", Password = "password", Surname = "surname", Mail = "mail"},
                    new User() {UserName = "Kiwi2", Password = "password", Surname = "surname", Mail = "mail"}

                });
            SaveChanges();
        }
    };
}
