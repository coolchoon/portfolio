using UnityEngine;

namespace Sample.Players.States
{
    public class StandState : State
    {
        public override void Enter(Player player)
        {
            player.Animator.Play("Stand");
        }

        public override void Update(Player player)
        {
            //..
        }

        public override void Move(Player player, Vector2 direction)
        {
            if(direction != Vector2.zero)
            {
                player.SetDirection(direction);
                player.SetState<MoveState>();
            }
        }

        public override void Attack(Player player)
        {
            player.SetState<AttackState>();
        }
    }
}