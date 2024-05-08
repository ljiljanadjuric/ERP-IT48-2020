﻿using System.ComponentModel.DataAnnotations;

namespace ProdavnicaObuce.DTOs
{
    public class LoginDTO
    {
        [Required, MaxLength(100)]
        public string Email { get; set; } = String.Empty;
        [Required, MaxLength(100)]
        public string Sifra { get; set; } = String.Empty;
    }
}
