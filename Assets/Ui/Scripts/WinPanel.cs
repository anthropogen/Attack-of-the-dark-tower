
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private RectTransform panel;
    [SerializeField] private Spawner spawner;
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
        panel.gameObject.SetActive(true);
    }
}
