namespace AutoService.Contracts.Dtos;

/// <summary>
/// Результат успешного входа
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    /// JWT для доступа к API
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Дата и время окончания действия токена в UTC
    /// </summary>
    public DateTime ExpiresAt { get; set; }
}
