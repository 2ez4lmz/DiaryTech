using DiaryTech.Domain.Interfaces;

namespace DiaryTech.Domain.Entity;

public class User : IEntityId<long>, IAuditable
{
    public long Id { get; set; }

    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public List<Report> Reports { get; set; }
    
    public UserToken UserToken { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public long CreatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public long? UpdatedBy { get; set; }
}