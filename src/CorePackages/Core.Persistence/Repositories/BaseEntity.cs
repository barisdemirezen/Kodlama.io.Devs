namespace Core.Persistence.Repositories;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public BaseEntity()
    {
    }

    public BaseEntity(int id) : this()
    {
        Id = id;
    }
}