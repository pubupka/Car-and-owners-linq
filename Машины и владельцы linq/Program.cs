using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Машины_и_владельцы_linq
{
    /*
     Два класса, первый класс описание машины( идентификатор, цвет, марка)
Второй класс айди машины и владельцы( айди машины, ФИО владельца)
С использованием запросов необходимо:
Выполнить отбор машин по заданной марке,
сгруппировать владельцев по идентификатору машины(машинк- владельцы)
    */
    public class Car
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public Car(int id, string colour, string brand) 
        {
            Id = id; Colour = colour; Brand = brand;
        }
    }

    public class Car_owner
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public Car_owner(int id, string fio)
        {
            Id = id; Fio = fio;
        }
    }

    public class Temp
    {
        public string Fio { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public Temp(string fio, string colour, string brand)
        {
            Fio = fio; Colour = colour; Brand = brand;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car[] carlist =
            {
                new Car(1, "чёрный", "bmw"),
                new Car(2, "белый", "audi"),
                new Car(3, "зелёный", "audi"),
                new Car(4, "жёлтый", "porsche"),
                new Car(5, "синий", "audi"),
                new Car(6, "чёрный", "range rover"),
            };

            Car_owner[] ownerslist =
            {
                new Car_owner(1, "палыч"),
                new Car_owner(2, "михалыч"),
                new Car_owner(3, "кузьмич"),
                new Car_owner(4, "саныч"),
                new Car_owner(5, "сидорыч"),
                new Car_owner(6, "иваныч"),
            };

            Console.WriteLine("Введите марку для выборки (советую написать audi)");
            string brand = Console.ReadLine();
            var Car_by_brand = from car in carlist
                               where car.Brand == brand
                               select car;

            var Owner_by_car = from owner in ownerslist
                               join car in carlist on owner.Id equals car.Id
                               select new Temp(owner.Fio, car.Colour, car.Brand);

            Console.WriteLine("Введите марку для выборки (советую написать audi)");
            foreach (Car car in Car_by_brand)
            {
                Console.WriteLine($"Id: {car.Id}, Цвет: {car.Colour}, Марка: {car.Brand}");
            }

            foreach (Temp owner_by_car in Owner_by_car)
            {
                Console.WriteLine($"Владелец: {owner_by_car.Fio}, Цвет: {owner_by_car.Colour}, Марка: {owner_by_car.Brand}");
            }
            Console.ReadLine();
        }
    }
}
