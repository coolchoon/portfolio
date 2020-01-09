using UnityEngine;

namespace Sample
{
    public class Movement
    {
        public static void Move(Transform transform, Vector2 direction, float speed)
        {
            transform.Translate(Time.deltaTime * direction * speed);
        }
    }
}