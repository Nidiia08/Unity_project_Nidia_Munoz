using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_clase : MonoBehaviour
{
    public float posX = -0.27f;
    public float posY = 2.28f;
    public float posZ = -2.86f;
    void Start()
    {
        //Debug.Log("Mi nombre es: " + name);
        //Debug.Log("Pocision en X:" + transform.position.x);
        //Debug.Log("La pocision actual es: " + transform.position);

        transform.position = new Vector3(posX, posY, posZ);
        Debug.Log("Nueva pocision Camara: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
