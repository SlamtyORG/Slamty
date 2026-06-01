namespace Slamty.Domain.Contracts
{
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public void Delete()
        {
            IsDeleted = true;
            DeletedDate = DateTime.UtcNow;
        }

        public void UnDelete()
        {
            IsDeleted = false;
            DeletedDate = null;
        }
    }
}
