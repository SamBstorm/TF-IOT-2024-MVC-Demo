using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo01.Models
{
    public class AuthLoginForm
    {
        [DisplayName("Votre login :")]
        [Required(ErrorMessage = "Le champs 'Login' est obligatoire")]
        [StringLength(6,MinimumLength = 2, ErrorMessage = "Le champs 'Login' doit avoir un nombre de caractères entre 2 et 6")]
        public string Login { get; set; }
        [DisplayName("Votre mot de passe :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le champs 'Mot de passe' est obligatoire")]
        [RegularExpression("[0-9]+",ErrorMessage = "Manque un chiffre")]
        [MinLength(8,ErrorMessage ="Le champ 'Mot de passe' doit avoir au minimum 8 caractères.")]
        [MaxLength(64,ErrorMessage = "Le champ 'Mot de passe' doit avoir au maximum 64 caractères.")]
        //[RegularExpression("[0-9]+")]
        //[RegularExpression("[a-z]+")] ATTENTION : Pas possible de multiplier les attributs, sur un même éléments (Propriétés, Méthodes, champs,...)
        public string Password { get; set; }
    }
}
