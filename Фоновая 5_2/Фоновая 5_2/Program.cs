using System;


namespace Фоновая_5_2
{
    class CargoVehicles
    {
        protected string name;
        protected int mass;
        protected int powerReserve;
        protected int carryCap;
        protected int cargoMass;
        protected string Name
        {
            get { return name; }
        }
        protected CargoVehicles(string name, int mass, int powerReserve, int carryCap, int cargoMass)
        {
            this.name = name;
            this.mass = mass;
            this.powerReserve = powerReserve;
            this.carryCap = carryCap;
            this.cargoMass = cargoMass;
        }
        virtual public void output()
        {
            Console.WriteLine("Название ТС {0}, масса ТС {1}, запас хода {2}, грузопдъёмность {3}, масса груза {4}", name, mass, powerReserve, carryCap, mass);
        }
        protected CargoVehicles()
        {
            name = "Грузовая машина";
            mass = 5;
            powerReserve = 500;
            carryCap = 1000;
            cargoMass = 500;
        }
        virtual public void Description()
        {
            Console.WriteLine("Это Description класса - одителя");
        }
        virtual public int fullMass
        {
            get { return mass + cargoMass; }
        }
        public int CarryCap
        {
            get { return carryCap; }
        }
        virtual public int CargoMass
        {
            get { return cargoMass; }
            set { cargoMass = value; }
        }
        virtual public void fuelS(int benzMass)
        {
            double kpd = double.Parse(Console.ReadLine());
            Console.WriteLine((43600d * benzMass * kpd) / (fullMass * 10 * 0.87d));
        }
    }

    enum Transmission { задний = 1, передний, полный };


    class RollingVehicles : CargoVehicles
    {
        protected int wheel;
        protected Transmission transmission;
        override public void output()
        {
            base.output();
            Console.WriteLine(", кол-во колес {0}", wheel);
        }
        public override int fullMass
        {
            get { return mass + cargoMass; }
        }
        protected RollingVehicles() : base()
        {
            wheel = 4;
        }
        protected RollingVehicles(string name, int mass, int powerReserve, int carryCap, int cargoMass, int wheel) : base(name, mass, powerReserve, carryCap, cargoMass)
        {
            this.wheel = wheel;
        }

        public override void fuelS(int benzMass)
        {
            double koef;
            koef = Convert.ToDouble(Console.ReadLine());
            double kpd = double.Parse(Console.ReadLine());
            Console.WriteLine((kpd * 43600d * benzMass * kpd) / (fullMass * 10 * 0.87d));
        }
    }
    class Train : RollingVehicles
    {
        int wagonsNumber;
        override public void output()
        {
            base.output();
            Console.Write(", кол-во вагонов {0} \n", wagonsNumber);
            Console.WriteLine("_________________________________________________________________________________________________________");
        }
        public Train() : base()
        {
            wagonsNumber = 0;
        }
        public Train(string name, int mass, int powerReserve, int carryCap, int cargoMass, int wheel, int wagonsNumber) : base(name, mass, powerReserve, carryCap, cargoMass, wheel)
        {
            this.wagonsNumber = wagonsNumber;
        }
        override public int fullMass
        {
            get
            {
                return mass + cargoMass + 70 + 600 * wheel + wagonsNumber * 23000;
            }
        }
        override public void Description()
        {
            Console.WriteLine("Грузовой поезд — группа грузовых вагонов во главе с локомотивом. Поезд предназначен для перевозки грузов. Устаревшее название — товарный поезд, в просторечии товарняк.");
        }
        public override int CargoMass
        {
            get { return cargoMass; }
        }
        public override void fuelS(int benzMass)
        {
            double ro, lamdda;
            lamdda = Convert.ToDouble(Console.ReadLine());
            double kpd = double.Parse(Console.ReadLine());
            Console.WriteLine((lamdda * benzMass * kpd) / (fullMass * 10 * 0.87d));
        }
    }
    class Truck : RollingVehicles
    {
        protected int drivers;
        override public void output()
        {
            base.output();
            Console.WriteLine(", кол-во водителей {0}", drivers);
        }
        public Truck() : base()
        {
            drivers = 1;
        }
        public Truck(string name, int mass, int powerReserve, int carryCap, int cargoMass, int wheel, int drivers) : base(name, mass, powerReserve, carryCap, cargoMass, wheel)
        {
            this.drivers = drivers;
        }

