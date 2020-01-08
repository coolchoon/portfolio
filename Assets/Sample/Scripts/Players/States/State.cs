using UnityEngine;

namespace Sample.Players.States
{
    public abstract class State
    {
        public abstract void Enter(Player player);

        public virtual void Update(Player player) { }
        public virtual void Move(Player player, Vector2 direction) { }
        public virtual void Attack(Player player) { }
    }
}

