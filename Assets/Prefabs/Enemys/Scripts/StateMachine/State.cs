using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> transitions;
    protected Character Target { get; private set; }
    public void Enter(Character target)
    {
        if (enabled==false)
        {
            Target = target;
            enabled = true;
            foreach (var transition in transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }
    public void Exit()
    {
        if (enabled==true)
        {
            foreach (var transition in transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }
    public State GetNext()
    {
        foreach (var transition in transitions)
        {
            if (transition.NeedTransit)
            {
              return  transition.TargetState;
            }
        }
        return null;
    }
}
