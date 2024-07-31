using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo01.Models
{
    public class StudentListItem
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int Student_Id { get; set; }
        [DisplayName("Prénom")]
        public string First_Name { get; set; }
        [DisplayName("Nom de famille")]
        public string Last_Name { get; set; }

    }
}
