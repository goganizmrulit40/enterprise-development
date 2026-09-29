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

        var cars = new List<Car>()
        {
            new() { LicensePlate = "Т812КМ 78", Brand = "Skoda",   Model = "Octavia", Year = 2000, ClientId = clients[0].Id },
            new() { LicensePlate = "Н217УВ 47", Brand = "Kia",     Model = "Rio",     Year = 2001, ClientId = clients[1].Id },
            new() { LicensePlate = "М903АС 99", Brand = "Lada",    Model = "Vesta",   Year = 2002, ClientId = clients[2].Id },
            new() { LicensePlate = "Е441РТ 67", Brand = "Hyundai", Model = "Creta",   Year = 2003, ClientId = clients[3].Id },
            new() { LicensePlate = "В562НХ 52", Brand = "Mazda",   Model = "CX-5",    Year = 2004, ClientId = clients[4].Id },
            new() { LicensePlate = "К119МУ 178",Brand = "Chery",   Model = "Tiggo 7", Year = 2005, ClientId = clients[5].Id },
            new() { LicensePlate = "О774ВС 23", Brand = "Toyota",  Model = "Camry",   Year = 2006, ClientId = clients[6].Id },
            new() { LicensePlate = "С528ТЕ 64", Brand = "Renault", Model = "Duster",  Year = 2007, ClientId = clients[7].Id },
            new() { LicensePlate = "У391АК 16", Brand = "VW",      Model = "Polo",    Year = 2008, ClientId = clients[8].Id },
            new() { LicensePlate = "Р527ОМ 34", Brand = "Nissan",  Model = "Qashqai", Year = 2026, ClientId = clients[9].Id }
        };

        var mechanics = new List<Mechanic>()
        {
            new() { Passport = "8888 123345", FullName = "Кириллов Кирилл Кириллович",      Specialization = Specialization.Engine,         Experience = 11 },
            new() { Passport = "7777 123243", FullName = "Романова Ольга Владимировна",     Specialization = Specialization.Transmission,   Experience = 8  },
            new() { Passport = "6666 213123", FullName = "Гусеев Гусь Гусевич",             Specialization = Specialization.Electrical,     Experience = 6  },
            new() { Passport = "5555 324255", FullName = "Комаров Комар Комарович",         Specialization = Specialization.Body,           Experience = 14 },
            new() { Passport = "4444 543546", FullName = "Мошкова Мошка Мошковна",          Specialization = Specialization.Diagnostics,    Experience = 5  },
            new() { Passport = "3333 456546", FullName = "Тараканов Таракан Тараканович",   Specialization = Specialization.Suspension,     Experience = 9  },
            new() { Passport = "2222 879789", FullName = "Тараканов Торт Тортович",         Specialization = Specialization.Brakes,         Experience = 7  },
            new() { Passport = "1111 674667", FullName = "Горева Зима Владимировна",        Specialization = Specialization.Painting,       Experience = 12 },
            new() { Passport = "9999 812812", FullName = "Веснова Весна Владимировна",      Specialization = Specialization.Engine,         Experience = 17 },
            new() { Passport = "0000 524267", FullName = "Родионов Михаил Петрович",        Specialization = Specialization.Diagnostics,    Experience = 3  }
        };
        
        var works = new List<WorkType>();
        var orders = new List<Order>();

        return (clients, cars, mechanics, works, orders);
    }
}