/*Завдання 3
Створіть клас «Кафе» з інформацією про працівників кафе. 
Реалізуйте підтримку ітератора для класу
«Кафе». Протестуйте можливість використання foreach
для «Кафе».*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


interface ICafeWorker
{
    string Name { get; }
    string Position { get; }
    int Age { get; }
}


class Waiter : ICafeWorker
{
    public string Name { get; }
    public string Position { get; }
    public int Age { get; }

    public Waiter(string name, int age)
    {
        Name = name;
        Position = "Официант";
        Age = age;
    }
}


class Chef : ICafeWorker
{
    public string Name { get; }
    public string Position { get; }
    public int Age { get; }

    public Chef(string name, int age)
    {
        Name = name;
        Position = "Повар";
        Age = age;
    }
}


class Cafe : IEnumerable<ICafeWorker>
{
    private List<ICafeWorker> cafeWorkers = new List<ICafeWorker>();

    public void AddCafeWorker(ICafeWorker worker)
    {
        cafeWorkers.Add(worker);
    }

    public IEnumerator<ICafeWorker> GetEnumerator()
    {
        return cafeWorkers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        Cafe cafe = new Cafe();
        cafe.AddCafeWorker(new Waiter("Валентин", 25));
        cafe.AddCafeWorker(new Chef("София", 30));
        cafe.AddCafeWorker(new Waiter("Маргарита", 23));

        Console.WriteLine("Сотрудники кафе:");
        foreach (ICafeWorker worker in cafe)
        {
            Console.WriteLine($"{worker.Name} ({worker.Position}) - Возраст: {worker.Age} лет");
        }
        Console.ReadKey();
    }
}

