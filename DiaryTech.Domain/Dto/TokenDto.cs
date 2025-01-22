namespace DiaryTech.Domain.Dto.User;

public class TokenDto
{
    public string AccessToken { get; set; }
    
    public string RefreshToken { get; set; }
}