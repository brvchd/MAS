using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP02.WITH_ATTRIBUTE
{
    public class Example
    {
        public static void Main(string[] args)
        {
            Employee emp = new("Dmytro", "Borovych", new DateTime(2021,10,10),"Junior","SWQA");
            Asset phone = new("SM-960F", "Flagship");
            Request request1 = new(phone, "Change application", new DateTime(2021, 10, 10), "For testing purposes", new DateTime(2022, 10, 10), emp);
            emp.RemoveRequest(request1);
            Employee emp2 = new("Vladyslav", "Kutsenko", new DateTime(2021, 11, 11), "Intern", "DACL");
            //emp2.AddRequest(request1); //error will come up
            //Request request2 = new(phone, "Change application", new DateTime(2021, 10, 10), "For testing purposes", new DateTime(2022, 10, 10), emp2); //duplicate association
            Asset phone2 = new("SM-961F", "Flaship");
            Request request2 = new(phone2, "Change application", new DateTime(2021, 10, 10), "For testing purposes", new DateTime(2022, 10, 10), emp2);


        }
    }
}
