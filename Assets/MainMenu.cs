using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Creamos nuestra propia funcion para siempre que se llame nuestro boton
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
       
    }

    public void ChickenTaker()
    {
        PlayGame();
    }

    public void ChickenInstructor()
    {
        Debug.Log("Ventana Instructor");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
