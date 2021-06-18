using System;
using API.Interface;

namespace API.service
{
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
           Console.WriteLine($"my dependency.writemessage called. Message : {message}");
        }
    }
}