using System.Collections;
using BehaviorTrees;
using UnityEngine;
using Sample.Enemies.Behaviors;

namespace Sample.Enemies
{
    public class Enemy : Character
    {
        public Vector2 SpawnPosition { get; private set; }
        public float PatrolRange { get { return _patrolRange; } }

        [SerializeField]
        float _patrolRange;

        protected override void Awake()
        {
            base.Awake();

            SpawnPosition = transform.position;
        }

        IEnumerator Start()
        {
            Sequence root = new Sequence();

            Selector selector = new Selector();

            Sequence attackSequence = new Sequence();

            Node isAlivedBehavior = new IsAlivedBehavior(this);
            Node detectBehavior = new DetectBehavior(this);
            Node attackBehavior = new AttackBehavior(this);
            Node patrolBehavior = new PatrolBehavior(this);

            root.AddChild(selector);

            root.AddChild(isAlivedBehavior);

            selector.AddChild(attackSequence);

            attackSequence.AddChild(detectBehavior);
            attackSequence.AddChild(attackBehavior);

            selector.AddChild(patrolBehavior);

            while (root.Invoke())
            {
                yield return null;
            }
        }
    }
}