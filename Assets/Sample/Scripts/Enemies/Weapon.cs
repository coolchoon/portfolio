using System;
using UnityEngine;

namespace Sample.Enemies
{
    [Serializable]
    public class Weapon : Sample.Weapon
    {
        public float AttackRange { get { return _attackRange; } }

        [SerializeField]
        Enemy _enemy;
        [SerializeField]
        Bullet _bulletOrigin;
        [SerializeField]
        float _attackRange;

        public override void Attack()
        {
            Character player = _enemy.Detect(_enemy.Direction, _attackRange, "Player");

            if (player != null)
            {
                Bullet bullet = Instantiate(_bulletOrigin);
                bullet.transform.position = _enemy.transform.position;
                bullet.SetDirection(_enemy.Direction);
                bullet.SetTarget(LayerMask.NameToLayer("Player"));
;            }
        }
    }
}

