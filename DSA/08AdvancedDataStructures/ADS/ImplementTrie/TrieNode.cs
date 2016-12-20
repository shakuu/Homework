using System.Collections.Generic;

namespace ImplementTrie
{
    public class TrieNode
    {
        private LinkedList<TrieNode> children;

        public int count { private set; get; }
        public char data { private set; get; }

        public TrieNode(char data = ' ')
        {
            this.data = data;
            count = 0;
            children = new LinkedList<TrieNode>();
        }

        public TrieNode GetChild(char c, bool createIfNotExist = false)
        {
            foreach (var child in children)
            {
                if (child.data == c)
                {
                    return child;
                }
            }

            if (createIfNotExist)
            {
                return CreateChild(c);
            }

            return null;
        }

        public void AddCount()
        {
            count++;
        }

        public TrieNode CreateChild(char c)
        {
            var child = new TrieNode(c);
            children.AddLast(child);

            return child;
        }
    }
}