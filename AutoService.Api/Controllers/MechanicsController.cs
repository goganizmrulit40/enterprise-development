using AutoService.Domain.Data;
using AutoService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers;

/// <summary>
/// Контроллер для управления механиками.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MechanicsController : ControllerBase
{
    /// <summary>
    /// Получить список всех механиков.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Mechanic>> GetAll()
    {
        return Ok(DataSeed.Mechanics);
    }

    /// <summary>
    /// Получить механика по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор механика.</param>
    [HttpGet("{id}")]
    public ActionResult<Mechanic> GetById(Guid id)
    {
        var mechanic = DataSeed.Mechanics.FirstOrDefault(m => m.Id == id);
        if (mechanic == null) return NotFound();
        return Ok(mechanic);
    }

    /// <summary>
    /// Добавить нового механика.
    /// </summary>
    /// <param name="newMechanic">Данные нового механика.</param>
    [HttpPost]
    public ActionResult<Mechanic> Create([FromBody] Mechanic newMechanic)
    {
        DataSeed.Mechanics.Add(newMechanic);
        return CreatedAtAction(nameof(GetById), new { id = newMechanic.Id }, newMechanic);
    }

    /// <summary>
    /// Обновить данные существующего механика.
    /// </summary>
    /// <param name="id">Идентификатор механика.</param>
    /// <param name="updatedMechanic">Новые данные механика.</param>
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Mechanic updatedMechanic)
    {
        var mechanic = DataSeed.Mechanics.FirstOrDefault(m => m.Id == id);
        if (mechanic == null) return NotFound();

        mechanic.FullName = updatedMechanic.FullName;
        mechanic.Passport = updatedMechanic.Passport;
        mechanic.Specialization = updatedMechanic.Specialization;
        mechanic.Experience = updatedMechanic.Experience;

        return NoContent();
    }

    /// <summary>
    /// Удалить механика по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор механика.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var mechanic = DataSeed.Mechanics.FirstOrDefault(m => m.Id == id);
        if (mechanic == null) return NotFound();

        DataSeed.Mechanics.Remove(mechanic);
        return NoContent();
    }
}