using BehaviorTrees;
using Weapon = Sample.Enemies.Weapon;

namespace Sample.Enemies.Behaviors
{
    public class AttackBehavior : Node
    {
        Enemy _enemy;

        public AttackBehavior(Enemy enemy)
        {
            _enemy = enemy;
        }

        public override bool Invoke()
        {
            _enemy.Attack();

            return true;
        }
    }
}