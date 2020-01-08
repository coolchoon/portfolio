using BehaviorTrees;
using UnityEngine;

namespace Sample.Enemies.Behaviors
{
    public class PatrolBehavior : Node
    {
        Enemy _enemy;

        public PatrolBehavior(Enemy enemy)
        {
            _enemy = enemy;
        }

        public override bool Invoke()
        {
            Vector2 distacne = _enemy.SpawnPosition - (Vector2)_enemy.transform.position;

            if (distacne.x < -_enemy.PatrolRange)
                _enemy.SetDirection(_enemy.Direction * -1f);
            else if(_enemy.PatrolRange < distacne.x)
                _enemy.SetDirection(_enemy.Direction * -1f);

            _enemy.Move(_enemy.Direction, _enemy.MoveSpeed);

            return true;
        }
    }
}