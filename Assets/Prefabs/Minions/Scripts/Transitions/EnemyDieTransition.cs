

public class EnemyDieTransition : Transition
{
    private void Update()
    {
        if (Target.IsDeath)
        {
            NeedTransit = true;
        }
    }
}
