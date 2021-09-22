
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private RectTransform panel;
    private void OnEnable()
    {
        player.PlayerDead += OpenPanel;
    }
    private void OnDisable()
    {
        player.PlayerDead += OpenPanel;
    }
    public void OpenPanel()
    {
        Time.timeScale = 0;
        panel.gameObject.SetActive(true);
    }
}
