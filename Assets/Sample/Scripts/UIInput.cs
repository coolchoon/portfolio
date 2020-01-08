using System;
using UnityEngine;

namespace Sample
{
    public class UIInput : MonoBehaviour
    {
        public Action<Vector2> onDirection;
        public Action onAttackDown;

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                onDirection?.Invoke(Vector2.left);
            else if (Input.GetKey(KeyCode.RightArrow))
                onDirection?.Invoke(Vector2.right);
            else
                onDirection?.Invoke(Vector2.zero);


            if (Input.GetKeyDown(KeyCode.Space))
                onAttackDown?.Invoke();
        }
    }
}