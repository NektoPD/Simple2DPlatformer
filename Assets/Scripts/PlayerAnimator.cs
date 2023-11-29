using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string JumpComponentName = "Jump";
    private const string SpeedComponentName = "Speed";

    private Animator _animator;

    public void ActivateRunAnimation(float speed)
    {
        _animator.SetFloat(SpeedComponentName, speed);
    }

    public void ActivateJumpingAnimation()
    {
        _animator.SetTrigger(JumpComponentName);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
