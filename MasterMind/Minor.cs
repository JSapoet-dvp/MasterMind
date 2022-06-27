using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Minor : Player
    {
        bool Permission
        { get; set; }

        public Minor(int id, int age, string name, bool permission) : base(id, age, name)
        {
            Permission = permission;
        }
    }
}
