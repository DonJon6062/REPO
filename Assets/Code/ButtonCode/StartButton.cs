using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    public void GoToScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
        SFX_Manager.instance.PlaySoundClip(clickSound, transform, 1f);
    }

    public void QuitApp() 
    {
        SFX_Manager.instance.PlaySoundClip(clickSound, transform, 1f);
        Application.Quit();
        Debug.Log("Quit");
    }
}
