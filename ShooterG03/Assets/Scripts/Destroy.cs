using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        StartCoroutine(DestroyAfterAnimationCoroutine());
    }

    private IEnumerator DestroyAfterAnimationCoroutine()
    {
        yield return null;
        
        float animationTime = _animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(animationTime);

        Destroy(gameObject);
    }
}
