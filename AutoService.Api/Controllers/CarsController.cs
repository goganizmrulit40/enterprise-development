using AutoService.Domain.Data;
using AutoService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers;

/// <summary>
/// Контроллер для управления автомобилями.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    /// <summary>
    /// Получить список всех автомобилей.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAll()
    {
        return Ok(DataSeed.Cars);
    }

    /// <summary>
    /// Получить автомобиль по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор автомобиля.</param>
    [HttpGet("{id}")]
    public ActionResult<Car> GetById(Guid id)
    {
        var car = DataSeed.Cars.FirstOrDefault(c => c.Id == id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    /// <summary>
    /// Добавить новый автомобиль.
    /// </summary>
    /// <param name="newCar">Данные нового автомобиля.</param>
    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
        DataSeed.Cars.Add(newCar);
        return CreatedAtAction(nameof(GetById), new { id = newCar.Id }, newCar);
    }

    /// <summary>
    /// Обновить данные существующего автомобиля.
    /// </summary>
    /// <param name="id">Идентификатор автомобиля.</param>
    /// <param name="updatedCar">Новые данные автомобиля.</param>
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Car updatedCar)
    {
        var car = DataSeed.Cars.FirstOrDefault(c => c.Id == id);
        if (car == null) return NotFound();

        car.Brand = updatedCar.Brand;
        car.Model = updatedCar.Model;
        car.Year = updatedCar.Year;
        car.LicensePlate = updatedCar.LicensePlate;

        return NoContent();
    }

    /// <summary>
    /// Удалить автомобиль по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор автомобиля.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var car = DataSeed.Cars.FirstOrDefault(c => c.Id == id);
        if (car == null) return NotFound();

        DataSeed.Cars.Remove(car);
        return NoContent();
    }
}