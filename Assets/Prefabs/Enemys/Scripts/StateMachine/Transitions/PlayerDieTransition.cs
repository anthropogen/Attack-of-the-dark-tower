

public class PlayerDieTransition: Transition
{
    private void Update()
    {
        if (Target.IsDeath)
        {
            var stateMachine = GetComponent<EnemyStateMachine>();
            stateMachine.ChangeTarget(stateMachine.Player);
            if (stateMachine.Player==null)
            {
                NeedTransit = true;
            }
        }
    }
}
