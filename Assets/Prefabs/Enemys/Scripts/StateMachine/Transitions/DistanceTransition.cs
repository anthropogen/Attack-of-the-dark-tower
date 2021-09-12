using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float distanceTransition;
    [SerializeField] private float distancePlayerAttackTransition;
    [SerializeField] private float rangeSpread;
   
    private void Start()
    {
        distanceTransition =RandomDistance(distanceTransition);
        distancePlayerAttackTransition = RandomDistance(distancePlayerAttackTransition);
    }
    public float RandomDistance(float distance)
    {
      return distance += Random.Range(-rangeSpread, rangeSpread);
    }
    private void Update()
    {
        if (Target!=null)
        {
        if (Vector2.Distance(transform.position, Target.transform.position) < distanceTransition)
        {
            NeedTransit = true;
        }
        else if (Target.GetType() == typeof(Player))
        {
            if (Vector2.Distance(transform.position, Target.transform.position) < distancePlayerAttackTransition)
            {
                NeedTransit = true;
            }
        } 
    }
    }
}
