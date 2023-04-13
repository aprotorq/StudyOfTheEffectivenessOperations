using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations.Models
{
    public class BlackRedTreeNodes
    {
        public int value;
        public BlackRedTreeNodes left;
        public BlackRedTreeNodes right;
        public bool isBlack;

        public BlackRedTreeNodes(int value)
        {
            this.value = value;
            this.isBlack = false;
        }
    }
}
