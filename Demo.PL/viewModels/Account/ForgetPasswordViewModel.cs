﻿using System.ComponentModel.DataAnnotations;

namespace Demo.PL.viewModels.Account
{
    public class ForgetPasswordViewModel
    {

        [DataType(DataType.EmailAddress)]
        [Required (ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
