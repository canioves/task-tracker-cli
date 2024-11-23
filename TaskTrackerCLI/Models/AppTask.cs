using TaskTrackerCLI.Enums;

namespace TaskTrackerCLI.Models
{
    public class AppTask
    {
        public AppTask(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; } = Status.TODO;
        public DateTime? CreatedAt { get; set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            AppTask other = (AppTask)obj;
            return Id == other.Id && Description == other.Description; 
        }
        public override int GetHashCode() => Id.GetHashCode() ^ Description.GetHashCode();
    }
}
