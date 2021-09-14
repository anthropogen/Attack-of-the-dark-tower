

public class EnemyDieTransition : Transition
{
    private void Update()
    {
        if (Target==null)
        {
            NeedTransit = true;
        }
    }
}
