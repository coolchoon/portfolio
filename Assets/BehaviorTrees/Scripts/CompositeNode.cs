using System;
using System.Collections.Generic;

namespace BehaviorTrees
{
    public class CompositeNode : Node
    {
        List<Node> _children = new List<Node>();

        public List<Node> GetChildren()
        {
            return _children;
        }

        public void AddChild(Node node)
        {
            _children.Add(node);
        }

        public override bool Invoke()
        {
            return true;
        }
    }
}

