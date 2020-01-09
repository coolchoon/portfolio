using UnityEngine;
using Sample.Players;

namespace Sample
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        float _moveSpeed;
        [SerializeField]
        int _attackPoint;

        Vector2 _direction;
        LayerMask _targetLayer;

        void Update()
        {
            Movement.Move(transform, _direction, _moveSpeed);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.layer == _targetLayer.value)
            {
                Character target = collision.GetComponent<Character>();
                target.ApplyDamage(_attackPoint);
                Destroy(gameObject);
            }
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void SetTarget(LayerMask layer)
        {
            _targetLayer = layer;
        }
    }
}