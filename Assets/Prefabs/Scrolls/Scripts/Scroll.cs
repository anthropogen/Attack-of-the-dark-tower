
using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]
public abstract class Scroll : MonoBehaviour
{
    protected Player Player { get; private set; }
    public void Init(Player player)
    {
        Player = player;
    }
    public abstract void MouseDownAction();

    private void OnMouseDown()
    {
        MouseDownAction();
    }
}
