using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera; 

    private void Awake() {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context){

        // si no está inicializada la escena 
        if(!context.started) return;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
