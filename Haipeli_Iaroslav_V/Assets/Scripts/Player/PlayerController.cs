using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform gunTransform;
    public float moveSpeed = 5f;
    
    private Vector2 moveInput;
    private Vector2 aimInput;
    private Master controls;
    private Rigidbody2D body;

    void Awake()
    {
        controls = new Master();
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void onDisable() {
        controls.Disable();
    }

    void FixedUpdate()
    {
       Move(); 
    }

    void Move(){
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }

    void Update(){
        Shoot();
        Aim();
    }

    void Aim()
    {
        aimInput = controls.Player.Aim.ReadValue<Vector2>();
        if(aimInput.sqrMagnitude > 0.1){
            //Debug.Log(aimInput);
            Vector2 aimDirection = Vector2.zero;
            if(UsingMouse()){
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                mousePosition.z = 0;
                aimDirection = mousePosition - gunTransform.position;
            }
            else{
                aimDirection = aimInput;
            }
            float angle = Mathf.Atan2(aimDirection.x, -aimDirection.y) * Mathf.Rad2Deg;
            gunTransform.rotation = Quaternion.Euler(0,0,angle);
        }
    }

    bool UsingMouse(){
        if(Mouse.current.delta.ReadValue().sqrMagnitude > 0.1){
            return true;
        }


            return false;
    }


    void Shoot()
    {

    
        if(controls.Player.Fire.triggered){
            GameObject bullet = BulletPoolManager.Instance.GetBullet();
            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation; 
        }
    }
}
