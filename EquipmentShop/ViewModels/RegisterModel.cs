using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email field is empty!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Prove that you are an admin!")]
        public string AdminVerification { get; set; }
        [Required(ErrorMessage = "Password fireld is empty!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wrong Password!")]
        public string ConfirmPassword { get; set; }
    }
}
