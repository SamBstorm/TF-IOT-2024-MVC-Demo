﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo01.Models
{
    public class StudentCreateForm
    {
        [DisplayName("Prénom : ")]
        [Required(ErrorMessage = "Est obligatoire.")]
        [MinLength(3, ErrorMessage = "Nécessite 3 caractères au minimum.")]
        [MaxLength(50, ErrorMessage = "Ne peut excéder 50 caractères.")]
        public string First_Name { get; set; }
        [DisplayName("Nom de famille: ")]
        [Required(ErrorMessage = "Est obligatoire.")]
        [MinLength(3, ErrorMessage = "Nécessite 3 caractères au minimum.")]
        [MaxLength(50, ErrorMessage = "Ne peut excéder 50 caractères.")]
        public string Last_Name { get; set; }
        [DisplayName("Date de naissance: ")]
        [Required(ErrorMessage = "Est obligatoire.")]
        [DataType(DataType.Date)]
        public DateTime Birth_Date { get; set; }
    }
}
