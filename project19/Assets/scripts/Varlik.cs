using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Varlik : MonoBehaviour
{
    //her varligin bir saglik degeri bulunur sifira inerse varlik yok olur
    public float saglik;
    public Merkez merkez;

    public void Start()
    {
        saglik = 100;
    }

    // Update is called once per frame
    public void Update()
    {
        if (saglik < 0) Destroy(gameObject);
    }
}
