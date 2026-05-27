namespace WebNet23Online.Data.Models;

public class HabitTrChatMessageData : BaseModel
{
    public DateTime Date { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    
    public virtual UserData User { get; set; }
}