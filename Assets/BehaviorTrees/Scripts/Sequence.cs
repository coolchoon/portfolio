namespace BehaviorTrees
{
    public class Sequence : CompositeNode
    {
        public override bool Invoke()
        {
            foreach (Node node in GetChildren())
            {
                if (!node.Invoke())
                    return false;
            }

            return true;
        }
    }
}