using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public GameObject[] hearts;

    public int life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);

        }
        else if (life < 3)
        {
            Destroy(hearts[1].gameObject);
        }
    }


    public void TakeDamage(int damage)
    {

    }
}
