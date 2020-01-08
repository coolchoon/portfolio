using System;
using UnityEngine;

namespace Sample.Players
{
    [Serializable]
    public class Weapon : Sample.Weapon
    {
        [SerializeField]
        float _attackRange;
        [SerializeField]
        int _attackPoint;
        [SerializeField]
        Player _player;

        public override void Attack()
        {
            _player.Animator.Play("Attack", 0, 0f);

            Character enemy = _player.Detect(_player.Direction, _attackRange, "Enemy");
            if(enemy != null)
            {
                enemy.ApplyDamage(_attackPoint);
            }
        }
    }
}

