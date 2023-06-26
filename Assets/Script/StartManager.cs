using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1080, 1920, true);

        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
    }
    public void OnCliCkStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
