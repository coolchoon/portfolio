using UnityEngine;

namespace Sample.Players.States
{
    public class AttackState : State
    {
        public override void Enter(Player player)
        {
            player.Attack();
        }

        public override void Update(Player player)
        {
            if (player.Attackable)
                player.SetState<StandState>();
        }
    }
}