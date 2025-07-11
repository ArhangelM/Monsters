using UnityEngine;

namespace Assets.Monsters.Scripts.Runtime.Player
{
    [RequireComponent(typeof(Animator))]
    public partial class Character 
    {
        [SerializeField] private Animator _animator;
        
        private void PlayAnimation()
        {
            _animator.SetBool("IsWalk", _horizontalInput != 0);
            _animator.SetBool("IsGround", _isGround);
            _animator.SetBool("IsRun", _isRun);

            if (_jumpInput > 0 && _isGround)
                _animator.SetTrigger("IsJump");
        }
    }
}
