using UnityEngine;
using Sample.Players.States;

namespace Sample.Players
{
    public class Player : Character
    {
        public float AttackRange { get { return _attackRange; } }
        public int AttackPoint { get { return _attackPoint; } }

        [Header("Player")]
        [SerializeField]
        float _attackRange;
        [SerializeField]
        int _attackPoint;
        
        State _state;

        void Start()
        {
            SetState<StandState>();
        }

        void Update()
        {
            _state.Update(this);
        }

        public void SetState<T>() where T : State, new()
        {
            _state = new T();
            _state.Enter(this);
        }

        public void InputMove(Vector2 direction)
        {
            _state.Move(this, direction);
        }

        public void InputAttack()
        {
            _state.Attack(this);
        }
    }
}