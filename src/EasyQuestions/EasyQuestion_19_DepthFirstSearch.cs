namespace CodingQuestions.EasyQuestions
{
    /// <see href="https://www.algoexpert.io/questions/depth-first-search"/>
    /// Time: O(v + e) where v is the number of vertices, e is the number of edges
    /// Space: O(v)
    internal class EasyQuestion_19_DepthFirstSearch : CodingQuestion<EasyQuestion_19_DepthFirstSearch.Node, List<string>>
    {
        protected override List<string> ExecuteSolution(Node input)
        {
            var result = new List<string>();
            SearchDepthFirst(input, result);
            return result;
        }

        private void SearchDepthFirst(Node node, List<string> result)
        {
            result.Add(node.Name);
            foreach (var child in node.Children)
            {
                SearchDepthFirst(child, result);
            }
        }

        protected override bool CompareActualAndExpectedOuputs(List<string> expected, List<string> actual)
        {
            if (expected.Count != actual.Count) return false;
            for (var i = 0; i < expected.Count; i++)
            {
                if (actual[i] != expected[i]) return false;
            }

            return true;
        }

        protected override IReadOnlyDictionary<Node, List<string>> GetTests()
        {
            /*
                    A
                  / | \
                 B  C  D
                / \   / \
               E   F G   H
                  / \ \
                 I   J K
             */
            var root = new Node("A");
            root.AddChild("B");

            var b = root.Children.Last();
            b.AddChild("E").AddChild("F");

            var f = b.Children.Last();
            f.AddChild("I").AddChild("J");

            root.AddChild("C").AddChild("D");

            var d = root.Children.Last();
            d.AddChild("G");

            var g = d.Children.Last();
            g.AddChild("K");

            d.AddChild("H");

            return new Dictionary<Node, List<string>>
            {
                { root, new List<string> { "A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H" } },
            };
        }

        internal class Node
        {
            public string Name;
            public List<Node> Children = new();

            public Node(string name)
            {
                Name = name;
            }

            public Node AddChild(string name)
            {
                Node child = new Node(name);
                Children.Add(child);
                return this;
            }
        }
    }
}
