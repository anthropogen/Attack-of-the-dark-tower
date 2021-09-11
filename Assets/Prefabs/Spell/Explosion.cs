using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float delayBeforeExplode;
    [SerializeField] private float delayAfterExplode;
    [SerializeField] private int layerNumber;
    [SerializeField] private float radius;

    private void OnValidate()
    {
        if (layerNumber<0)
        {
            layerNumber = 0;
        }
    }
    public void InitExplode(float radius,float damage)
    {
        StartCoroutine(Explode(radius, damage));
    }
    private IEnumerator Explode(float radius, float damage)
    {
        yield return new WaitForSeconds(delayBeforeExplode);
        RaycastHit2D[] hits= Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
         
        if (hits.Length>0)
        {
            foreach (var hit in hits)
            {
               
                if (hit.collider.gameObject.layer==layerNumber)
                {
                    if (hit.transform.gameObject.TryGetComponent(out Character character))
                    {
                        character.TakeDamage(damage);
                    }
                }
            }
        }
       yield return new WaitForSeconds(delayAfterExplode);
        Destroy(gameObject);
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }*/
}
