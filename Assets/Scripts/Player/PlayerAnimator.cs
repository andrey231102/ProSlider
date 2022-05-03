using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartJumpAnimation()
    {
        _animator.transform.rotation = Quaternion.Euler(Vector3.zero);
        _animator.Play("Jumping");
    }
}
