using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muro : MonoBehaviour
{

    public int disparosParaRomper = 10;
    private int disparosRecibidos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Destruir el objeto al recibir 10 disparos de tipo "BalaDoble"
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("BalaDoble"))
        {
            disparosRecibidos++;
            Debug.Log("Disparos recibidos: " + disparosRecibidos);

            if (disparosRecibidos >= disparosParaRomper)
            {
                Destroy(gameObject);
                Debug.Log("Muro destruido");
            }
        }
    }
}
