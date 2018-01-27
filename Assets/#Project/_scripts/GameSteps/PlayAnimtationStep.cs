using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayAnimtationStep : GameStep
{
    public Animator _animator;
    public string _animation;

    public override void StartStep() {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation() {
        _animator.Play(_animation);

        while (_animator.GetCurrentAnimatorStateInfo(0).IsName(_animation)) 
            yield return null;

        Next();
    }
}
