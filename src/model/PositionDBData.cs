using System.ComponentModel.DataAnnotations;

namespace Bredex1.src.model
{
    public class PositionDBData
    {
        public PositionDBData(string title, string location) 
        {
            Id = Guid.NewGuid();
            Title = title;
            Location = location;
        }


        [Key]
        public Guid Id {get; set;}

        [StringLength(50)]
        public string Title {get; set;}

        [StringLength(50)]
        public string Location {get; set;}
    }
}