using AutoService.Domain.Models;

namespace AutoService.Domain.Data;

/// <summary>
/// Тестовые данные для юнит-тестов
/// </summary>
public static class DataSeed
{
    /// <summary>
    /// Возвращаем по 10 экземпляров каждого класса
    /// </summary>
    public static (List<Client>, List<Car>, List<Mechanic>, List<WorkType>, List<Order>) Create()
    {
        var clients = new List<Client>
        {
            new() { FullName = "Иванов Иван Иванович",              Phone = "+71234567890" },
            new() { FullName = "Симонов Илья Геогриевич",           Phone = "+71234567891" },
            new() { FullName = "Кораблев Гриша Александрович",      Phone = "+71234567892" },
            new() { FullName = "Толстой Илья Сергеевич",            Phone = "+71234567893" },
            new() { FullName = "Кольцова Александра Тимофеевна",    Phone = "+71234567894" },
            new() { FullName = "Кулова Диана Сергеевна",            Phone = "+71234567895" },
            new() { FullName = "Кикиморов Петр Иванович",           Phone = "+71234567896" },
            new() { FullName = "Кощеев Кощей Кощеевич",             Phone = "+71234567897" },
            new() { FullName = "Кефирова Яга Сергеевна",            Phone = "+71234567898" },
            new() { FullName = "Андреев Андрей Андреевич",          Phone = "+71234567899" }
        };

        var cars = new List<Car>();
        var mechanics = new List<Mechanic>();
        var works = new List<WorkType>();
        var orders = new List<Order>();

        return (clients, cars, mechanics, works, orders);
    }
}