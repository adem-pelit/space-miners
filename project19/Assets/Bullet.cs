using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Varlik
{
    public Rigidbody rb;
    void Start()
    {
        base.Start();

        StartCoroutine(die());
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
        //transform.Translate(0,0,Time.deltaTime*speed);
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "MyGameObjectName")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
        //print(collision.gameObject.name);
        Explosion.create(transform.position, Color.white);
        print(collision.gameObject.name);
        var varlik = collision.gameObject.GetComponent<Varlik>();
        varlik.saglik -= 30;
        Destroy(gameObject);

    }

    public static void create(Vector3 pos, Quaternion rota, Vector3 velocity, Vector3 force, Color color)
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = pos;
        go.transform.rotation = rota;
        go.GetComponent<Renderer>().material.color = color;
        //go.GetComponent<Bullet>().speed = speed + 100f;
        go.AddComponent<Bullet>();
        var rb = go.AddComponent<Rigidbody>();
        rb.velocity = velocity;
        rb.useGravity = false;
        rb.AddForce(force, ForceMode.Impulse);//this.rb.velocity+ 
        var isik = go.AddComponent<Light>();
        isik.color = color;
        isik.range = 1000;
        isik.intensity = 10;
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
