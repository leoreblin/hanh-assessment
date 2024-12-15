namespace Domain.Primitives;

public abstract class Entity
{
    protected Entity(Guid id)
        : this()
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("The entity ID is required.", nameof(id));
        }

        Id = id;
    }

    protected Entity() { }

    public Guid Id { get; private set; }        
}
