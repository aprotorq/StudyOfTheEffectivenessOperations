// Klasa reprezentująca drzewo czerwono-czarne
using StudyOfTheEffectivenessOperations.Helpers;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
namespace StudyOfTheEffectivenessOperations.Operation.BlackRedTreeOperation
{
    public class BlackRedTreeOperation
    {
        
       private Node _root = null;
       
        private int numberCount;
        private int numberCountToRemove;
        private Stopwatch sw = Stopwatch.StartNew();
        private Random rnd = new Random();
        public int count;
        const int maxValue = 100000;
        public int NumberCount { get => numberCount; set => numberCount = value; }
        public int NumberCountToRemove { get => numberCountToRemove; set => numberCountToRemove = value; }
        public BlackRedTreeOperation()
        {
            NumberCount = VariablesManager.RandomNumberCount;
            NumberCountToRemove = VariablesManager.NumberCountToRemove;
            count = VariablesManager.IsManual == true ? VariablesManager.Array.Length : VariablesManager.QuantityToAutoFill;
            Menu();
        }
        public void Menu()
        {
            string menu = $"Wybierz numer wskazujący która akcja ma zostać wykonana wykonać na drzewie czarno czerwonym. \r\n";
            menu += "Każda wybrana akcja zostanie powtórzona w pętli 100 razy \r\n ";
            menu += "(za każdym razem zostanie wygenerowany nowy zestaw danych - nie dla testu manualnego) a czas wykonania uśredniony \r\n";
            menu += $"W przypadku operacji dodawania, najpierw zostanie wygenerowanych {count} liczb a dopiero potem eksperymenty \r\n";
            menu += $"----------------------------\r\n";
            menu += $"[1] dodwanie 1 losowej liczby w przedziele 0- {maxValue} (x100) do {count} istniejących (nie dla testu manualnego)\r\n";
            menu += $"[2] usuwanie 1 liczby   drzewa \r\n";
            menu += $"[3] wyszukiwanie w drzewie\r\n";
            menu += $"[4] wyświetl strukturę\r\n";
            menu += "--------------------------------------------------- \r\n";
            menu += "[5] Wyjdź do głównego menu\r\n";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(menu);
            Console.ForegroundColor = ConsoleColor.White;
            string key = Console.ReadLine();

            switch (key)
            {
                case "1":

                    MainMenu.ColorizeString($"dodwanie 1 losowej liczby w przedziele 0 - 1000 000(x100)\r\n");
                    InsertIntoTree();
                    break;
                case "2":
                    MainMenu.ColorizeString($"usunięcie 1 losowej liczby w przedziele 0- 1000 000 (x100) z drzewa\r\n");
                    Delete();
                    break;
                case "3":
                    MainMenu.ColorizeString($"szukanie 1  liczbyw drzewie\r\n");
                    Find();
                    break;
                case "4":
                    MainMenu.ColorizeString($"wyśiwltam strukturę\r\n");
                    PrintTree();
                    break;
                case "5":
                    MainMenu.ShowMenu();
                    break;
                default:
                    Menu();
                    break;
            }
        }
        // Metoda wykonująca rotację w lewo
        private void RotateLeft(Node node)
        {
            Node right_child = node.RightChild;
            node.RightChild = right_child.LeftChild;
            if (right_child.LeftChild != null)
            {
                right_child.LeftChild.Parent = node;
            }
            right_child.Parent = node.Parent;
            if (node.Parent == null)
            {
                _root = right_child;
            }
            else if (node == node.Parent.LeftChild)
            {
                node.Parent.LeftChild = right_child;
            }
            else
            {
                node.Parent.RightChild = right_child;
            }
            right_child.LeftChild = node;
            node.Parent = right_child;
        }

        // Metoda wykonująca rotację w prawo
        private void RotateRight(Node node)
        {
            Node left_child = node.LeftChild;
            node.LeftChild = left_child.RightChild;
            if (left_child.RightChild != null)
            {
                left_child.RightChild.Parent = node;
            }
            left_child.Parent = node.Parent;
            if (node.Parent == null)
            {
                _root = left_child;
            }
            else if (node == node.Parent.RightChild)
            {
                node.Parent.RightChild = left_child;
            }
            else
            {
                node.Parent.LeftChild = left_child;
            }
            left_child.RightChild = node;
            node.Parent = left_child;
        }

