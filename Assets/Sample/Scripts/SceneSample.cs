using UnityEngine;
using Sample.Players;

namespace Sample
{
    public class SceneSample : MonoBehaviour
    {
        [SerializeField]
        UIInput _uiInput;

        [SerializeField]
        Player _player;

        void Awake()
        {
            _uiInput.onDirection = _player.InputMove;
            _uiInput.onAttackDown = _player.InputAttack;

            _player.onDead = () => {
                _uiInput.onDirection = null;
                _uiInput.onAttackDown = null;
            };
        }
    }
}