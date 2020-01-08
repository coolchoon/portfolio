using BehaviorTrees;
using Weapon = Sample.Enemies.Weapon;

namespace Sample.Enemies.Behaviors
{
    public class DetectBehavior : Node
    {
        Enemy _enemy;

        public DetectBehavior(Enemy enemy)
        {
            _enemy = enemy;
        }

        public override bool Invoke()
        {
            Character player = _enemy.Detect(_enemy.Direction, ((Weapon)_enemy.Weapon).AttackRange, "Player");

            return player != null;
        }
    }
}