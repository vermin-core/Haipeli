using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Master controls;
    // Start is called before the first frame update
    void Start()
    {
        controls = new Master();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
