using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float speed;
    private void Update()
    {
       // transform.position = new Vector2(Mathf.Lerp(transform.position.x, Target.transform.position.x, speed * Time.deltaTime), transform.position.y);
        
         Vector2 pos   = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        pos.y = -3.5f;
        transform.position = pos;
    }
}
