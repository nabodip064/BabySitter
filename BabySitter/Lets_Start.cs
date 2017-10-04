using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BabySitter
{
    class Lets_Start
    {
        List<Employee> emplyList = new List<Employee>();
        List<Child> childlist = new List<Child>();
        List<Emergency> emernecylist = new List<Emergency>();

        public void initialize()
        {
            //string name = stringInput();
            //string address = stringInput();
            //int number = input();
            emplyList.Add(new Employee(){name = "Narayan", phone_number = 01715455759, address = "Saturia", id = 0});
            emplyList.Add(new Employee() {name = "Arun", phone_number = 0172368544, address = "Dhaka", id = 1});
            emplyList.Add(new Employee() { name = "Amit", phone_number = 0181452145, address = "Manikgonj" , id = 2});

            childlist.Add(new Child() { id = 0, name = "Abir", health = "good", interest = "playing" });
            childlist.Add(new Child() { id = 0, name = "Nabodip", health = "good", interest = "playing" });
            childlist.Add(new Child() { id = 1, name = "Akash", health = "not good", interest = "working" });
            childlist.Add(new Child() { id = 1, name = "Zaman", health = "good", interest = "riding" });
            childlist.Add(new Child() { id = 2, name = "Modon da", health = "good", interest = "playing" });
            childlist.Add(new Child() { id = 2, name = "Modna", health = "mideum", interest = "studying" });

            emernecylist.Add(new Emergency() {id = 0,name = "Tusar",phone_number = 0182345678, relationship = "friend" });
            emernecylist.Add(new Emergency() { id = 1, name = "Hannan", phone_number = 0187895642, relationship = "Father" });
            emernecylist.Add(new Emergency() { id = 2, name = "Adib", phone_number = 01925575656, relationship = "uncle" });
        }

        public void disp()
        {
            Console.WriteLine();
            foreach (var item in emplyList)
            {
                Console.WriteLine("{0}  {1}", item.id, item.name);
            }
            Console.WriteLine("Enter 1 for show details\nEnter 2 delete\nEnter 3 for Add");
            int test = input();
            if (test == 1)
                details();
            else if (test == 2)
                delete();
            else if (test == 3)
                add();
            else
            {
                Console.WriteLine("Invalid input....");
                disp();
            }
        }
        private void details()
        {
            Console.WriteLine("Enter the serial number which you want to show");
            var idn = input();
            Console.WriteLine("Name Number  Address");
            foreach (var it in emplyList)
            {
                if (it.id == idn)
                {
                    Console.WriteLine("{0}      {1}     {2}", it.name, it.phone_number, it.address);
                    break;
                }
            }
            Console.WriteLine("For emergecy contact\nName Number RelationShip");
            foreach(var it in emernecylist)
            {
                if(it.id == idn)
                {
                    Console.WriteLine("{0}      {1}     {2}", it.name, it.phone_number, it.relationship);
                    break;
                }
            }
            Console.WriteLine("Children are....\nName Health Interest");
            foreach (var it in childlist)
            {
                if (it.id == idn)
                    Console.WriteLine("{0}      {1}     {2}", it.name, it.health, it.interest);
            }
            disp();
        }
        private void add()
        {
            Console.WriteLine("Enter name");
            var names = stringInput();
            Console.WriteLine("Enter address");
            var addrs = stringInput();
            Console.WriteLine("Enter number");
            var nmbr = input();
            var idn = emernecylist.Count;
            emplyList.Add(new Employee(){id = idn, name = names, address = addrs, phone_number = nmbr});

            Console.WriteLine("Enter emergecy contact...");
            Console.WriteLine("For emergecy enter name");
            var nameEmg = stringInput();
            Console.WriteLine("Enter relationship");
            var relation = stringInput();
            Console.WriteLine("Enter number");
            var nmbrEmg = input();
            emernecylist.Add(new Emergency() {id = idn, name = nameEmg, phone_number = nmbrEmg, relationship = relation });

            Console.WriteLine("Enter for your children...");
            while (true)
            {
                Console.WriteLine("Enter your child name");
                var nameChld = stringInput();
                if (nameChld == "")
                    break;
                Console.WriteLine("Enter your child health");
                var health = stringInput();
                Console.WriteLine("Enter your child interesting");
                var interesting = stringInput();
                childlist.Add(new Child() { id = idn, name = nameChld, health = health, interest = interesting});
            }
            disp();
        }

        private void delete()
        {
            Console.WriteLine("Enter serial number");
            var ids = input();
            var idn = getItem(ids);
            if(idn != null)
            {
                emplyList.Remove(idn);
                childlist.Remove(childItem(ids));
                emernecylist.Remove(emItem(ids));
            }
            disp();
        }

        private Employee getItem(int idn)
        {
            foreach (var it in emplyList)
            {
                if (it.id == idn)
                    return it;
            }
            return null;
        }
        private Child childItem(int idn)
        {
            foreach (var it in childlist)
            {
                if (it.id == idn)
                    return it;
            }
            return null;
        }
        private Emergency emItem(int idn)
        {
            foreach (var it in emernecylist)
            {
                if (it.id == idn)
                    return it;
            }
            return null;
        }
        private string stringInput()
        {
            string str = null;
            try
            {
                str = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return str;
        }

        private int input()
        {
            int n = 0;
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return n;
        }
    }
}
