using System.ComponentModel.DataAnnotations;

namespace Task_Of_Api.Model
{
    public class Unit
    {
        [Key]
        public int UnitNo { get; set; }
        public string UnitName { get; set; }
    }
}
