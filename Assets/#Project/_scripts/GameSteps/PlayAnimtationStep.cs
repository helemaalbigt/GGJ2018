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

       yield return new WaitForSeconds(_animation.Length);

        Next();
    }
}
