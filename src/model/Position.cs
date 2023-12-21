using System.ComponentModel.DataAnnotations;

namespace Bredex1.src.model
{
    public class Position
    {
        [StringLength(50)]
        public required string Title {get; set;}

        [StringLength(50)]
        public required string Location {get; set;}
    }
}