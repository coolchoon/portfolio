using System;
using System.Collections.Generic;

namespace BehaviorTrees
{
    public class Selector : CompositeNode
    {
        public override bool Invoke()
        {
            foreach (Node node in GetChildren())
            {
                if (node.Invoke())
                    return true;
            }

            return false;
        }
    }
}