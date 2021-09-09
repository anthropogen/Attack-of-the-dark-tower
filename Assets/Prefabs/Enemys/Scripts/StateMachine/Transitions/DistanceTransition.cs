using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float distanceTransition;
    [SerializeField] private float rangeSpread;
    private void Start()
    {
        distanceTransition += Random.Range(-rangeSpread, rangeSpread);
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position,Target.transform.position)<distanceTransition)
        {
            NeedTransit = true;
        }
    }
}
