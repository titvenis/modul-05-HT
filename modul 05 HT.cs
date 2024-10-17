using System;

public interface IVehicle
{
    void Drive();
    void Refuel();
}

public class Car : IVehicle
{
    private string Brand;
    private string Model;
    private string FuelType;

    public Car(string brand, string model, string fuelType)
    {
        Brand = brand;
        Model = model;
        FuelType = fuelType;
    }

    public void Drive()
    {
        Console.WriteLine($"Автомобиль {Brand} {Model} едет.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Автомобиль {Brand} {Model} заправляется {FuelType}.");
    }
}

public class Motorcycle : IVehicle
{
    private string Type;
    private int EngineVolume;

    public Motorcycle(string type, int engineVolume)
    {
        Type = type;
        EngineVolume = engineVolume;
    }

    public void Drive()
    {
        Console.WriteLine($"Мотоцикл типа {Type} с объемом двигателя {EngineVolume}cc едет.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Мотоцикл типа {Type} заправляется.");
    }
}

public class Truck : IVehicle
{
    private int LoadCapacity;
    private int AxleCount;

    public Truck(int loadCapacity, int axleCount)
    {
        LoadCapacity = loadCapacity;
        AxleCount = axleCount;
    }

    public void Drive()
    {
        Console.WriteLine($"Грузовик с грузоподъемностью {LoadCapacity} тонн и {AxleCount} осями едет.");
    }

    public void Refuel()
    {
        Console.WriteLine("Грузовик заправляется дизелем.");
    }
}

public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}

public class CarFactory : VehicleFactory
{
    private string brand;
    private string model;
    private string fuelType;

    public CarFactory(string brand, string model, string fuelType)
    {
        this.brand = brand;
        this.model = model;
        this.fuelType = fuelType;
    }

    public override IVehicle CreateVehicle()
    {
        return new Car(brand, model, fuelType);
    }
}

public class MotorcycleFactory : VehicleFactory
{
    private string type;
    private int engineVolume;

    public MotorcycleFactory(string type, int engineVolume)
    {
        this.type = type;
        this.engineVolume = engineVolume;
    }

    public override IVehicle CreateVehicle()
    {
        return new Motorcycle(type, engineVolume);
    }
}

public class TruckFactory : VehicleFactory
{
    private int loadCapacity;
    private int axleCount;

    public TruckFactory(int loadCapacity, int axleCount)
    {
        this.loadCapacity = loadCapacity;
        this.axleCount = axleCount;
    }

    public override IVehicle CreateVehicle()
    {
        return new Truck(loadCapacity, axleCount);
    }
}

public class Bus : IVehicle
{
    private int PassengerCapacity;
    private string Route;

    public Bus(int passengerCapacity, string route)
    {
        PassengerCapacity = passengerCapacity;
        Route = route;
    }

    public void Drive()
    {
        Console.WriteLine($"Автобус с вместимостью {PassengerCapacity} пассажиров едет по маршруту {Route}.");
    }

    public void Refuel()
    {
        Console.WriteLine("Автобус заправляется газом.");
    }
}

public class BusFactory : VehicleFactory
{
    private int passengerCapacity;
    private string route;

    public BusFactory(int passengerCapacity, string route)
    {
        this.passengerCapacity = passengerCapacity;
        this.route = route;
    }

    public override IVehicle CreateVehicle()
    {
        return new Bus(passengerCapacity, route);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип транспорта: 1. Автомобиль 2. Мотоцикл 3. Грузовик 4. Автобус");
        string choice = Console.ReadLine();

        VehicleFactory factory = null;

        switch (choice)
        {
            case "1":
                Console.Write("Введите марку автомобиля: ");
                string carBrand = Console.ReadLine();
                Console.Write("Введите модель автомобиля: ");
                string carModel = Console.ReadLine();
                Console.Write("Введите тип топлива: ");
                string fuelType = Console.ReadLine();
                factory = new CarFactory(carBrand, carModel, fuelType);
                break;
            case "2":
                Console.Write("Введите тип мотоцикла (спортивный/туристический): ");
                string motoType = Console.ReadLine();
                Console.Write("Введите объем двигателя (в cc): ");
                int engineVolume = int.Parse(Console.ReadLine());
                factory = new MotorcycleFactory(motoType, engineVolume);
                break;
            case "3":
                Console.Write("Введите грузоподъемность (в тоннах): ");
                int loadCapacity = int.Parse(Console.ReadLine());
                Console.Write("Введите количество осей: ");
                int axleCount = int.Parse(Console.ReadLine());
                factory = new TruckFactory(loadCapacity, axleCount);
                break;
            case "4":
                Console.Write("Введите вместимость автобуса (в пассажирах): ");
                int passengerCapacity = int.Parse(Console.ReadLine());
                Console.Write("Введите маршрут автобуса: ");
                string route = Console.ReadLine();
                factory = new BusFactory(passengerCapacity, route);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        IVehicle vehicle = factory.CreateVehicle();
        vehicle.Drive();
        vehicle.Refuel();
    }
}
