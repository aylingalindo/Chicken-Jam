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
        //Debug.Log("a");
        //InvokeRepeating("RandomFace", 0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomFace(){
        int index = Random.Range(0,8);
        spriteR.sprite = sprites[index];
    }
}