        override public void Description()
        {
            Console.WriteLine("Грузовой автомобиль — автомобиль, предназначенный для перевозки грузов в кузове или на грузовой платформе. ");
        }
        override public int fullMass
        {
            get
            {
                return mass + cargoMass + 5 * wheel + 70 * drivers;
            }
        }
        public override void fuelS(int benzMass)
        {
            double ro = 0, lamdda = 0; double kpd = 0; double koefTreniya = 0; double g = 0;
            do
            {
                try
                {
                    //этот код был написан ьез использования мыши
                    Console.Write("Введите удельную теплоту сгорания ");
                    lamdda = Convert.ToDouble(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите КПД двигателя ");
                    kpd = double.Parse(Console.ReadLine()); if (kpd < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите коэф трения ");
                    koefTreniya = double.Parse(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите g ");
                    g = double.Parse(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

            } while (!(lamdda > 0d && kpd > 0 && koefTreniya > 0 && g > 0));
            Console.WriteLine("Запас хода рвен {0:F2}", (lamdda * benzMass * kpd) / (fullMass * g * koefTreniya));
        }
    }
    class PickUp : Truck
    {
        bool isPass;
        public PickUp() : base()
        {
            isPass = true;
        }
        public PickUp(string name, int mass, int powerReserve, int carryCap, int cargoMass, int wheel, int drivers, bool isPass) : base(name, mass, powerReserve, carryCap, cargoMass, wheel, drivers)
        {
            this.isPass = isPass;
        }
        override public void output()
        {
            base.output();
            if (isPass) Console.WriteLine(", пассажиры есть");
            else Console.WriteLine(", пассажиров нет");
            Console.WriteLine("_________________________________________________________________________________________________________");

        }
        override public int fullMass
        {
            get
            {
                if (isPass) return mass + 5 * wheel + cargoMass + 280 + 70 * drivers;
                else return mass + cargoMass;
            }
        }
        override public void fuelS(int benzMass)
        {
            double ro = 0, lamdda = 0; double kpd = 0; double koefTreniya = 0; double g = 0;
            do
            {
                try
                {
                    //этот код был написан ьез использования мыши
                    Console.Write("Введите удельную теплоту сгорания ");
                    lamdda = Convert.ToDouble(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите КПД двигателя ");
                    kpd = double.Parse(Console.ReadLine()); if (kpd < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите коэф трения ");
                    koefTreniya = double.Parse(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите g ");
                    g = double.Parse(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

            } while (!(lamdda > 0d && kpd > 0 && koefTreniya > 0 && g > 0));
            Console.WriteLine("Запас хода рвен {0:F2}", (lamdda * benzMass * kpd) / (fullMass * g * koefTreniya));
        }
        override public void Description()
        {
            base.Description();
            Console.WriteLine("Пикап — легкий грузовик с закрытой кабиной и открытой грузовой площадкой с невысокими сторонами и задней дверью");
        }
    }
    class ExtraTruck : Truck
    {
        int tanksNum;
        public ExtraTruck() : base()
        {
            tanksNum = 1;
        }
        public ExtraTruck(string name, int mass, int powerReserve, int carryCap, int cargoMass, int wheel, int drivers, int tanksNum) : base(name, mass, powerReserve, carryCap, cargoMass, wheel, drivers)
        {
            this.tanksNum = tanksNum;
        }
        override public void output()
        {
            base.output();
            Console.WriteLine(", кол-во вагончиков {0}", tanksNum);
            Console.WriteLine("_________________________________________________________________________________________________________");

        }
        override public void Description()
        {
            base.Description();
            Console.WriteLine("Большегруз — транспортное средство для перевозки тяжёлых грузов.");
        }
        override public int fullMass
        {
            get
            {
                return mass + cargoMass + 280 + 5 * wheel + 70 * drivers + tanksNum * 400;
            }
        }
        override public void fuelS(int benzMass)
        {
            double ro = 0, lamdda = 0; double kpd = 0; double koefTreniya = 0; double g = 0;
            do
            {
                try
                {
                    //этот код был написан ьез использования мыши
                    Console.Write("Введите удельную теплоту сгорания ");
                    lamdda = Convert.ToDouble(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите КПД двигателя ");
                    kpd = double.Parse(Console.ReadLine()); if (kpd < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите коэф трения ");
                    koefTreniya = double.Parse(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                    Console.Write("Введите g ");
                    g = double.Parse(Console.ReadLine()); if (lamdda < 0) throw new Exception("Это значение не может быть отрицательным");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

            } while (!(lamdda > 0d && kpd > 0 && koefTreniya > 0 && g > 0));
            Console.WriteLine("Запас хода рвен {0:F2}", (lamdda * benzMass * kpd) / (fullMass * g * koefTreniya));
        }
    }
    class Program
    {
        public static ExtraTruck CreatingExtraTruck()
        {
            int choose = 0;
            do { try { Console.Write("Конструктор по умолчанию - 1, своё ТС - 2 "); choose = int.Parse(Console.ReadLine()); if (!(0 < choose && choose < 3)) throw new Exception("Введите чило в дапазоне 1-2"); } catch (Exception error) { Console.WriteLine(error.Message); } } while (!(0 < choose && choose < 3));
            if (choose == 2)
            {
                string name = ""; int mass = 0; int powerReserve = 0; int carryCap = 0; int cargoMass = 0; int wheel = 0; int drivers = 0; int tanksNum = 0;
                do
                {
                    try
                    {
                        Console.Write("Название ");
                        name = Console.ReadLine(); if (name.Length == 0) throw new Exception("Введите название");
                        Console.Write("Масса ");
                        mass = int.Parse(Console.ReadLine()); if (mass < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Запас хода ");
                        powerReserve = int.Parse(Console.ReadLine()); if (powerReserve < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Грузоподъемность ");
                        carryCap = int.Parse(Console.ReadLine()); if (carryCap < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Масса груза ");
                        cargoMass = int.Parse(Console.ReadLine()); if (cargoMass < 0 || carryCap <= cargoMass) throw new Exception("Это значение не может быть отрицательным или больше грузоподъемности");
                        Console.Write("Кол-во колесов ");
                        wheel = int.Parse(Console.ReadLine()); if (wheel < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Кол-во водителей ");
                        drivers = int.Parse(Console.ReadLine()); if (drivers < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Кол-во вагончиков ");
                        tanksNum = int.Parse(Console.ReadLine()); if (tanksNum < 0) throw new Exception("Это значение не может быть отрицательным");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }

                } while (!(name.Length > 0 && mass > 0 && powerReserve > 0 && carryCap > 0 && cargoMass > 0 && wheel > 0 && drivers > 0 && tanksNum > 0));
                return new ExtraTruck(name, mass, powerReserve, carryCap, cargoMass, wheel, drivers, tanksNum);
            }
            else
            {
                return new ExtraTruck();
            }
        }
        public static PickUp CreatingPickUp()
        {
            int choose = 0;
            do { try { Console.Write("Конструктор по умолчанию - 1, своё ТС - 2 "); choose = int.Parse(Console.ReadLine()); if (!(0 < choose && choose < 3)) throw new Exception("Введите чило в дапазоне 1-2"); } catch (Exception error) { Console.WriteLine(error.Message); } } while (!(0 < choose && choose < 3));
            if (choose == 2)
            {
                string name = ""; int mass = 0; int powerReserve = 0; int carryCap = 0; int cargoMass = 0; int wheel = 0; int drivers = 0; bool isPass = true; int isPassInt;
                do
                {
                    try
                    {
                        Console.Write("Название ");
                        name = Console.ReadLine(); if (name.Length < 0) throw new Exception("Введите название");
                        Console.Write("Масса ");
                        mass = int.Parse(Console.ReadLine()); if (mass < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Запас хода ");
                        powerReserve = int.Parse(Console.ReadLine()); if (powerReserve < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Грузоподъемность ");
                        carryCap = int.Parse(Console.ReadLine()); if (carryCap < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Масса груза ");
                        cargoMass = int.Parse(Console.ReadLine()); if (cargoMass < 0 || carryCap >= cargoMass) throw new Exception("Это значение не может быть отрицательным или больше грузоподъемности");
                        Console.Write("Кол-во колесов ");
                        wheel = int.Parse(Console.ReadLine()); if (wheel < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Кол-во водителей ");
                        drivers = int.Parse(Console.ReadLine()); if (drivers < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Есть поссажиры? да - 1, нет - другое число ");
                        isPassInt = int.Parse(Console.ReadLine()); if (isPassInt == 1) isPass = true;
                        else isPass = false;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }

                } while (name.Length > 0 && mass > 0 && powerReserve > 0 && carryCap > 0 && cargoMass > 0 && wheel > 0 && drivers > 0);
                return new PickUp(name, mass, powerReserve, carryCap, cargoMass, wheel, drivers, isPass);
            }
            else
            {
                return new PickUp();
            }

        }
        public static Train CreatingTrain()
        {
            int choose = 0;
            do { try { Console.Write("Конструктор по умолчанию - 1, своё ТС - 2 "); choose = int.Parse(Console.ReadLine()); if (!(0 < choose && choose < 3)) throw new Exception("Введите чило в дапазоне 1-2"); } catch (Exception error) { Console.WriteLine(error.Message); } } while (!(0 < choose && choose < 3));
            if (choose == 2)
            {
                string name = ""; int mass = 0; int powerReserve = 0; int carryCap = 0; int cargoMass = 0; int wheel = 0; int wagonsNumber = 0;
                do
                {
                    try
                    {
                        Console.Write("Название ");
                        name = Console.ReadLine(); if (name.Length < 0) throw new Exception("Введите название");
                        Console.Write("Масса ");
                        mass = int.Parse(Console.ReadLine()); if (mass < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Запас хода ");
                        powerReserve = int.Parse(Console.ReadLine()); if (powerReserve < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Грузоподъемность ");
                        carryCap = int.Parse(Console.ReadLine()); if (carryCap < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Масса груза ");
                        cargoMass = int.Parse(Console.ReadLine()); if (cargoMass < 0 || carryCap >= cargoMass) throw new Exception("Это значение не может быть отрицательным или больше грузоподъемности");
                        Console.Write("Кол-во колесов ");
                        wheel = int.Parse(Console.ReadLine()); if (wheel < 0) throw new Exception("Это значение не может быть отрицательным");
                        Console.Write("Кол-во вагонов ");
                        wagonsNumber = int.Parse(Console.ReadLine()); if (wagonsNumber < 0) throw new Exception("Это значение не может быть отрицательным");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }

                } while (name.Length > 0 && mass > 0 && powerReserve > 0 && carryCap > 0 && cargoMass > 0 && wheel > 0 && wagonsNumber > 0);
                return new Train(name, mass, powerReserve, carryCap, cargoMass, wheel, wagonsNumber);
            }
            else
            {
                return new Train();
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            int n;
            int.TryParse(Console.ReadLine(), out n);
            CargoVehicles[] arr = new CargoVehicles[n];
            Console.WriteLine("Заполнение массива");
            Console.WriteLine("_________________________________________________________________________________________________________");
            for (int i = 0; i < arr.Length; i++)
            {
                int temp = 0;
                Console.Write("Пикап - 1, большегруз - 2, поезд - 3: ");
                do { try { temp = int.Parse(Console.ReadLine()); if (!(0 < temp && temp < 4)) throw new Exception("Введите чило в дапазоне 1-3"); } catch (Exception error) { Console.WriteLine(error.Message); } } while (!(0 < temp && temp < 4));

                if (temp == 1) arr[i] = CreatingPickUp();
                if (temp == 2) arr[i] = CreatingExtraTruck();
                if (temp == 3) arr[i] = CreatingTrain();

            }
            //Console.Clear();
            Console.WriteLine("Значения массива");
            Console.WriteLine("_________________________________________________________________________________________________________");
            foreach (CargoVehicles i in arr)
            {
                i.output();
                i.Description();
                Console.Write("Измените массу груза");
                int tempCargoMass = 0;
                do
                {
                    try
                    {
                        tempCargoMass = int.Parse(Console.ReadLine());
                        if (tempCargoMass > i.CarryCap) throw new Exception("Масса груза не может быть больше грузоподъемности");
                        if (tempCargoMass < 0) throw new Exception("Это значение не может быть отрицательным");
                    }
                    catch (Exception error) { Console.WriteLine(error.Message); }
                } while (tempCargoMass > i.CarryCap || tempCargoMass < 0);
                i.CargoMass = tempCargoMass;
                Console.WriteLine("Новая масса груза ТС {0:F2}", i.CargoMass);
                Console.WriteLine("Полная масса ТС {0:F2}", i.fullMass);


                int fuelMass = 0;
                Console.Write("Введите значение массы бензина ");
                do
                {
                    try
                    {
                        fuelMass = int.Parse(Console.ReadLine());
                        if (fuelMass + i.CargoMass > i.CarryCap) throw new Exception("Сумма массы бензина и массы груза не должна превышать грузоподъёмность");
                        if (fuelMass < 0) throw new Exception("Это значение не может быть отрицательным");
                    }
                    catch (Exception error) { Console.WriteLine(error.Message); }
                } while (!(fuelMass + i.CargoMass < i.CarryCap && fuelMass >= 0));
                i.fuelS(fuelMass);
            }

            /*Console.WriteLine("\n\n Значения отдельного объекта(класса ExtraTruck)");
            Console.WriteLine("_________________________________________________________________________________________________________");*//*
            Truck truck = CreatingExtraTruck();*//*
            truck.Description();
            truck.output();*/





            Console.ReadKey();
        }
    }
}
