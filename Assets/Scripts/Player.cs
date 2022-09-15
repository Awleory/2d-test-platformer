using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _hitHurtTime = 0.5f;
    [SerializeField] private float _hitInvincibleTime = 1.5f;
    [SerializeField] private UnityEvent _gotDamage;

    public bool IsHurt { get; private set; }
    public bool Invincible { get; private set; }


    private Coroutine _hurtCoroutine;
    private Coroutine _invincibleCoroutine;

    public void TakeDamage()
    {
        if (_hurtCoroutine == null && _invincibleCoroutine == null)
        {
            IsHurt = true;
            _hurtCoroutine = StartCoroutine(WaitHitHurtTime());

            Invincible = true;
            _invincibleCoroutine = StartCoroutine(WaitHitInvincibleTime());

            _gotDamage?.Invoke();
        }
    }

    private IEnumerator WaitHitHurtTime()
    {
        yield return new WaitForSeconds(_hitHurtTime);
        IsHurt = false;
        _hurtCoroutine = null;
    }

    private IEnumerator WaitHitInvincibleTime()
    {
        yield return new WaitForSeconds(_hitInvincibleTime);
        Invincible = false;
        _invincibleCoroutine = null;
    }


}
