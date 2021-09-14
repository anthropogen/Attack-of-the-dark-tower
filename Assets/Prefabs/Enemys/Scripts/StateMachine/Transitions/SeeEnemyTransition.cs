
using UnityEngine;

public class SeeEnemyTransition : Transition
{
    [SerializeField] private float distanceView;
    [SerializeField] private int layerNumber;
    private void OnValidate()
    {
        if (layerNumber<0)
        {
            layerNumber = 0;
        }
    }
    void Update()
    {
      RaycastHit2D[] hits=Physics2D.CircleCastAll(transform.position, distanceView, Vector2.zero);
        if (hits.Length>0)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.layer==layerNumber)
                {
                    if (hit.transform.gameObject.TryGetComponent<Character>(out Character target))
                    {
                        GetComponent<EnemyStateMachine>().ChangeTarget(target);
                        NeedTransit = true;
                    }
                }
            }              
        }
    }
}
