
using UnityEngine;

public class HealthScroll : Scroll
{
    [SerializeField] private Vector2Int rangeHealthAdded;
   

    public override void MouseDownAction()
    {
        int addedHealth = Random.Range(rangeHealthAdded.x, rangeHealthAdded.y);
        if (addedHealth<0)
        {
            return;
        }
        Player.AddHealth(addedHealth);
        gameObject.SetActive(false);
    }
}
