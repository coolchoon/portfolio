using System;
using System.Collections;
using UnityEngine;

namespace Sample
{
    public class Character : MonoBehaviour
    {
        public Action onDead;
        public Action<int> onHealthPointChanged;

        public Vector2 Direction { get; private set; } = Vector2.right;
        public float MoveSpeed { get { return _moveSpeed; } }
        public Weapon Weapon { get { return _weapon; } }
        public bool Attackable { get { return _attackable; } }
        public Animator Animator { get; private set; }

        [Header("Base")]
        [SerializeField]
        Weapon _weapon;
        [SerializeField]
        int _healthPoint;
        [SerializeField]
        float _moveSpeed;
        

        SpriteRenderer _renderer;
        bool _attackable = true;

        protected virtual void Awake()
        {
            Animator = GetComponent<Animator>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        IEnumerator AttackRoutine()
        {
            _attackable = false;

            _weapon.Attack();

            yield return new WaitForSeconds(_weapon.AttackSpeed);

            _attackable = true;
        }

        public void SetDirection(Vector2 direction)
        {
            Direction = direction;

            _renderer.flipX = Direction == Vector2.left;
        }

        public void ApplyDamage(int attackPoint)
        {
            Animator.Play("Attacked", 0, 0f);

            _healthPoint -= attackPoint;

            if (_healthPoint < 0)
                _healthPoint = 0;

            onHealthPointChanged?.Invoke(_healthPoint);

            if (_healthPoint == 0)
            {
                onDead?.Invoke();
                Destroy(gameObject);
            }
        }

        public Character Detect(Vector2 direction, float distance, string layer)
        {
            Vector2 origin = transform.position;
            LayerMask mask = 1 << LayerMask.NameToLayer(layer);
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, mask);

            if (hit.collider != null)
            {
                Character target = hit.collider.GetComponent<Character>();
                return target;
            }

            return null;
        }

        public void Move(Vector2 direction, float speed)
        {
            if(direction != Vector2.zero)
            {
                SetDirection(direction);

                Movement.Move(transform, direction, speed);
            }
        }

        public void Attack()
        {
            if (_attackable)
                StartCoroutine(AttackRoutine());
        }
    }
}
