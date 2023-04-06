using StudyOfTheEffectivenessOperations.FileExt;
using StudyOfTheEffectivenessOperations.Operation.ArrayOperation;
using StudyOfTheEffectivenessOperations.Operation.AVLTreeOperation;
using StudyOfTheEffectivenessOperations.Operation.BidirectionaListOperation;
using StudyOfTheEffectivenessOperations.Operation.BinaryTreeOperation;
using StudyOfTheEffectivenessOperations.Operation.BlackRedTreeOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileOperation file = new FileOperation();
            ArrayOperation arrayOp = new ArrayOperation();
            BidirectionaListOperation listOp = new BidirectionaListOperation();
            BinaryTreeOperation binaryTreeOp = new BinaryTreeOperation();
            BlackRedTreeOperation blackRedTreeOp = new BlackRedTreeOperation();
            AVLTreeOperation AVLTreeOp = new AVLTreeOperation();
        }
    }
}
