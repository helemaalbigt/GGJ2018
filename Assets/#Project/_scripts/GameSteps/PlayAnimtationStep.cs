using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayAnimtationStep : GameStep
{
    [Space(15)]
    public bool _waitForAnimToFinish;
    public Animator _animator;
    public string _animation;

    public override void StartStep() {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation() {
        _animator.Play(_animation);
        yield return _waitForAnimToFinish ? new WaitForSeconds(_animation.Length) : null;
        Next();
    }
}
