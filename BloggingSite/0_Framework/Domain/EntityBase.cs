namespace _0_Framework.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
            IsRemoved = Statuses.NotRemoved;
            CreationDate = DateTime.Now;
        }
    }
}