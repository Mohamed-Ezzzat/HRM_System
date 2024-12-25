using System.Collections;
using System.Collections.Generic;

namespace HRM_System.Models.ViewModel
{
    public class GroupsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
