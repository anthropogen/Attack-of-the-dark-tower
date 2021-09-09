using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float delayBeforeExplode;
    [SerializeField] private float delayAfterExplode;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float radius;

    public void InitExplode(float radius,float damage)
    {
        StartCoroutine(Explode(radius, damage));
    }
    private IEnumerator Explode(float radius, float damage)
    {
        yield return new WaitForSeconds(delayBeforeExplode);
        RaycastHit2D[] hits= Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, enemyMask);
        if (hits.Length>0)
        {
            foreach (var hit in hits)
            {
                if (hit.transform.gameObject.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(damage);
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
