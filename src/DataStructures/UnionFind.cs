namespace CodingQuestions.DataStructures
{
    /// <summary>
    /// The union-find data structure is similar to a traditional set data structure in that it contains a collection of unique values.
    /// However, these values are spread out amongst a variety of distinct disjoin sets, meaning that no set can have duplicate values,
    /// and no two sets can contain the same value.
    /// </summary>
    /// <see href="https://www.algoexpert.io/questions/union-find"/>
    internal class UnionFind
    {
        private Dictionary<int, int> valueToSet = new Dictionary<int, int>();
        private List<HashSet<int>?> sets = new List<HashSet<int>?>();

        // Time: O(1)
        // Space: O(1)
        public void CreateSet(int value)
        {
            if (valueToSet.ContainsKey(value)) return;

            var newSet = new HashSet<int> { value };
            sets.Add(newSet);

            valueToSet[value] = sets.Count - 1;
        }

        // Time: O(1)
        // Space: O(1)
        public int? Find(int value)
        {
            if (!valueToSet.ContainsKey(value)) return null;
            var @set = sets[valueToSet[value]];
            return @set?.First();
        }

        // Time: O(n) where n is the number of elements in the smaller set
        // Space: O(1)
        public void Union(int valueOne, int valueTwo)
        {
            if (!valueToSet.ContainsKey(valueOne) || !valueToSet.ContainsKey(valueTwo)) return;

            var set1Index = valueToSet[valueOne];
            var set2Index = valueToSet[valueTwo];

            if (set1Index == set2Index) return;

            var set1 = sets[set1Index];
            var set2 = sets[set2Index];

            var smallSet = set1.Count < set2.Count ? set1 : set2;
            var smallSetIndex = set1.Count < set2.Count ? set1Index : set2Index;

            var bigSet = set1.Count >= set2.Count ? set1 : set2;
            var bigSetIndex = set1.Count >= set2.Count ? set1Index : set2Index;

            foreach (var value in smallSet)
            {
                valueToSet[value] = bigSetIndex;
                bigSet.Add(value);
            }

            sets[smallSetIndex] = null;
        }
    }
}
