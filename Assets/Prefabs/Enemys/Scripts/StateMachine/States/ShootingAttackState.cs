using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttackState : AttackState
{
    [SerializeField] private float timeShootProjectile;
    [SerializeField] private Transform castPoint;
    [SerializeField] private float speedProjectile;
    private ProjectilePool pool;
    private void Awake()
    {
        pool = GetComponentInChildren<ProjectilePool>();
    }
    protected override void Attack(Character target)
    {
        _animator.SetTrigger("Attack");
        StartCoroutine(GetArrow(timeShootProjectile, target.transform));
    }
   private IEnumerator GetArrow(float delay,Transform target)
    {
        yield return new WaitForSeconds(delay);
        Vector2 direction = (target.position-castPoint.position).normalized;
        Vector2 dirRotate =   target.position-castPoint.position;
        float angle = Mathf.Atan2(dirRotate.y, dirRotate.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var arrow = pool.GetFreeObject(0);
        arrow.transform.position = castPoint.position;
        arrow.transform.rotation = rotation;
        arrow.InitProjectile(speedProjectile, damage, direction);
        arrow.gameObject.SetActive(true);
    }
}
