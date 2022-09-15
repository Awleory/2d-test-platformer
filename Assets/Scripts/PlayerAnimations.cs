using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Player), typeof(MoveController))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    private MoveController _moveController;

    private const string _nameValueOfJumped = "jumped";
    private const string _nameValueOfSpeed = "speed";
    private const string _nameValueOfVelocityY = "velocityY";
    private const string _nameValueOfGrounded = "grounded";
    private const string _nameValueOfHurt = "hurt";
    private const string _nameValueOfInvincible = "invincible";

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
        _moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        UpdateAnimationParameters();    
    }

    private void UpdateAnimationParameters()
    {
        _animator.SetBool(_nameValueOfGrounded, _moveController.Grounded);
        _animator.SetBool(_nameValueOfJumped, _moveController.Jumped);
        _animator.SetFloat(_nameValueOfVelocityY, _moveController.VelocityY);
        _animator.SetFloat(_nameValueOfSpeed, Mathf.Abs(_moveController.VelocityX));
        _animator.SetBool(_nameValueOfHurt, _player.IsHurt);
        _animator.SetBool(_nameValueOfInvincible, _player.Invincible);
    }
}
