using UnityEngine;

namespace Sample
{
    public abstract class Weapon : MonoBehaviour
    {
        public float AttackSpeed { get { return _attackSpeed; } }

        [Header("Base")]
        [SerializeField]
        float _attackSpeed;

        public abstract void Attack();
    }
}