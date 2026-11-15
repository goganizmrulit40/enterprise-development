namespace AutoService.Contracts.Dtos;

/// <summary>
/// DTO для результата аналитики по клиентам механика.
/// </summary>
public class ClientMechanicReportDto
{
    /// <summary>
    /// Идентификатор клиента.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// ФИО клиента.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Контактный телефон.
    /// </summary>
    public string Phone { get; set; } = string.Empty;
}
