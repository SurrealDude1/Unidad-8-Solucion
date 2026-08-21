using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

    public float speed = 5;

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;

    }
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

}

    
