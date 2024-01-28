using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    public List<Sprite> sprites;
    public SpriteRenderer spriteR;

    public Button Play;
    public Button Eat;
    public Button Sleep;
    public Button Hug;
    public Button Motivation;
    public Button Clean;
    public Button Shower;
    public Button Water;

    private int Task;
    private bool Furioso;
    private bool Happy = false;
    private bool winner = false;
    public int TimeEmotion = 20;

    public TMP_Text CounterText;
    public TMP_Text DayText;

    public GameObject VictoryPng;
    public GameObject VictoryBgPng;
    private bool fallaste = false; 

    private int PlayerPuntuation = 1;

    public GameObject explosionAnim;
    public GameObject showerAnim;
    public GameObject waterAnim;
    public GameObject sleepAnim;
    public GameObject playAnim;
    public GameObject eatAnim;
    public GameObject motivationAnim;
    public GameObject hugAnim;
    public GameObject cleanAnim;

    private float realTime;
    private float totalTime;
    private float dayTime = 2f;
    private float currentDay = 6;

    private void Awake() {
        _mainCamera = Camera.main;
    }

    /*public void OnClick(InputAction.CallbackContext context){
        Debug.Log("rayhit");

        // si no está inicializada la escena 
        if(!context.started) return;
        Debug.Log("rayhit");
        // checa donde hizo click 
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        // si no le pega a un collider
        if(!rayHit.collider) return;

        // imprime el nombre del objeto del collider (aqui logica)
        Debug.Log(rayHit.collider.gameObject.name);
    }*/
    // Start is called before the first frame update
    void Start()
    {
        DayText.text = "Día: " + currentDay;

        explosionAnim.SetActive(false);
        showerAnim.SetActive(false);
        waterAnim.SetActive(false);
        sleepAnim.SetActive(false);
        playAnim.SetActive(false);
        eatAnim.SetActive(false);
        motivationAnim.SetActive(false);
        hugAnim.SetActive(false);
        cleanAnim.SetActive(false);

        RandomFace();
        setDay();
        Play.onClick.AddListener(PlayChicken);
        Eat.onClick.AddListener(EatChicken);
        Sleep.onClick.AddListener(SleepChicken);
        Hug.onClick.AddListener(HugChicken);
        Motivation.onClick.AddListener(MotivationChicken);
        Clean.onClick.AddListener(CleanChicken);
        Shower.onClick.AddListener(ShowerChicken);
        Water.onClick.AddListener(WaterChicken);
    }

    // Update is called once per frame
    void Update()
    {
        if(!winner){
        totalTime+=Time.deltaTime;
        if(totalTime>=dayTime){
                currentDay++;
            totalTime = 0f;
            if(currentDay<6){
                
                CancelInvoke("GameOver");
                    realTime = TimeEmotion;
                    Invoke("RandomFace",1);
                    
            DayText.text = "Siguiente día";
                Invoke("setDay", 1);
            }
            else if (currentDay >= 7)
            {
                VictoryPng.SetActive(true);
                VictoryBgPng.SetActive(true);
                winner = true;
            }
        }
        if (realTime > 0)
        {
            if (realTime - Time.deltaTime < 0)
                realTime = 0;
            else
                realTime -= Time.deltaTime;
            CounterText.text = realTime.ToString("F2");
        }
        }
        else{
            StartCoroutine(DelayDeath(4f));
        }
    }

    void setDay(){//si
        switch(currentDay){
            case 1:
                TimeEmotion = 20;
            break;
            case 2:
                TimeEmotion = 10;
            break;
            case 3:
                TimeEmotion = 8;
            break;
            case 4:
                TimeEmotion = 5;
            break;
            case 5:
                TimeEmotion = 4;
            break;
            case 6:
                TimeEmotion = 2;
            break;
        }
        
            DayText.text = "Día: " + currentDay;
    }

    /*private IEnumerator PerformAction()
    {
        while (true)
        {
            
            actionCompleted = false;

            float timer = 0f;

            while (timer < timeLimit)
            {
                timer += Time.deltaTime;

                if (actionCompleted)
                    break;

                yield return null;
            }

            if (!actionCompleted)
            {
                Debug.Log("¡Perdiste! No completaste la acción a tiempo.");

                yield return new WaitForSeconds(1f); 
            }
            else
            {
                yield return null;
            }
        }
    }*/

    /*
    private void CompleteAction()
    {
        if (!actionCompleted)
        {
            actionCompleted = true;
            Debug.Log("¡Completaste la acción!");

            // Aquí puedes agregar la lógica adicional para manejar la acción completada.

        }
    }*/

    void GameOver()
    {
        if (PlayerPuntuation == 0)
        {
            Debug.Log("valiste madre morro");
            explosionAnim.SetActive(true);
            StartCoroutine(DelayDeath(1.5f));
        }
        else
        {
            fallaste = true;
            CancelInvoke("GameOver");
            Debug.Log("Chevin el jemima");
            PlayerPuntuation = PlayerPuntuation - 1;
            RandomFace();
            realTime = TimeEmotion;
            Invoke("GameOver", TimeEmotion);
        }
    }

    IEnumerator DelayDeath(float secs)
    {
        yield return new WaitForSeconds(secs);
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void RandomFace(){

        // if you just have one life remaining, the task is going to be strong emotion acordingly
        if ((PlayerPuntuation == 0) && (fallaste == true)) { // agregar bool de fallaste
            fallaste = false;
            switch(Task){
                case 2: 
                case 3:
                case 7:
                case 8:
                int[] specificNumbers = { 2, 3, 7, 8 };
                int randomIndex = Random.Range(0, specificNumbers.Length);
                Task = specificNumbers[randomIndex];
                break;

                case 1:
                Task = 2;
                break;

                case 4:
                Task = 7;
                break;

                case 5:
                Task = 3;
                break;

                case 6:
                Task = 8;
                break;

                default:
                Task = Random.Range(1,9);
                break;

            }
        } 
        // if you have the two lives, the task is random
        else {
            // logica de los dias?
            Task = Random.Range(1,9);
        }

        if (Happy == true){
            //CompleteAction();
            Debug.Log("Completaste este peduki");
        }
        realTime = TimeEmotion;
        Invoke("GameOver", TimeEmotion);
        
        Happy = false;
        
        spriteR.sprite = sprites[Task];
        //StartCoroutine(PerformAction());
    }

    void PlayChicken(){
        Debug.Log("Play");
        if (!Happy){
            switch(Task){
                case 1:
                spriteR.sprite = sprites[0];
                Happy = true;
                CancelInvoke("GameOver");
                realTime = TimeEmotion;
                Invoke("RandomFace",2);
                playAnim.SetActive(true);
                StartCoroutine(StopAnimation(playAnim, 1.0f));
                break;
                default:
                GameOver();
                //RandomFace();
                break;
            }
        }
    }

    IEnumerator StopAnimation(GameObject anim, float time){
        yield return new WaitForSeconds(time);
        anim.SetActive(false);
        //xsInvoke("RandomFace",1);
    }

    void EatChicken(){
        Debug.Log("Eat");
        if (!Happy){
            switch(Task){
                case 2:
                    if(Furioso){
                        spriteR.sprite = sprites[0];
                        Happy = true;
                        CancelInvoke("GameOver");
                        realTime = TimeEmotion;
                        Invoke("RandomFace",2);
                        eatAnim.SetActive(true);
                        StartCoroutine(StopAnimation(eatAnim, 1.0f));
                    }
                    Furioso = true;
                break;
                default:
                GameOver();
                //RandomFace();
                break;
            }
        }
    }
    void CleanChicken(){
        Debug.Log("Clean");
        if (!Happy){
        switch(Task){
            case 4:
                spriteR.sprite = sprites[0];
                Happy = true;
                CancelInvoke("GameOver");
                realTime = TimeEmotion;
                Invoke("RandomFace",2);
                cleanAnim.SetActive(true);
                StartCoroutine(StopAnimation(cleanAnim, 1.0f));
                
            break;
            default:
            GameOver();
            //RandomFace();
            break;
        }}
    }
    void HugChicken(){
        Debug.Log("Hug");
        if (!Happy){
        switch(Task){
            case 5:
                spriteR.sprite = sprites[0];
                Happy = true;
                CancelInvoke("GameOver");
                realTime = TimeEmotion;
                Invoke("RandomFace",2);
                hugAnim.SetActive(true);
                StartCoroutine(StopAnimation(hugAnim, 1.0f));
            break;
            default:
            GameOver();
            //RandomFace();
            break;
        }}
    }
    void MotivationChicken(){
        Debug.Log("Motivation");
if (!Happy){
        switch(Task){
            case 3:
                spriteR.sprite = sprites[0];
                Happy = true;
                CancelInvoke("GameOver");
                realTime = TimeEmotion;
                Invoke("RandomFace",2); // 1 + 1
                motivationAnim.SetActive(true);
                StartCoroutine(StopAnimation(motivationAnim, 1.0f));
            break;
            default:
            GameOver();
            //RandomFace();
            break;
        }}
    }
    void SleepChicken(){
        Debug.Log("Sleep");
        if (!Happy){
        switch(Task){ 
            case 2:
                if(Furioso){
                    spriteR.sprite = sprites[0];
                    Happy = true;
                    CancelInvoke("GameOver");
                    realTime = TimeEmotion;
                    Invoke("RandomFace",2);
                    sleepAnim.SetActive(true);
                    StartCoroutine(StopAnimation(sleepAnim, 1.0f));
                }
                Furioso = true;
            break;
            case 6:
                spriteR.sprite = sprites[0];
                Happy = true;
                CancelInvoke("GameOver");
                realTime = TimeEmotion;
                Invoke("RandomFace",2);
                sleepAnim.SetActive(true);
                StartCoroutine(StopAnimation(sleepAnim, 1.0f));
            break;
            default:
            GameOver();
            //RandomFace();
            break;
        }}
    }
    void ShowerChicken(){
        Debug.Log("Shower");
        if (!Happy){
        switch(Task){
            case 7:
                spriteR.sprite = sprites[0];
                Happy = true;
                CancelInvoke("GameOver");
                realTime = TimeEmotion;
                Invoke("RandomFace",2);
                showerAnim.SetActive(true);
                StartCoroutine(StopAnimation(showerAnim, 1.0f));
            break;
            default:
            GameOver();
            //RandomFace();
            break;
        }}
    }
    void WaterChicken(){
        Debug.Log("Water");
if (!Happy){
        switch(Task){
            case 8:
                spriteR.sprite = sprites[0];
                Happy = true;
                CancelInvoke("GameOver");
                realTime = TimeEmotion;
                Invoke("RandomFace",2);
                waterAnim.SetActive(true);
                StartCoroutine(StopAnimation(waterAnim, 1.0f));
            break;
            default:
            GameOver();
            //RandomFace();
            break;
        }}
    }
}
