using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float speed;
    [SerializeField] private float groundY;
    [SerializeField] private bool isRight;
    private float currentPositionX;
    private float lastPositionX;
    private void OnEnable()
    {
        lastPositionX = currentPositionX = transform.position.x;
    }
    private void Update()
    {
        if (Target!=null)
        {
            currentPositionX = transform.position.x;
            if (currentPositionX > lastPositionX && !isRight || currentPositionX < lastPositionX && isRight)
            {
                Spin();
            }
            lastPositionX = currentPositionX;
            Vector2 pos = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
            pos.y = groundY;
            transform.position = pos;
        }
    }


    private void Spin()
    {
        transform.Rotate(0, 180, 0);
        isRight = !isRight;
    }
}
