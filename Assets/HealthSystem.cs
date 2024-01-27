using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public GameObject GameOverUI;

    public GameObject[] hearts;
    public GameObject buttonRef;
    public Button buttonRefFinal;


    public int life;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //if (life <= 0)
        //{
        //    Destroy(hearts[0].gameObject);

        //}
        //else if (life < 3)
        //{
        //    Destroy(hearts[1].gameObject);
        //}
        if (dead)
        {
            Debug.Log("ESTAMOS MUERTOS");
            GameOverUI.SetActive(true);
        }
    }


    public void TakeDamage(int damage)
    {
        if (life >= 1)
        {
            life -= damage;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                dead = true;
                
            }
        }
    }
}
