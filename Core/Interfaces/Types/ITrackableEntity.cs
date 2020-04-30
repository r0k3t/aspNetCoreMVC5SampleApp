namespace Core.Interfaces.Types
{
    public interface ITrackableEntity: ITrackable
    {
        public int Id { get; set; }
    }
}