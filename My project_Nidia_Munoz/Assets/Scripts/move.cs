using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float horizontalInput;
    public float verticalInput;

    //Variable de tipo gameObject para guardar la esfera
    public GameObject miObjeto;

    public GameObject miOtroObjeto;

    //variable para interactuar en otra clase.
    public bool cambioObjeto = false;

    //Variables para el imán
    public bool imanActivo = false;
    public float radioIman = 10f;
    public float velocidadAtraccion = 5f;

    public float fuerzaSalto = 5f;
    private bool enElSuelo = true;  // Verifica si está en el suelo

    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        // Salto al presionar Enter (KeyCode.Return)
        if (Input.GetKeyDown(KeyCode.Return) && enElSuelo)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enElSuelo = false;
        }

        // Uso de miObjeto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(miObjeto, transform.position, Quaternion.identity);
            cambiaMiObjeto();
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //Limites del escenario Vertical

        if (transform.position.z > 42)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 42f);
        }

        if (transform.position.z < -14.14)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -14.14f);
        }

        //Limites del escenario Horizontal

        if (transform.position.x > 8.7)
        {
            transform.position = new Vector3(8.7f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -9.5)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        }

        // Activar o desactivar imán
        // Presiona la tecla "M" para activar/desactivar el imán. Al estar precionando la tecla, el imán atraerá monedas cercanas.
        if (Input.GetKeyDown(KeyCode.M))
        {
            imanActivo = !imanActivo;
        }

        // Si el imán está activo, atraer monedas
        if (imanActivo)
        {
            AtraerMonedas();
        }

    }

    private void cambiaMiObjeto()
    {
        if (cambioObjeto == true)
        {
            Instantiate(miOtroObjeto, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
        }
    }

    // Método para atraer monedas
    private void AtraerMonedas()
    {
        GameObject[] monedas = GameObject.FindGameObjectsWithTag("moneda");

        foreach (GameObject moneda in monedas)
        {
            float distancia = Vector3.Distance(transform.position, moneda.transform.position);

            if (distancia <= radioIman)
            {
                moneda.transform.position = Vector3.MoveTowards(
                    moneda.transform.position,
                    transform.position,
                    velocidadAtraccion * Time.deltaTime
                );
            }
        }
    }

    // Detectar si tocó el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
    }

}
