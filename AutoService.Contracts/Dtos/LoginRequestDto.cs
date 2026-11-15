namespace AutoService.Contracts.Dtos;

/// <summary>
/// Данные для входа в приложение
/// </summary>
public class LoginRequestDto
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
