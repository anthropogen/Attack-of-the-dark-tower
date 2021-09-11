using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State targetState;
    protected Character Target { get; private set; }
    public State TargetState => targetState;
    public bool NeedTransit { get; protected set; }
    internal void Init(Character target)
    {
        Target = target ;
    }
    private void OnEnable()
    {
        NeedTransit = false;
    }
}