        // Metoda dodająca wartość do drzewa
        public void InsertIntoTree()
        {
            Console.Clear();
            double[] times = new double[100];

            int iterations = 100;
          
            Console.WriteLine("Czekaj...");
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    sw.Restart();
                    for (int j = 0; j < count; j++)
                    {
                        Node node = new Node(VariablesManager.Array[j], "red");
                        Node parent = null;
                        Node current = _root;
                        while (current != null)
                        {
                            parent = current;
                            if (node.Value < current.Value)
                            {
                                current = current.LeftChild;
                            }
                            else
                            {
                                current = current.RightChild;
                            }
                        }
                        node.Parent = parent;
                        if (parent == null)
                        {
                            _root = node;
                        }
                        else if (node.Value < parent.Value)
                        {
                            parent.LeftChild = node;
                        }
                        else
                        {
                            parent.RightChild = node;
                        }
                        FixTreeAfterInsertion(node);
                    }
                    sw.Stop();
                }
                else
                {
                    sw.Restart();
                    for (int j = 0; j < count; j++)
                    {
                        Node node = new Node(rnd.Next(maxValue), "red");
                        Node parent = null;
                        Node current = _root;
                        while (current != null)
                        {
                            parent = current;
                            if (node.Value < current.Value)
                            {
                                current = current.LeftChild;
                            }
                            else
                            {
                                current = current.RightChild;
                            }
                        }
                        node.Parent = parent;
                        if (parent == null)
                        {
                            _root = node;
                        }
                        else if (node.Value < parent.Value)
                        {
                            parent.LeftChild = node;
                        }
                        else
                        {
                            parent.RightChild = node;
                        }
                        FixTreeAfterInsertion(node);
                    }
                    sw.Stop();
                }
                times[i] = sw.Elapsed.TotalMilliseconds;
                
            }
                Console.Clear();
                Console.WriteLine($"Czas najmniejszy: {times.Min()}, czas najwiekszy: {times.Max()}, czas średni: {times.Average()} ms");
                Console.WriteLine("Koniec zadania 1.");
                Menu();
            
        }

        // Metoda naprawiająca drzewo po dodaniu węzła
        private void FixTreeAfterInsertion(Node node)
        {
            while (node.Parent != null && node.Parent.Color == "red")
            {
                if (node.Parent == node.Parent.Parent.LeftChild)
                {
                    Node uncle = node.Parent.Parent.RightChild;
                    if (uncle != null && uncle.Color == "red")
                    {
                        node.Parent.Color = "black";
                        uncle.Color = "black";
                        node.Parent.Parent.Color = "red";
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.RightChild)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.Color = "black";
                        node.Parent.Parent.Color = "red";
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    Node uncle = node.Parent.Parent.LeftChild;
                    if (uncle != null && uncle.Color == "red")
                    {
                        node.Parent.Color = "black";
                        uncle.Color = "black";
                        node.Parent.Parent.Color = "red";
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.LeftChild)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.Color = "black";
                        node.Parent.Parent.Color = "red";
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }
            _root.Color = "black";
        }
        public void Find()
        {
            double[] times = new double[100];
            int iterations = 100;
            int userNumber = 0;
            if (VariablesManager.IsManual)
            {
                Console.WriteLine("Podaj liczbę, którą chcesz znaleść");
                Int32.TryParse(Console.ReadLine(), out userNumber);

            }
            for (int i = 0; i < iterations; i++)
            {
                if (VariablesManager.IsManual)
                {
                    for (int j = 0; j < count; j++)
                    {
                       
                        Node new_node = new Node(VariablesManager.Array[j], "red");
                        Node parent = null;
                        Node current = _root;
                        while (current != null)
                        {
                            parent = current;
                            if (new_node.Value < current.Value)
                            {
                                current = current.LeftChild;
                            }
                            else
                            {
                                current = current.RightChild;
                            }
                        }
                        new_node.Parent = parent;
                        if (parent == null)
                        {
                            _root = new_node;
                        }
                        else if (new_node.Value < parent.Value)
                        {
                            parent.LeftChild = new_node;
                        }
                        else
                        {
                            parent.RightChild = new_node;
                        }
                        FixTreeAfterInsertion(new_node);
                    }
                    sw.Restart();
                    Node node = FindNode(userNumber);
                    sw.Stop();
                    if (node == null)
                    {
                        MainMenu.ColorizeString("Nie ma takiej liczby w zbiorze", ConsoleColor.Red);
                    }
                    else
                    {
                        MainMenu.ColorizeString("Taka liczba istnieje", ConsoleColor.Green);
                    }
                }
                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        Node new_node = new Node(rnd.Next(maxValue), "red");
                        Node parent = null;
                        Node current = _root;
                        while (current != null)
                        {
                            parent = current;
                            if (new_node.Value < current.Value)
                            {
                                current = current.LeftChild;
                            }
                            else
                            {
                                current = current.RightChild;
                            }
                        }
                        new_node.Parent = parent;
                        if (parent == null)
                        {
                            _root = new_node;
                        }
                        else if (new_node.Value < parent.Value)
                        {
                            parent.LeftChild = new_node;
                        }
                        else
                        {
                            parent.RightChild = new_node;
                        }
                        FixTreeAfterInsertion(new_node);
                    }
                    sw.Restart();
                    Node node = FindNode(userNumber);
                    sw.Stop();
                    if (node == null)
                    {
                        MainMenu.ColorizeString("Nie ma takiej liczby w zbiorze", ConsoleColor.Red);
                    }
                    else
                    {
                        MainMenu.ColorizeString("Taka liczba istnieje", ConsoleColor.Green);
                    }
                }
            }
        }
        // Metoda wyszukująca węzeł z wartością
        private Node FindNode(int value)
        {
            Node current = _root;
            while (current != null && current.Value != value)
            {
                if (value < current.Value)
                {
                    current = current.LeftChild;
                }
                else
                {
                    current = current.RightChild;
                }
            }
            return current;
        }
        // Zwraca następnik węzła o podanej wartości
        private Node GetSuccessor(Node node)
        {
            if (node.RightChild != null)
            {
                node = node.RightChild;
                while (node.LeftChild != null)
                {
                    node = node.LeftChild;
                }
                return node;
            }
            else
            {
                Node parent = node.Parent;
                while (parent != null && node == parent.RightChild)
                {
                    node = parent;
                    parent = node.Parent;
                }
                return parent;
            }
        }

        // Metoda usuwająca węzeł o podanej wartości
        public void Delete()
        {
            double[] times = new double[100];
            int iterations = 100;
            
            int userNumber = 0;
            if (VariablesManager.IsManual)
            {
                Console.WriteLine("Podaj liczbę, która ma byc usunięta");
                Int32.TryParse(Console.ReadLine(), out userNumber);
                
            }
            for (int i = 0; i < iterations; i++)
            {

                // Generowanie losowych liczb i dodawanie ich na końcu tablicy
                if (VariablesManager.IsManual)
                {

                    for (int j = 0; j < count; j++)
                    {
                        Node new_node = new Node(VariablesManager.Array[j], "red");
                        Node parent_node = null;
                        Node current = _root;
                        while (current != null)
                        {
                            parent_node = current;
                            if (new_node.Value < current.Value)
                            {
                                current = current.LeftChild;
                            }
                            else
                            {
                                current = current.RightChild;
                            }
                        }
                        new_node.Parent = parent_node;
                        if (parent_node == null)
                        {
                            _root = new_node;
                        }
                        else if (new_node.Value < parent_node.Value)
                        {
                            parent_node.LeftChild = new_node;
                        }
                        else
                        {
                            parent_node.RightChild = new_node;
                        }
                        FixTreeAfterInsertion(new_node);
                    }

                    Node node = FindNode(userNumber);
                    if (node == null)
                    {
                        MainMenu.ColorizeString("Nie ma takiej liczby", ConsoleColor.Yellow);
                    }
                    Node child = null;
                    if (node.LeftChild == null || node.RightChild == null)
                    {
                        child = node;
                    }
                    else
                    {
                        child = GetSuccessor(node);
                    }
                    Node parent = child.Parent;
                    if (child.LeftChild != null)
                    {
                        child.LeftChild.Parent = parent;
                    }
                    if (parent == null)
                    {
                        _root = child.LeftChild;
                    }
                    else if (child == parent.LeftChild)
                    {
                        parent.LeftChild = child.LeftChild;
                    }
                    else
                    {
                        parent.RightChild = child.LeftChild;
                    }
                    if (child.Color == "black")
                    {
                        FixTreeAfterDeletion(child.LeftChild, parent);
                    }
                }
                else
                {

                    for (int j = 0; j < count; j++)
                    {
                        Node new_node = new Node(rnd.Next(maxValue), "red");
                        Node parent_node = null;
                        Node current = _root;
                        while (current != null)
                        {
                            parent_node = current;
                            if (new_node.Value < current.Value)
                            {
                                current = current.LeftChild;
                            }
                            else
                            {
                                current = current.RightChild;
                            }
                        }
                        new_node.Parent = parent_node;
                        if (parent_node == null)
                        {
                            _root = new_node;
                        }
                        else if (new_node.Value < parent_node.Value)
                        {
                            parent_node.LeftChild = new_node;
                        }
                        else
                        {
                            parent_node.RightChild = new_node;
                        }
                        FixTreeAfterInsertion(new_node);
                    }
                    Node node = FindNode(userNumber);
                    if (node == null)
                    {
                        MainMenu.ColorizeString("Nie ma takiej liczby", ConsoleColor.Yellow);
                    }
                    Node child = null;
                    if (node.LeftChild == null || node.RightChild == null)
                    {
                        child = node;
                    }
                    else
                    {
                        child = GetSuccessor(node);
                    }
                    Node parent = child.Parent;
                    if (child.LeftChild != null)
                    {
                        child.LeftChild.Parent = parent;
                    }
                    if (parent == null)
                    {
                        _root = child.LeftChild;
                    }
                    else if (child == parent.LeftChild)
                    {
                        parent.LeftChild = child.LeftChild;
                    }
                    else
                    {
                        parent.RightChild = child.LeftChild;
                    }
                    if (child.Color == "black")
                    {
                        FixTreeAfterDeletion(child.LeftChild, parent);
                    }
                }
            }
            PrintTree();
        }

        // Metoda naprawiająca drzewo po usunięciu węzła
        private void FixTreeAfterDeletion(Node node, Node parent)
        {
            while (node != _root && (node == null || node.Color == "black"))
            {
                if (node == parent.LeftChild)
                {
                    Node sibling = parent.RightChild;
                    if (sibling.Color == "red")
                    {
                        sibling.Color = "black";
                        parent.Color = "red";
                        RotateLeft(parent);
                        sibling = parent.RightChild;
                    }
                    if ((sibling.LeftChild == null || sibling.LeftChild.Color == "black") &&
                        (sibling.RightChild == null || sibling.RightChild.Color == "black"))
                    {
                        sibling.Color = "red";
                        node = parent;
                        parent = node.Parent;
                    }
                    else
                    {
                        if (sibling.RightChild == null || sibling.RightChild.Color == "black")
                        {
                            sibling.LeftChild.Color = "black";
                            sibling.Color = "red";
                            RotateRight(sibling);
                            sibling = parent.RightChild;
                        }
                        sibling.Color = parent.Color;
                        parent.Color = "black";
                        sibling.RightChild.Color = "black";
                        RotateLeft(parent);
                        node = _root;
                    }
                }
                else
                {
                    Node sibling = parent.LeftChild;
                    if (sibling.Color == "red")
                    {
                        sibling.Color = "black";
                        parent.Color = "red";
                        RotateRight(parent);
                        sibling = parent.LeftChild;
                    }
                    if ((sibling.LeftChild == null || sibling.LeftChild.Color == "black") &&
                        (sibling.RightChild == null || sibling.RightChild.Color == "black"))
                    {
                        sibling.Color = "red";
                        node = parent;
                        parent = node.Parent;
                    }
                    else
                    {
                        if (sibling.LeftChild == null || sibling.LeftChild.Color == "black")
                        {
                            sibling.RightChild.Color = "black";
                            sibling.Color = "red";
                            RotateLeft(sibling);
                            sibling = parent.LeftChild;

                        }
                        sibling.Color = parent.Color;
                        parent.Color = "black";
                        sibling.LeftChild.Color = "black";
                        RotateRight(parent);
                        node = _root;
                    }
                }
            }
            if (node != null)
            {
                node.Color = "black";
            }
        }

        // Wyświetla drzewo w formie tekstowej
        public void PrintTree()
        {
            PrintTree(_root, "", true);
        }

        // Metoda pomocnicza do wyświetlania drzewa
        private void PrintTree(Node node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("└─");
                    indent += "  ";
                }
                else
                {
                    Console.Write("├─");
                    indent += "| ";
                }
                Console.WriteLine(node.Value + " (" + node.Color + ")");
                PrintTree(node.LeftChild, indent, false);
                PrintTree(node.RightChild, indent, true);
            }
        }

        // Klasa reprezentująca węzeł drzewa
        class Node
        {
            public int Value { get; set; }
            public string Color { get; set; }
            public Node Parent { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
            public Node(int value, string color = "red" )
            {
                Value = value;
                Color = color;
                Parent = null;
                LeftChild = null;
                RightChild = null;
            }
        }
    }

}