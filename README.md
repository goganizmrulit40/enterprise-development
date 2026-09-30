# Лабораторная работа №1 - Классы

## Цель работы

Реализовать объектную модель предметной области "Автосвервис", реализовать линк-запросы к тестовым данным, также с помощью модульных тестов на xUnit v3 проверить результаты.

## Предметная область

В проекте реализованы следующие основные классы:
- `Client` — клиент автосервиса;
- `Car` — автомобиль клиента;
- `Mechanic` — механик автосервиса;
- `WorkType` — вид работ, выполняемых в автосервисе;
- `Order` — заказ на обслуживание автомобиля.

а также перечисление:
- `Specialization` — специализация механика.

Между классами реализованы связи: клиент может иметь несколько
автомобилей, каждый автомобиль привязан к клиенту. Заказ содержит
информацию о клиенте, автомобиле, механике и списке видов работ,
а также даты приёма и выдачи автомобиля. Виды работ сгруппированы
по категориям, соответствующим специализациям механиков.

## Тестовые данные

Для выполнения лабораторной работы создан статический класс `DataSeed` с методом `Create()`, возвращающим кортеж из пяти коллекций.

В наборе данных предусмотрено по 10 экземпляров основных сущностей:
клиентов, автомобилей, механиков, видов работ и заказов.

## LINQ-запросы

В модульных тестах реализованы и проверены следующие запросы:

1. Получение механиков, специализирующихся на выбранном виде работ.
2. Получение клиентов, чьи автомобили обслуживались у указанного
механика, с сортировкой по ФИО.
3. Получение клиентов с повторными обращениями за последний месяц.
4. Подсчёт суммарной стоимости работ для выбранного заказа.
5. Получение пяти наиболее частых видов работ.

## Модульное тестирование

Для тестирования используется **xUnit v3**.

Всего реализовано 5 тестов.

С помощью команды 
```commandline
"dotnet test"
```
получим результат выполнения:
```commandline
Сводка тестового запуска: Пройден!
  итог: 5
  сбой: 0
  успешно: 5
  пропущено: 0
  длительность: 1s 142ms
```

Команда "dotnet run --project AutoService.Tests -- -showLiveOutput" даёт более подробную информацию о тестах:
```commandline
 AutoService.Tests.AutoServiceTests.GetRepeatClientsLastMonth [OUTPUT] Иванов
 Иван Иванович: 3 обращения
    AutoService.Tests.AutoServiceTests.GetOrderTotalCost [OUTPUT] Авто: Skoda Oc
tavia (Т812КМ 78)
    AutoService.Tests.AutoServiceTests.GetOrderTotalCost [OUTPUT]   Правка вмяти
ны крыла: 6500 р.
    AutoService.Tests.AutoServiceTests.GetOrderTotalCost [OUTPUT]   Диагностика
ходовой: 3200 р.
    AutoService.Tests.AutoServiceTests.GetOrderTotalCost [OUTPUT] Итого: 9700 р.
    AutoService.Tests.AutoServiceTests.GetTop5Works [OUTPUT] Диагностика ходовой
: 3
    AutoService.Tests.AutoServiceTests.GetTop5Works [OUTPUT] Замена АКБ: 2
    AutoService.Tests.AutoServiceTests.GetTop5Works [OUTPUT] Замена тормозных ди
сков: 2
    AutoService.Tests.AutoServiceTests.GetTop5Works [OUTPUT] Компьютерная диагно
стика: 2
    AutoService.Tests.AutoServiceTests.GetTop5Works [OUTPUT] Правка вмятины крыл
а: 2
    AutoService.Tests.AutoServiceTests.GetClientsByMechanic [OUTPUT] Механик: Ки
риллов Кирилл Кириллович
    AutoService.Tests.AutoServiceTests.GetClientsByMechanic [OUTPUT] Андреев Анд
рей Андреевич — +71234567899
    AutoService.Tests.AutoServiceTests.GetClientsByMechanic [OUTPUT] Иванов Иван
 Иванович — +71234567890
    AutoService.Tests.AutoServiceTests.GetMechanicsByWorkCategory [OUTPUT] Мошко
ва Мошка Мошковна — Diagnostics
    AutoService.Tests.AutoServiceTests.GetMechanicsByWorkCategory [OUTPUT] Родио
нов Михаил Петрович — Diagnostics
```