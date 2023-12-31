﻿using System.ComponentModel.DataAnnotations;

namespace TailorWebApp.Application.Dtos.Authentication
{
    public class AuthenticationRequestDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}