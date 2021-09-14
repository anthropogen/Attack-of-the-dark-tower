using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{
   
  private  void Update()
    {
        if (Target == null)
        {
          var stateMachine=  GetComponent<EnemyStateMachine>();
            stateMachine.ChangeTarget(stateMachine.Player);
            if (stateMachine.Player!=null)
            {
                NeedTransit = true;
            }
        }
    }
}
