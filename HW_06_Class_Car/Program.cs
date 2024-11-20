using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HW_06_Class_Car
{
    class Garage
    {
        Car[] carsArray = new Car[0];
        Car emptyObj = new Car();
        public Garage()
        {
            Array.Resize<Car>(ref carsArray, carsArray.Length + 1);
            carsArray[0] = new Car(); //Initialization of the cell with empty objects

            carsArray[0].carNumber = 1111;
            carsArray[0].carModel = "c"; //"Tesla";
            carsArray[0].carPrice = 150000;

            Array.Resize<Car>(ref carsArray, carsArray.Length + 1);
            emptyObj = new Car(); //Initialization of the fields of the object zeros
            carsArray[1] = new Car(); //Initialization of the cell with an empty object

            carsArray[1].carNumber = 2222;
            carsArray[1].carModel = "w";//"Nissan";
            carsArray[1].carPrice = 150000;
        }

        public Garage(int number, string model, float price)
        {
           // Array.Resize<Car>(ref carsArray, carsArray.Length + 1);
            AddCar(number, model, price);
        }

        public void AddCar(int number, string model, float price)
        {
            Array.Resize<Car>(ref carsArray, carsArray.Length + 1);
            carsArray[carsArray.Length-1] = new Car(); //Initialization of the cell with an empty object

            carsArray[carsArray.Length - 1].carNumber = number;
            carsArray[carsArray.Length - 1].carModel = model;
            carsArray[carsArray.Length - 1].carPrice = price;
        }
        public void AddCar(ref Car[]CarsArray, int number, string model)
        {
            Array.Resize<Car>(ref carsArray, carsArray.Length + 1);
            for (int i = 0; i < carsArray.Length; i++)
            {
                carsArray[i] = new Car();
            }
            
            carsArray[carsArray.Length - 1].carNumber = number;
            carsArray[carsArray.Length - 1].carModel = model;
        }

        public void RemoveCar(int number) //!
        {
            for (int j = 0; j < carsArray.Length && carsArray.Length != 0; j++)
            {
                if ((carsArray[j]).carNumber == number)
                {
                    int i = 0;
                    Car buf = new Car();

                    for ( ;i < carsArray.Length - 1 - j; i++)
                    {
                        buf = carsArray[j];
                        carsArray[i] = carsArray[i+1];
                    }
                    carsArray[carsArray.Length - 1] = buf;
                    Array.Resize<Car>(ref carsArray, carsArray.Length - 1);
                    Console.WriteLine($"Deleting is completed! The Car with this number '{buf.carNumber}' has been deleted!");
                }
                else if(j == carsArray.Length-1)
                {
                    if (j == carsArray.Length-1)
                    {
                        throw new Exception($"Exception! Removal not completed! There is no car with this number: '{number}' in the array of cars!!!");

                    }
                    else
                    {
                        Console.WriteLine("Deleting is completed!");
                    }
                }

            }
        }
        
        public void SortCarsByNumber()
        {
            for (int j = 0; j < carsArray.Length; j++)
            {
                for (int i = 0; i < carsArray.Length - 1 - j; i++)
                {
                    if (carsArray[i + 1].carNumber < carsArray[i].carNumber)
                    {
                        Car buf = carsArray[i + 1];
                        carsArray[i + 1] = carsArray[i];
                        carsArray[i] = buf;
                    }
                }
            }
        }

        public void SortCarsByModel()
        {
            for (int j = 0; j < carsArray.Length; j++)
            {
                for (int i = 0; i < carsArray.Length - 1 - j; i++)
                {
                    if (string.Compare(carsArray[i].carModel, carsArray[i + 1].carModel) > 0)
                    {
                        Car buf = carsArray[i + 1];
                        carsArray[i + 1] = carsArray[i];
                        carsArray[i] = buf;
                    }
                }
            }
        }

        public void SortCarsByPrice()
        {
            for (int j = 0; j < carsArray.Length; j++)
            {
                for (int i = 0; i < carsArray.Length - 1 - j; i++)
                {
                    if (carsArray[i + 1].carPrice < carsArray[i].carPrice)
                    {
                        Car buf = carsArray[i + 1];
                        carsArray[i + 1] = carsArray[i];
                        carsArray[i] = buf;
                    }
                }
            }
        }

        public void GarageInfo()
        {
            for (int i = 0; i < carsArray.Length; i++)
            {
                Console.WriteLine($"\n========= Car: {i} =========\n");
                carsArray[i].CarInfo();
            }
        }
    }
    class Car
    {
        public int carNumber;
        public string carModel;
        public float carPrice;

        public Car()
        {
            carNumber = 0;
            carModel = "";
            carPrice = 0;
        }      
        
        public Car(int carNumber, string carModel, float carPrice)
        {
            this.carNumber = carNumber;
            this.carModel = carModel;
            this.carPrice = carPrice;

        }

        public void CarInfo()
        {
            Console.WriteLine($"Car number: {carNumber}");
            Console.WriteLine($"Car model:  {carModel}");
            Console.WriteLine($"Car price:  {carPrice}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Задание

                1.	Разработать класс Car, описывающий автомобиль
                2.	Класс должен включать конструктор с параметрами,
            конструктор без параметров, поля, необходимые для описания 
            автомобиля.
                3.	Создать класс, который будет содержать
            массив экземпляров класса Car.

                Создать методы сортировки автомобилей по названию и по цене,
            методы для работы с данными (добавление, удаление),
            продемонстрировать работу этих методов.

            */

            Garage garage_obj = new Garage();

            int menu = 0;
            int number = 0;
            string model = "";
            float price = 0;

            do
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine($"\n   Select operation: ");
                Console.WriteLine($"1. Show garage: ");
                Console.WriteLine($"2. Add a car to garage: ");
                Console.WriteLine($"3. Sorting of cars by number: ");
                Console.WriteLine($"4. Sorting of cars by model: ");
                Console.WriteLine($"5. Sorting of cars by price: ");
                Console.WriteLine($"6. Deleting a car by number: ");
                Console.WriteLine("=============================\n");

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:

                        garage_obj.GarageInfo();
                        break;

                    case 2:

                        Console.WriteLine("Enter the car number: ");
                        number = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the car model: ");
                        model = Console.ReadLine();

                        Console.WriteLine("Enter the car price: ");
                        price = int.Parse(Console.ReadLine());

                        garage_obj.AddCar(number, model, price);
                        Console.WriteLine("Addition is completed!");
                        break;

                    case 3:

                        garage_obj.SortCarsByNumber();
                        Console.WriteLine("Sorting is completed!");
                        break;

                    case 4:

                        garage_obj.SortCarsByModel();
                        Console.WriteLine("Sorting is completed!");
                        break;

                    case 5:

                        garage_obj.SortCarsByPrice();
                        Console.WriteLine("Sorting is completed!");
                        break;

                    case 6:

                        Console.WriteLine("Enter the car number for deleting: ");
                        number = int.Parse(Console.ReadLine());

                        try
                        {
                            garage_obj.RemoveCar(number);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        //Console.WriteLine("Enter the car number for deleting: ");
                        //number = int.Parse(Console.ReadLine());
                        //garage_obj.RemoveCar(number);
                        //Console.WriteLine("Deleting is completed!");
                        break;

                    default:
                        break;
                }

            } while (menu != 0);

           

           

            Console.ReadKey();
        }
    }
}
