namespace _0_Framework.Domain
{
    public abstract class EntityBase
    {
        public long Id { get; protected set; }
        public bool IsRemoved { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        public EntityBase()
        {
            IsRemoved = Statuses.NotRemoved;
            CreationDate = DateTime.Now;
        }
    }
}