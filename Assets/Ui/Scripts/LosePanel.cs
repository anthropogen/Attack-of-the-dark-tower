
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private RectTransform panel;
    [SerializeField] private RectTransform scrollContainer;
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
        CloseScrolls();
        panel.gameObject.SetActive(true);
    }
    private void CloseScrolls()
    {
        scrollContainer.gameObject.SetActive(false);
    }
}
