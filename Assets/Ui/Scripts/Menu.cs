using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
   public void OpenPanel(RectTransform panel)
    {
        panel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClosePanel(RectTransform panel)
    {
        panel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }    
}
