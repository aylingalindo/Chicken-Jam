using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System.Runtime.InteropServices;

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

    public TMP_Text CounterText;

    private int Task;
    private bool Furioso;
    private bool Happy = false;
    public int TimeEmotion = 8;

    private int PlayerPuntuation = 1;

    private float realTime;
    private bool initTimer = false;


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
        RandomFace();
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
        if (initTimer)
        {
            if (realTime > 0)
            {
                if (realTime - Time.deltaTime < 0)
                    realTime = 0;
                else
                    realTime -= Time.deltaTime;
                CounterText.text = realTime.ToString("F2");
            }
            Debug.Log(realTime);
        }
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
        }
        else 
        {
            CancelInvoke("GameOver");
            Debug.Log("Chevin el jemima");
            PlayerPuntuation = PlayerPuntuation - 1;
            RandomFace();
            realTime = TimeEmotion;
            initTimer = true;
            Invoke("GameOver", TimeEmotion);
        }
    }

    void RandomFace(){

        // if you just have one life remaining, the task is going to be strong emotion acordingly
        if (PlayerPuntuation == 0) {
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
                    Invoke("RandomFace",1);
                
                break;
                default:
                GameOver();
                //RandomFace();
                break;
            }
        }
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
                        Invoke("RandomFace",1);
                
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
                Invoke("RandomFace",1);
                
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
                Invoke("RandomFace",1);
                
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
                Invoke("RandomFace",1);
                
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
                    Invoke("RandomFace",1);
                }
                Furioso = true;
            break;
            case 6:
                spriteR.sprite = sprites[0];
                Happy = true;
                CancelInvoke("GameOver");
                Invoke("RandomFace",1);
                
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
                Invoke("RandomFace",1);
                
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
                Invoke("RandomFace",1);
                
            break;
            default:
            GameOver();
            //RandomFace();
            break;
        }}
    }
}
