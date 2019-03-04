using Armada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Database
{
    public class DataStore
    {
        public static List<User> Users = new List<User>()
        {
            new User() {UserID = 1, UserName = "clement",
                Messages = new List <Message> ()
                    {
                        new Message() { MessageID = 1,MessageDateCreate =  DateTime.Now ,Content = "blablala" },
                        new Message() { MessageID = 2,MessageDateCreate =  DateTime.Now ,Content = "test" },
                        new Message() { MessageID = 3,MessageDateCreate =  DateTime.Now ,Content = "apero :D" }
                    },
                },

            new User() {UserID = 2, UserName = "Test"},
            new User() {UserID = 3, UserName = "Raida"},
            new User() {UserID = 4, UserName = "Kiwi"}

        };
    }
}
