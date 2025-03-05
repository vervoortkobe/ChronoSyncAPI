namespace Domain.Model.TimeEntries;

public class DetachedTimeEntry : BaseTimeEntry
{
    public required Category Category { get; set; }
    public required DateOnly Date { get; set; }
}

public enum Category
{
    LEARN, 
    PROJECT, 
    CLIENT, 
    OTHER
}
