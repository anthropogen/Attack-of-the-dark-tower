
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class Scroll : MonoBehaviour,IPointerDownHandler
{
    protected Player Player { get; private set; }
    public void Init(Player player)
    {
        Player = player;
    }
    public abstract void MouseDownAction();

   
  public void OnPointerDown(PointerEventData eventData)
    {
        MouseDownAction();
    }
}
