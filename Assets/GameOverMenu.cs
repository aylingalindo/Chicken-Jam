using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveScreen()
    {
        gameObject.SetActive(true);
        Debug.Log("Menu Muerte");
    }

    public void ReturnToSender()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
