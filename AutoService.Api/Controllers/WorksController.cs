using AutoService.Domain.Data;
using AutoService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers;

/// <summary>
/// Контроллер для управления видами работ.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WorksController : ControllerBase
{
    /// <summary>
    /// Получить список всех видов работ.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<WorkType>> GetAll()
    {
        return Ok(DataSeed.Works);
    }

    /// <summary>
    /// Получить вид работ по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор вида работ.</param>
    [HttpGet("{id}")]
    public ActionResult<WorkType> GetById(Guid id)
    {
        var work = DataSeed.Works.FirstOrDefault(w => w.Id == id);
        if (work == null) return NotFound();
        return Ok(work);
    }

    /// <summary>
    /// Добавить новый вид работ.
    /// </summary>
    /// <param name="newWork">Данные нового вида работ.</param>
    [HttpPost]
    public ActionResult<WorkType> Create([FromBody] WorkType newWork)
    {
        DataSeed.Works.Add(newWork);
        return CreatedAtAction(nameof(GetById), new { id = newWork.Id }, newWork);
    }

    /// <summary>
    /// Обновить данные вида работ.
    /// </summary>
    /// <param name="id">Идентификатор вида работ.</param>
    /// <param name="updatedWork">Новые данные вида работ.</param>
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] WorkType updatedWork)
    {
        var work = DataSeed.Works.FirstOrDefault(w => w.Id == id);
        if (work == null) return NotFound();

        work.Name = updatedWork.Name;
        work.Category = updatedWork.Category;
        work.Price = updatedWork.Price;
        work.Duration = updatedWork.Duration;

        return NoContent();
    }

    /// <summary>
    /// Удалить вид работ по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор вида работ.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var work = DataSeed.Works.FirstOrDefault(w => w.Id == id);
        if (work == null) return NotFound();

        DataSeed.Works.Remove(work);
        return NoContent();
    }
}