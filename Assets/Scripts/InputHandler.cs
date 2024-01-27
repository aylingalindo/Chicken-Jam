using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

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

    private void Awake() {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context){
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
    }
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
        
    }

    void RandomFace(){
        Task = Random.Range(1,8);
                Happy = false;
        spriteR.sprite = sprites[Task];
    }

    void PlayChicken(){
        Debug.Log("Play");
        if (!Happy){
            switch(Task){
                case 1:
                    spriteR.sprite = sprites[0];
                Happy = true;
                    Invoke("RandomFace",1);
                
                break;
                default:
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
                        Invoke("RandomFace",1);
                
                    }
                    Furioso = true;
                break;
                default:
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
                Invoke("RandomFace",1);
                
            break;
            default:
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
                Invoke("RandomFace",1);
                
            break;
            default:
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
                Invoke("RandomFace",1);
                
            break;
            default:
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
                    Invoke("RandomFace",1);
                }
                Furioso = true;
            break;
            case 6:
                spriteR.sprite = sprites[0];
                Happy = true;

                Invoke("RandomFace",1);
                
            break;
            default:
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
                Invoke("RandomFace",1);
                
            break;
            default:
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
                Invoke("RandomFace",1);
                
            break;
            default:
            break;
        }}
    }
}
