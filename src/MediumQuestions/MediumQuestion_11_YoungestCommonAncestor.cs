namespace CodingQuestions.MediumQuestions
{
    /// <see href="https://www.algoexpert.io/questions/youngest-common-ancestor"/>
    /// Time: O(d) where d is the maximum depth of two given descendants
    /// Space: O(1)
    internal class MediumQuestion_11_YoungestCommonAncestor
        : CodingQuestion<MediumQuestion_11_YoungestCommonAncestor.Input, MediumQuestion_11_YoungestCommonAncestor.AncestralTree>
    {
        protected override AncestralTree ExecuteSolution(Input input)
        {
            var descendantOne = input.DescendantOne;
            var descendantTwo = input.DescendantTwo;

            var depthOne = GetDepth(descendantOne);
            var depthTwo = GetDepth(descendantTwo);

            // First, we make sure both descendants are at the same depth.
            if (depthOne > depthTwo)
            {
                descendantOne = Move(descendantOne, depthOne - depthTwo);
            }
            else if (depthTwo > depthOne)
            {
                descendantTwo = Move(descendantTwo, depthTwo - depthOne);
            }

            // Now, we traverse upwards until we reach a common ancestor.
            while (descendantOne != descendantTwo)
            {
                descendantOne = descendantOne!.Ancestor;
                descendantTwo = descendantTwo!.Ancestor;
            }

            return descendantOne!;
        }

        // Calculate the depth of a given descendant.
        // Time: O(d) where d is the depth of the given descendant
        // Space: O(1)
        private static int GetDepth(AncestralTree descendant)
        {
            var depth = 0;
            while (descendant.Ancestor != null)
            {
                descendant = descendant.Ancestor;
                depth++;
            }

            return depth;
        }

        // Return an ancestor of a given descendant in a given distance towards root.
        // Time: O(d) where d is the distance to move towards root
        // Space: O(1)
        private static AncestralTree Move(AncestralTree descendant, int distance)
        {
            for (var i = 0; i < distance; i++)
                descendant = descendant.Ancestor!;

            return descendant;
        }

        protected override bool CompareActualAndExpectedOuputs(AncestralTree expected, AncestralTree actual)
        {
            return expected == actual;
        }

        protected override IReadOnlyDictionary<Input, AncestralTree> GetTests()
        {
            var a = new AncestralTree('A');
            var b = new AncestralTree('B') { Ancestor = a };
            var d = new AncestralTree('D') { Ancestor = b };
            var e = new AncestralTree('E') { Ancestor = b };
            var i = new AncestralTree('I') { Ancestor = d };

            return new Dictionary<Input, AncestralTree>
            {
                {
                    new Input
                    {
                        DescendantOne = e,
                        DescendantTwo = i
                    },
                    b
                }
            };
        }

        internal class AncestralTree
        {
            public char Name;
            public AncestralTree? Ancestor;

            public AncestralTree(char name)
            {
                Name = name;
            }
        }

        internal class Input
        {
            public required AncestralTree DescendantOne { get; set; }
            public required AncestralTree DescendantTwo { get; set; }
        }
    }
}
