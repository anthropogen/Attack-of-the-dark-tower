using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> transitions;
    protected Player Target { get; private set; }
}
