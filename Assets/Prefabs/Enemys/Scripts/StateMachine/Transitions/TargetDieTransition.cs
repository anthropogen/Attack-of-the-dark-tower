using UnityEngine;

public class TargetDieTransition : Transition
{
   
  private  void Update()
    {
        if (Target.IsDeath)
        {
          var stateMachine=  GetComponent<EnemyStateMachine>();
            stateMachine.ChangeTarget(stateMachine.Player);
            if (!stateMachine.Player.IsDeath)
            {
                NeedTransit = true;
            }
        }
    }
}
