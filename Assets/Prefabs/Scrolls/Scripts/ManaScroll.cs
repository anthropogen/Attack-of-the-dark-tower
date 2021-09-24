using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScroll : Scroll
{
    [SerializeField] private Vector2Int rangeManaAdded;
   

    public override void MouseDownAction()
    {
        int addedMana = Random.Range(rangeManaAdded.x, rangeManaAdded.y);
        if (addedMana < 0)
        {
            return;
        }
        Player.AddMana(addedMana);
        gameObject.SetActive(false);
    }
}
