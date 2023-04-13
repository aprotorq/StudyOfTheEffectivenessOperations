using StudyOfTheEffectivenessOperations.Models;
using StudyOfTheEffectivenessOperations.Operation.BinaryTreeOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOfTheEffectivenessOperations.Operation.BlackRedTreeOperation
{
    public class BlackRedTreeOperation
    {
        public BlackRedTreeNodes root;

        public BlackRedTreeOperation()
        {
            Run();
        }
        public void Run()
        {
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                int value = random.Next(1, 101);
                Add(value);
            }

            Console.WriteLine("Diagram drzewa czarno-czerwonego:");
            PrintTree(root, 0);
        }
        public void Add(int value)
        {
            BlackRedTreeNodes newBlackRedTreeNodes = new BlackRedTreeNodes(value);

            if (root == null)
            {
                newBlackRedTreeNodes.isBlack = true;
                root = newBlackRedTreeNodes;
                return;
            }

            BlackRedTreeNodes current = root;
            BlackRedTreeNodes parent = null;

            while (current != null)
            {
                parent = current;

                if (value < current.value)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }

            if (value < parent.value)
            {
                parent.left = newBlackRedTreeNodes;
            }
            else
            {
                parent.right = newBlackRedTreeNodes;
            }

            FixViolation(newBlackRedTreeNodes);
        }

        private void FixViolation(BlackRedTreeNodes BlackRedTreeNodes)
        {
            BlackRedTreeNodes parent = null;
            BlackRedTreeNodes grandParent = null;

            while (BlackRedTreeNodes != root && BlackRedTreeNodes.isBlack == false && BlackRedTreeNodes.left.isBlack == false && BlackRedTreeNodes.right.isBlack == false)
            {
                parent = BlackRedTreeNodes.left.value < BlackRedTreeNodes.right.value ? BlackRedTreeNodes.left : BlackRedTreeNodes.right;
                grandParent = parent.left.value < parent.right.value ? parent.left : parent.right;

                grandParent.isBlack = false;
                parent.isBlack = true;
                BlackRedTreeNodes.isBlack = true;

                BlackRedTreeNodes = grandParent;
            }

            if (BlackRedTreeNodes != root && BlackRedTreeNodes.isBlack == false && parent.isBlack == true && parent.left == BlackRedTreeNodes)
            {
                RotateRight(parent);
                BlackRedTreeNodes = parent;
                parent = BlackRedTreeNodes.right;
            }
            else if (BlackRedTreeNodes != root && BlackRedTreeNodes.isBlack == false && parent.isBlack == true && parent.right == BlackRedTreeNodes)
            {
                RotateLeft(parent);
                BlackRedTreeNodes = parent;
                parent = BlackRedTreeNodes.left;
            }

            if (BlackRedTreeNodes != root && BlackRedTreeNodes.isBlack == false && parent.isBlack == false)
            {
                grandParent = parent.left.value < parent.right.value ? parent.left : parent.right;

                if (parent == grandParent.left && BlackRedTreeNodes == parent.left)
                {
                    RotateRight(grandParent);
                    parent.isBlack = true;
                    grandParent.isBlack = false;
                }
                else if (parent == grandParent.left && BlackRedTreeNodes == parent.right)
                {
                    RotateLeft(parent);
                    RotateRight(grandParent);
                    BlackRedTreeNodes.isBlack = true;
                    grandParent.isBlack = false;
                }
                else if (parent == grandParent.right && BlackRedTreeNodes == parent.right)
                {
                    RotateLeft(grandParent);
                    parent.isBlack = true;
                    grandParent.isBlack = false;
                }
                else if (parent == grandParent.right && BlackRedTreeNodes == parent.left)
                {
                    RotateRight(parent);
                    RotateLeft(grandParent);
                    BlackRedTreeNodes.isBlack = true;
                    grandParent.isBlack = false;
                }
            }

            root.isBlack = true;
        }

        private void RotateLeft(BlackRedTreeNodes BlackRedTreeNodes)
        {
            BlackRedTreeNodes rightChild = BlackRedTreeNodes.right;
            BlackRedTreeNodes.right = rightChild.left;

            if (rightChild.left != null)
            {
                rightChild.left = BlackRedTreeNodes;
            }

            if (BlackRedTreeNodes == root)
            {
                root = rightChild;
            }
        }

        private void RotateRight(BlackRedTreeNodes node)
        {
            BlackRedTreeNodes leftChild = node.left;
            node.left = leftChild.right;
            if (leftChild.right != null)
            {
                leftChild.right = node;
            }

            if (node == root)
            {
                root = leftChild;
            }
        }
        static void PrintTree(BlackRedTreeNodes node, int indent)
        {
            if (node == null)
            {
                return;
            }

            PrintTree(node.right, indent + 4);

            Console.Write(new string(' ', indent));
            Console.Write(node.value.ToString());

            if (node.isBlack == true)
            {
                Console.Write(" (B)");
            }
            else
            {
                Console.Write(" (R)");
            }

            Console.WriteLine();

            PrintTree(node.left, indent + 4);
        }

    }

}
