using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

/**
* Classe que implementa el moviment lliure d'un objecte
* i la instàciació'objectes
* Jesuïtes El Clot
 * sergi.grau.@fje.edu
* 1.0 28.10.2023
*/
public class MovimentLliure : MonoBehaviour
{
    [SerializeField] float velocitat = 3f; //velocitat de
    [SerializeField] Rigidbody bala;
    [SerializeField] GameObject cano;
    [SerializeField] GameObject foc;
    private float _i = 0;
    void Start()
    {
        bala.gameObject.SetActive (false);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * velocitat);
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * velocitat);
        if (Input.GetButtonDown("Fire1"))
        {
            print("polsat");
            Vector3 pos = cano.transform.position;
            Quaternion rot = cano.transform.rotation;
            pos.Set(pos.x-1, pos.y, pos.z );
            Object o = Instantiate(bala, pos, rot);
            o.GameObject().SetActive(true);
            ((Rigidbody)o).AddForce(new Vector3(1,_i,0) * -1000);
           StartCoroutine(MostrarFocCano(1.0f));



        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            Debug.Log(_i+=0.1f);
            cano.transform.Rotate(Vector3.forward * 2);

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            Debug.Log(_i-=0.1f);
            cano.transform.Rotate(Vector3.forward * -2);

        }
    }

    IEnumerator MostrarFocCano(float durada)
    {
        foc.SetActive(true);
        var i= 0.0f;
        var rati= 5.0f;
        while (i < durada) {
            i += Time.deltaTime * rati;
            Debug.Log(i);
            foc.GetComponent<Light> ().intensity =Random.Range(0F, 10.0F);;        
            yield return null;
        }
        foc.SetActive(false);
    }
    
    private void MostrarFocCano()
    {
        foc.GetComponent<Light> ().intensity = Random.Range(0F, 10.0F);        
    }
    
    public void Reanomenar(string nouNom)
    {
        Debug.Log("missatge rebut"+nouNom);
        //gameObject.name = nouNom;
    }
}