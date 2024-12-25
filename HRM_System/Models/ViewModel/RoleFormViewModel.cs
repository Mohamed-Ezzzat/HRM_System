using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_System.Models.ViewModel
{
    public class RoleFormViewModel
    {
        [Required, StringLength(256)]

        public string Name { get; set; }

        public List<CheckBoxViewModel> RoleCalims { get; set; }

    }
}
