﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InterfacesIntro();

            //IPerson person = new IPerson(); Interfaces'ler newlenmez.

            //Demo();

            ICustomerDal[] customerDals = new ICustomerDal[3]
            {
                new SqlServerCustomerDal(),
                new OracleServerCustomerDal(),
                new MySqlCustomerDal()
            };

            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }
            Console.ReadLine();
        }

        private static void Demo()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new OracleServerCustomerDal());
        }

        private static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            Customer customer = new Customer // Bu da yapılabilir.
            {
                Id = 1,
                FirstName = "Engin",
                LastName = "Demiroğ",
                Address = "Demiroğ"
            };

            Student student = new Student
            {
                Id = 1,
                FirstName = "Derin",
                LastName = "Demiroğ",
                Department = "Computer Sciences"
            };
            manager.Add(customer);
            manager.Add(student);
        }
    }
    interface IPerson 
    {
        int Id { get; set; } 
        string FirstName { get; set; }
        string LastName { get; set; }

    }
    class Customer : IPerson 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; } //Müşteriye ait ayrıca bir özellik.
    }
    class Student : IPerson 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; } //Öğrenciye ait ayrıca bir özellik.
    }
    class Worker : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
    class PersonManager
    {
        public void Add(IPerson person) 
        {
            Console.WriteLine(person.FirstName);
        }
    }
}
