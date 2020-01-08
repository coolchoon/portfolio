using UnityEngine;

namespace Sample.Players.States
{
    public class MoveState : State
    {
        public override void Enter(Player player)
        {
            player.Animator.Play("Move");
        }

        public override void Update(Player player)
        {
            player.Move(player.Direction, player.MoveSpeed);
        }

        public override void Move(Player player, Vector2 direction)
        {
            if(direction == Vector2.zero)
            {
                player.SetState<StandState>();
            }
            else
            {
                player.SetDirection(direction);
            }
        }

        public override void Attack(Player player)
        {
            player.SetState<AttackState>();
        }
    }
}