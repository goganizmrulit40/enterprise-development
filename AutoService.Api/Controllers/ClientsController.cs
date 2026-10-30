using AutoService.Domain.Data;
using AutoService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers;

/// <summary>
/// Контроллер для управления клиентами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    /// <summary>
    /// Получить список всех клиентов.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Client>> GetAll()
    {
        return Ok(DataSeed.Clients);
    }

    /// <summary>
    /// Получить клиента по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор клиента.</param>
    [HttpGet("{id}")]
    public ActionResult<Client> GetById(Guid id)
    {
        var client = DataSeed.Clients.FirstOrDefault(c => c.Id == id);
        if (client == null) return NotFound();
        return Ok(client);
    }

    /// <summary>
    /// Добавить нового клиента.
    /// </summary>
    /// <param name="newClient">Данные нового клиента.</param>
    [HttpPost]
    public ActionResult<Client> Create([FromBody] Client newClient)
    {
        DataSeed.Clients.Add(newClient);
        return CreatedAtAction(nameof(GetById), new { id = newClient.Id }, newClient);
    }

    /// <summary>
    /// Обновить данные существующего клиента.
    /// </summary>
    /// <param name="id">Идентификатор клиента.</param>
    /// <param name="updatedClient">Новые данные клиента.</param>
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Client updatedClient)
    {
        var client = DataSeed.Clients.FirstOrDefault(c => c.Id == id);
        if (client == null) return NotFound();

        client.FullName = updatedClient.FullName;
        client.Phone = updatedClient.Phone;

        return NoContent();
    }

    /// <summary>
    /// Удалить клиента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор клиента.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var client = DataSeed.Clients.FirstOrDefault(c => c.Id == id);
        if (client == null) return NotFound();

        DataSeed.Clients.Remove(client);
        return NoContent();
    }
}