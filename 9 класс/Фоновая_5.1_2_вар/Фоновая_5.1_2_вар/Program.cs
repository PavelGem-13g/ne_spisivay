using System;
namespace Фоновая_5._1_2_вар
{
    class Vehicle
    {
        protected string title;
        protected double fuelCons;
        protected double fuelTankCap;

        public Vehicle()
        {
            title = "Жигули";
            fuelCons = 11.5;
            fuelTankCap = 60;
        }
        public Vehicle(string title, double fuelCons, double fuelTankCap)
        {
            this.title = title;
            this.fuelCons = fuelCons;
            this.fuelTankCap = fuelTankCap;
        }
        public void output()
        {
            Console.WriteLine("Данные транспортного средства: название {0}, потребление топлива на 100км {1}, объем бака {2}, ", title, fuelCons, fuelTankCap);
        }
        public string Title
        {
            get { return title; }
        }
        public double TravelDis
        {
            get { return fuelTankCap / fuelCons; }
        }
        public double fuelS(double LenRoute)
        {
            return (LenRoute * fuelCons) / 100;
        }

    }
    class Car : Vehicle
    {
        public enum BodyType { Седан = 1, Купе, Хэчбек, Универсал, Кабриолет };
        int bodyType;
        int numPass;

        public Car() : base()
        {
            bodyType = 1;
            numPass = 5;
        }
        public Car(string title, double fuelCons, double fuelTankCap, int bodyType, int numPass) : base(title, fuelCons, fuelTankCap)
        {
            this.bodyType = bodyType;
            this.numPass = numPass;
        }
        new public void output()
        {
            base.output();
            BodyType body = (BodyType)bodyType;
            Console.WriteLine("Данные машины: вид кузова {0}, кол-во пассажиров {1}", body, numPass);
        }
        public int NumPass
        {
            get { return numPass; }
            set { numPass = value; }
        }
        public double proNumPass(double contNum)
        {
            return numPass / contNum * 100;
        }
        new public double fuelS(double carMass, double S)
        {
            return ((carMass + 62 * numPass) * 10 * 0.575 * S) / (0.9 * 43600 * 0.87);
        }

    }
    class Truck : Vehicle
    {
        double carrycap;
        double cargoWeight;
        public Truck() : base("ГАЗель", 10.5, 72)
        {
            carrycap = 1000;
            cargoWeight = 0;
        }
        public Truck(string title, double fuelCons, double fuelTankCap, double carrycap, double cargoWeight) : base(title, fuelCons, fuelTankCap)
        {
            this.carrycap = carrycap;
            this.cargoWeight = cargoWeight;
        }
        new public void output()
        {
            base.output();
            Console.WriteLine("Данные грузвой машины: грузоподъемность {0}, масса груза {1}", carrycap, cargoWeight);
        }
        public double CargoWeight
        {
            set { cargoWeight = value; }
            get { return cargoWeight; }
        }
        public double ProWeight
        {
            get { return cargoWeight / carrycap * 100; }
        }
        new public double fuelS(double carMass, double S)
        {
            return ((carMass + cargoWeight) * 10 * 0.575 * S) / (0.9 * 43600 * 0.87);
        }
    }
    class Bus : Vehicle
    {
        int nunPass;
        int fare;
    }
    class Program
    {
        static Car creatingCar()
        {
            string title=""; double fuelCons=0; double fuelTankCap=0; int bodyType = 0; int numPass=0;
            while(!(title.Length > 0 && fuelCons > 0 && fuelTankCap > 0 && bodyType > 0 && numPass > 0)) 
            {
            try
            {
                Console.Write("Введите название машины ");
                    title = Console.ReadLine();
                    if (title.Length == 0) throw new Exception("Введите название машины");
                Console.Write("Введите расход топлива на 100км ");
                    fuelCons = double.Parse(Console.ReadLine());
                    if (fuelCons < 0) throw new Exception("Это значение не может быть отрицательное число");
                Console.Write("Введите объем топливного бака ");
                    fuelTankCap = double.Parse(Console.ReadLine());
                    if (fuelTankCap < 0 || fuelTankCap > 100) throw new Exception("Ошибка: неверный объем топливного бака (диапазон (1-100))");
                Console.Write("Введите кол-во пассажиров ");
                    numPass = int.Parse(Console.ReadLine());
                    if (numPass<0 || numPass>20) throw new Exception("Ошибка: неверное кол-во пассажиров (диапазон (1-20))");
                Console.Write("Введите вид кузова (Седан = 1, Купе, Хэчбек, Универсал, Кабриолет)");
                    bodyType = int.Parse(Console.ReadLine());
                    if ( bodyType<0  && bodyType > 6) throw new Exception("Ошибка: нет такго типа кузова");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            }
            return new Car(title, fuelCons, fuelTankCap, bodyType, numPass);
        }
        static Truck creatingTruck()
        {
            string title=""; double fuelCons=0; double fuelTankCap=0; int carrycap=0; int cargoWeight=0;
            while (!(title.Length > 0 && fuelCons > 0 && fuelTankCap > 0 && carrycap > 0 && cargoWeight > 0))
            {
                try
                {
                    Console.Write("Введите название машины ");
                    title = Console.ReadLine();
                    if (title.Length == 0) throw new Exception("Введите название машины ");
                    Console.Write("Введите расход топлива на 100км ");
                    fuelCons = double.Parse(Console.ReadLine());
                    if (fuelCons < 0) throw new Exception("Это значение не может быть отрицательное число ");
                    Console.Write("Введите объем топливного бака ");
                    fuelTankCap = double.Parse(Console.ReadLine());
                    if (fuelTankCap < 0 || fuelTankCap > 100) throw new Exception("Ошибка: неверный объем топливного бака (диапазон (1-100)) ");
                    Console.Write("Введите грузоподъемность ");
                    carrycap = int.Parse(Console.ReadLine());
                    if (carrycap < 0 ) throw new Exception("Это значение не может быть отрицательное число ");
                    Console.Write("Введите массу груза ");
                    cargoWeight = int.Parse(Console.ReadLine());
                    if(cargoWeight> carrycap || cargoWeight<0) throw new Exception("Неправельно ввведено число(диапазон(0-грузоподъемность))");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            return new Truck(title, fuelCons, fuelTankCap, carrycap, cargoWeight);
        }
        static void Main(string[] args)
        {
            int choose;
            Console.Write("Создать свою машину - 1, конструктор по умаланию - остальные числа ");
            choose = int.Parse(Console.ReadLine());
            Car car;
            if (choose == 1)
            {
                car = creatingCar();
            }
            else car = new Car();

            car.output();
            int temp = car.NumPass;
            try
            {
                
                Console.Write("Обновите кол-во пассажиров ");
                car.NumPass = int.Parse(Console.ReadLine());
                if (car.NumPass < 0) throw new Exception("Это значение не может быть отрицательным, значение не изменилось");
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
                car.NumPass = temp;
            }
            
            car.output();
            Console.Write("Введите общее кол-во пассажиров ");
            int contNum = int.Parse(Console.ReadLine());
            if (contNum > car.NumPass) Console.WriteLine("Процент загруженности машины {0:F2}%", car.proNumPass(contNum));
            else Console.WriteLine("Вы ввели неправильное зачение ");

            double carMass=0, S=0;bool flag = true;
            while (flag)
            {
                try
                {
                    Console.Write("Введите массу машины ");
                    carMass = double.Parse(Console.ReadLine());
                    if (carMass < 0) throw new Exception("Это значение не может быть отрицательным ");
                    Console.Write("Введите путь ");
                    S = double.Parse(Console.ReadLine());
                    if (S < 0) throw new Exception("Это значение не может быть отрицательным ");
                    flag = false;
                }
                catch(Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            Console.WriteLine("Необходимое кол-во топлива {0:F2}", car.fuelS(carMass, S));



            Console.WriteLine("Создать свою  Грузовую машину - 1, конструктор по умаланию - остальные числа ");
            choose = int.Parse(Console.ReadLine());
            Truck truck;
            if (choose == 1)
            {
                truck = creatingTruck();
            }
            else truck = new Truck();
            truck.output();


            Console.Write("Обновите массу груза ");
            truck.CargoWeight = double.Parse(Console.ReadLine());
            truck.output();
            Console.WriteLine("Процент загруженности грузовой машины {0:F2}%", truck.ProWeight);

            Console.Write("Введите массу грузовой машины ");
            carMass = double.Parse(Console.ReadLine());
            Console.Write("Введите путь ");
            S = double.Parse(Console.ReadLine());
            Console.WriteLine("Необходимое кол-во топлива {0:F2}", truck.fuelS(carMass, S));


            Console.Write("Выберите из чего создать массив, легковая машина - 1, грузовая машина - остальные числа ");
            choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {

                Console.Write("Введите кол-во элементов массива ");
                int k = int.Parse(Console.ReadLine());
                Car[] cars = new Car[k];
                for (int i = 0; i < k; i++)
                {
                    Console.Write("Создать свою машину - 1, конструктор по умаланию - остальные числа ");
                    choose = int.Parse(Console.ReadLine());
                    if (choose == 1)
                    {
                        cars[i] = car = creatingCar();
                    }
                    else cars[i] = new Car();
                }
                for (int i = 0; i < k; i++)
                {
                    cars[i].output();
                }
            }
            else
            {
                Console.WriteLine("Введите кол-во элементов массива ");
                int k = int.Parse(Console.ReadLine());
                Truck[] trucks = new Truck[k];
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine("Создать свою грузовую машину - 1, конструктор по умаланию - остальные числа ");
                    choose = int.Parse(Console.ReadLine());
                    if (choose == 1)
                    {
                        trucks[i] = creatingTruck();
                    }
                    else trucks[i] = new Truck();
                }
                for (int i = 0; i < k; i++)
                {
                    trucks[i].output();
                }
            }
            Console.ReadKey();
        }
    }
}
