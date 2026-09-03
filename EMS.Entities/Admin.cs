using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class Admin
    {
        //Data annotations
        //using session in .net core

        [DisplayName("Username")]
        [Required(ErrorMessage = "Please enter Username")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }
}