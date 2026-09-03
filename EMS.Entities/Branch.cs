using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entities
{
    public class Branch
    {
        public int Id { get; set; }

        [DisplayName("Branch Name")]
        [Required(ErrorMessage = "Please enter Branch Name")]
        public string BranchName { get; set; }

        [DisplayName("Branch Head")]
        [Required(ErrorMessage = "Please enter Branch Head")]

        public string BranchHead { get; set; }

        [Required(ErrorMessage = "Please enter Branch Address")]

        [DisplayName("Branch Address")]
        public string Address { get; set; }
    }
}