﻿using System.ComponentModel.DataAnnotations;

namespace NetCoreIdentity.Models
{
    public class UserSignInModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Parola gereklidir.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
