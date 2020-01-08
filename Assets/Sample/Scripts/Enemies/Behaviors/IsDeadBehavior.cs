using BehaviorTrees;

namespace Sample.Enemies.Behaviors
{
    public class IsDeadBehavior : Node
    {
        Enemy _enemy;

        public IsDeadBehavior(Enemy enemy)
        {
            _enemy = enemy;
        }

        public override bool Invoke()
        {
            return _enemy == null;
        }
    }
}