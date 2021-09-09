using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State targetState;
    protected Player Target { get; private set; }
    public State TargetState => targetState;
    public bool NeedTransit { get; protected set; }
    internal void Init(Player target)
    {
        Target = target ;
    }
    private void OnEnable()
    {
        NeedTransit = false;
    }
}
