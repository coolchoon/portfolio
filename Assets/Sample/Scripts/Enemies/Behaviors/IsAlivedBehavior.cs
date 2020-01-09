using BehaviorTrees;

namespace Sample.Enemies.Behaviors
{
    public class IsAlivedBehavior : Node
    {
        Enemy _enemy;

        public IsAlivedBehavior(Enemy enemy)
        {
            _enemy = enemy;
        }

        public override bool Invoke()
        {
            return _enemy != null;
        }
    }
}