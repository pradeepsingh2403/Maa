using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maa
{
    public class RolePermission
    {
        public bool CanSave { get; set; } = false;
        public bool CanUpdate { get; set; } = false;
        public bool CanDelete { get; set; } = false;
        public bool CanView { get; set; } = false;
        public bool CanExport { get; set; } = false;
    }
}
