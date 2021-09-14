using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBornedTransiition : Transition
{
 
    [SerializeField] private AnimationClip born;
    private float _lenghtAnim;
    private float counter=0;
    private void Start()
    {
        _lenghtAnim = born.length;
    }
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter>=_lenghtAnim)
        {
            NeedTransit = true;
        }
    }
}
