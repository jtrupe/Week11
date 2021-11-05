/// Week 11 Project 1
///
/// @author: Julian Trupe
/// Date:  November 4, 2021
///
/// Problem Statement: Create a Vehicle class with owner (Person class), cylinders, manufacturer properties
///                     Create Truck class derived from Vehicle with additional properties towCapacity and loadCapacity
//
/// Overall Plan:
/// 1) Create Person class, Vehicle class, Truck class derived from Vehicle
/// 2) Create getters/setters only in classes which require(Truck doesnt need getter/setters for Vehicle properties)
/// 3) Override ToString methods to print class properties to the console
/// 4) Create Equals method which returns true if all corresponding properties of a class object are equal
/// 5) In the main method create at least two of each class, test Equals and ToString methods


using System;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Below we will test our classes");
            Person person1 = new Person();
            Person person2 = new Person();
            Console.WriteLine(person1.Equals(person2));
            Vehicle car1 = new Vehicle();
            Vehicle car2 = new Vehicle("John Doe", 0, 4);
            Console.WriteLine(car1.Equals(car2));
            Truck truck1 = new Truck();
            Truck truck2 = new Truck(1, 1000);
            Truck truck3 = new Truck("Julian Trupe", Vehicle.manufacturer.Toyota, 6, 10, 2000);
            truck3.ToString();
            Console.WriteLine(truck1.Equals(truck2));
            Console.WriteLine(truck1.Equals(truck3));
            truck1.ToString();
            car1.ToString();
            person1.ToString();
        }
    }

    public class Vehicle
    {
        public enum manufacturer { Ford, Toyota, Honda };
        protected manufacturer manuName;
        protected int cylinders;
        protected Person owner;

        public Vehicle()
        {
            owner = new Person();
            manuName = 0;
            cylinders = 4;
        }

        public Vehicle(string name, manufacturer manu, int cyl)
        {
            owner = new Person(name);
            manuName = manu;
            cylinders = cyl;
        }

        protected void SetManuName(manufacturer name)
        {
            manuName = name;
        }
        protected manufacturer GetManuName()
        {
            return manuName;
        }
        protected void SetCylinders(int cyl)
        {
            cylinders = cyl;
        }
        protected int GetCylinders()
        {
            return cylinders;
        }

        public void ToString()
        {
            Console.WriteLine(owner.GetName() + "'s " + GetManuName() + " vehicle has " + GetCylinders() + " cylinders");
        }

        public bool Equals(Vehicle car)
        {
            return (car.owner.Equals(owner) && car.GetManuName() == manuName && car.GetCylinders() == cylinders);
        }


    }

    public class Truck : Vehicle
    {
        private double loadTons;
        private int towCapacity;

        public Truck()
        {
            owner = new Person();
            loadTons = 1;
            towCapacity = 1000;
            SetCylinders(4);
            SetManuName(0);

        }
        public Truck(double load, int tow)
        {
            owner = new Person();
            loadTons = load;
            towCapacity = tow;
            SetCylinders(4);
            SetManuName(0);
        }
        public Truck(string ownerName, manufacturer make, int cyl, double load, int tow)
        {
            owner = new Person(ownerName);
            SetManuName(make);
            SetCylinders(cyl);
            SetLoad(load);
            SetTow(tow);
        }

        public void SetLoad(double num)
        {
            loadTons = num;
        }
        public double GetLoad()
        {
            return loadTons;
        }
        public void SetTow(int num)
        {
            towCapacity = num;
        }
        public int GetTow()
        {
            return towCapacity;
        }

        public void ToString()
        {
            Console.WriteLine(owner.GetName() + "'s " + GetManuName() + " truck has " + GetCylinders() + " cylinders, " + GetLoad() + " ton load capacity, and " + GetTow() + " pound tow capacity");
        }
        public bool Equals(Truck car)
        {
            return (car.owner.Equals(owner) && manuName==car.GetManuName() && cylinders==car.GetCylinders() && loadTons==car.GetLoad() && towCapacity==car.GetTow());
        }
    }

    public class Person
    {
        private string name;

        public Person()
        {
            name = "John Doe";
        }
        public Person(string parName)
        {
            name = parName;
        }
        public Person(Person person)
        {
            name = person.name;
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string parName)
        {
            name = parName;
        }
        public string ToString()
        {
            Console.WriteLine(name);
            return name;
        }
        public bool Equals(Person person)
        {
            return name == person.name;
        }
    }
}
