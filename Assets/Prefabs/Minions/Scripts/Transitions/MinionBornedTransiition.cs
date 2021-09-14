
using UnityEngine;

public class MinionBornedTransiition : Transition
{
 
   
    [SerializeField] private float _lenghtAnim;
    private float counter=0;
   
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter>=_lenghtAnim)
        {
            NeedTransit = true;
        }
    }
}
