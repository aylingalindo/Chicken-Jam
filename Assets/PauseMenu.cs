using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public static bool IsGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsGamePaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        IsGamePaused = true;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1; 
        IsGamePaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("CargandoMenu...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }

    public void LoadOptions()
    {
        Debug.Log("Cargando Opciones...");
    }

}
