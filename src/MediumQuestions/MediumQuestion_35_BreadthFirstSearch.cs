namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/breadth-first-search"/>
    /// Time: O(v + e) where v is the number of vertices, e is the number of edges in a tree
    /// Space: O(v)
    internal class MediumQuestion_35_BreadthFirstSearch : CodingQuestion<MediumQuestion_35_BreadthFirstSearch.Node, List<string>>
    {
        protected override List<string> ExecuteSolution(Node root)
        {
            // We're using a queue to keep track of unvisited nodes.
            // This will make sure they'll be traversed in breadth-first manner.
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            var result = new List<string>();

            while (queue.TryDequeue(out var node))
            {
                result.Add(node.Name);

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        protected override bool CompareActualAndExpectedOuputs(List<string> expected, List<string> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (var i = 0; i < expected.Count; i++)
            {
                if (expected[i] != actual[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<Node, List<string>> GetTests()
        {
            var root = new Node("A");
            root.AddChild("B").AddChild("C").AddChild("D");

            root.Children[0].AddChild("E").AddChild("F");
            root.Children[2].AddChild("G").AddChild("H");

            root.Children[0].Children[1].AddChild("I").AddChild("J");
            root.Children[2].Children[0].AddChild("K");

            return new Dictionary<Node, List<string>>
            {
                { root, new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" } },
            };
        }

        internal class Node
        {
            public string Name { get; set; }
            public List<Node> Children { get; set; } = new List<Node>();

            public Node(string name)
            {
                Name = name;
            }

            public Node AddChild(string name)
            {
                var child = new Node(name);
                Children.Add(child);
                return this;
            }
        }
    }
}
