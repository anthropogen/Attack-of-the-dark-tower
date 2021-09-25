
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private RectTransform panel;
    [SerializeField] private Spawner spawner;
    [SerializeField] private RectTransform scrollContainer;
    private void OnEnable()
    {
        spawner.AllEnemyDied += OpenPanel;
    }
    private void OnDisable()
    {
        spawner.AllEnemyDied -= OpenPanel;
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
