using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructorTest : MonoBehaviour
{
  
    public void returnToMenu()
    {
        //Un simple click nos hara regresar al menu principal con el instructor
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
