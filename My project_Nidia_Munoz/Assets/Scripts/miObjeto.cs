using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miObjeto : MonoBehaviour
{
    public float speed = 5.0f;

    void Start()
    {
        // Asegúrate de que la bala tenga un Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > 42)
        {
            Destroy(this.gameObject);
        }
    }

    //Destruir el objeto al colisionar con el muro
    void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}