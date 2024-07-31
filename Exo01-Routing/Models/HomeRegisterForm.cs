using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exo01_Routing.Models
{
    public class HomeRegisterForm
    {
        [DisplayName("Nom de famille : ")]
        [Required(ErrorMessage = "est requis")]
        [MinLength(4, ErrorMessage = "Pas assez de caractères")]
        [MaxLength(16, ErrorMessage = "Trop de caractères")]
        public string Name { get; set; }
        [DisplayName("Prénom : ")]
        [Required(ErrorMessage = "est requis")]
        [MinLength(4, ErrorMessage = "Pas assez de caractères")]
        [MaxLength(16, ErrorMessage = "Trop de caractères")]
        public string FirstName { get; set; }
        [DisplayName("Date de naissance : ")]
        [DataType(DataType.Date,ErrorMessage = "Veuillez entrer une date valide.")]
        [Required(ErrorMessage = "est requis")]
        public DateOnly BirthDate { get; set; }
        [DisplayName("Pays : ")]
        public string? Country { get; set; }
        [DisplayName("Adresse e-mail : ")]
        [Required(ErrorMessage = "est requis")]
        [EmailAddress(ErrorMessage = "Ne correspond pas au format d'une adresse e-mail.")]
        [MinLength(5, ErrorMessage = "Pas assez de caractères")]
        [MaxLength(320, ErrorMessage = "Trop de caractères")]
        public string Email { get; set; }
        [DisplayName("Mot de passe : ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "est requis")]
        [MinLength(8, ErrorMessage = "Pas assez de caractères")]
        [MaxLength(64, ErrorMessage = "Trop de caractères")]
        public string Password { get; set; }
        [DisplayName("Veuillez confirmer le mot de passe : ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "est requis")]
        [MinLength(8, ErrorMessage = "Pas assez de caractères")]
        [MaxLength(64, ErrorMessage = "Trop de caractères")]
        [Compare(nameof(Password), ErrorMessage = "Les mots de passe ne corespondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}
