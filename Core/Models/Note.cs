using Core.BaseTypes;

namespace Core.Models
{
    public partial class Note: TrackableEntity
    {

        public string Text { get; set; }
        public int NoteTypeId { get; set; }
    }
}
