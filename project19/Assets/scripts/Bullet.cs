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
    public void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            if (hit.distance < 50) collision(hit);
    }
    void collision(RaycastHit hit)
    {


        //print(hit.transform.gameObject.name);
        var varlik = hit.transform.gameObject.GetComponent<Varlik>();
        varlik.saglik -= 30;
        Component bina = new Component();
        if (hit.transform.gameObject.TryGetComponent(typeof(Bina), out bina))
        {
            if (varlik.saglik < 0)
            {
                Explosion.create(transform.position, Color.white, Main.main.audios[1]);
                Main.main.score++;
                var bin = (Bina)bina;
                Merkez.binas.Remove(bin);
                Destroy(bin.gameObject);
                if (Merkez.binas.Count == 0)
                {
                    Explosion.create(transform.position, Color.white, Main.main.audios[2]);
                    Main.main.end();
                }
                else print(Merkez.binas.Count + " tane bina kaldı, score: " + Main.main.score);
                //if (Merkez.binas.Count < 4) foreach (var element in Merkez.binas) print(element.name);
            }
            else Explosion.create(transform.position, Color.white, Main.main.audios[0]);

        }
        else Explosion.create(transform.position, Color.white, Main.main.audios[0]);
        Destroy(gameObject);
    }

    

    /*
void OnCollisionEnter(Collision collision)
{

   Explosion.create(transform.position, Color.white);
   print(collision.gameObject.name);
   var varlik = collision.gameObject.GetComponent<Varlik>();
   varlik.saglik -= 30;
   Destroy(gameObject);

}
*/

    public static void create(Vector3 pos, Quaternion rota, Vector3 velocity, Vector3 force, Color color)
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = pos;
        go.transform.rotation = rota;
        go.GetComponent<Renderer>().material.color = color;
        //go.GetComponent<Bullet>().speed = speed + 100f;
        go.AddComponent<Bullet>();
        var rb = go.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
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
