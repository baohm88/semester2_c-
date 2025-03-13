using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleApp
{
    // Base class
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public abstract void DisplayInfo();
    }

    // Derived class: Car
    public class Car : Vehicle
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Car]   ID: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}");
        }
    }

    // Derived class: Motor
    public class Motor : Vehicle
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Motor] ID: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}");
        }
    }

    class Program
    {
        static List<Vehicle> vehicles = new List<Vehicle>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nVehicle Management Menu:");
                Console.WriteLine("1. Add a new Car");
                Console.WriteLine("2. Add a new Motor");
                Console.WriteLine("3. Remove a vehicle by ID");
                Console.WriteLine("4. Display all vehicles");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddVehicle(new Car());
                        break;
                    case "2":
                        AddVehicle(new Motor());
                        break;
                    case "3":
                        DisplayAllVehicles();
                        RemoveVehicleById();
                        DisplayAllVehicles();
                        break;
                    case "4":
                        DisplayAllVehicles();
                        break;
                    case "0":
                        Console.WriteLine("\nExiting...");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddVehicle(Vehicle vehicle)
        {
            vehicle.Id = nextId++;

            Console.Write("\nEnter brand: ");
            vehicle.Brand = Console.ReadLine();

            Console.Write("Enter model: ");
            vehicle.Model = Console.ReadLine();

            Console.Write("Enter year: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                vehicle.Year = year;
                vehicles.Add(vehicle);
                Console.WriteLine("\nVehicle added successfully.");
            }
            else
            {
                Console.WriteLine("\nInvalid year. Vehicle not added.");
            }
        }

        static void RemoveVehicleById()
        {
            
            Console.Write("\nEnter vehicle ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var vehicle = vehicles.FirstOrDefault(v => v.Id == id);
                if (vehicle != null)
                {
                    vehicles.Remove(vehicle);
                    Console.WriteLine("\nVehicle removed.");
                }
                else
                {
                    Console.WriteLine("\nVehicle not found.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid ID.");
            }
        }

        static void DisplayAllVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("\nNo vehicles to display.");
                return;
            }

            Console.WriteLine("\nList of existing vehicles:");
            foreach (var v in vehicles)
            {
                v.DisplayInfo();
            }
        }
    }
}
