using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arac : Varlik {
    public static Arac player = null;
    GameObject hizTopu;
    public string user = "player";
    public float _speed = 10;
    public float _rotationSpeed = 10;

    public float speed = 0;
    public Vector3 rota = Vector3.zero;
    public GameObject bullet;
    public Rigidbody rb;
    public void Start () {
        base.Start();
        if (user == "player") Arac.player = this;
        
        this.hizTopu = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.hizTopu.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(this.hizTopu.GetComponent<BoxCollider>());
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update () {
        base.Update();
        if (user == "player") {
            move ();
            shoot();
        }
    }
    public void shoot(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Bullet.create(transform.forward * 5 + transform.position, transform.rotation, rb.velocity, transform.forward * 1000, Color.red);
        }
    }
    public void move () {

        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;
        float side = (Convert.ToInt32(Input.GetKey(KeyCode.Keypad1)) - Convert.ToInt32(Input.GetKey(KeyCode.Keypad3))) * _rotationSpeed;
        float upDown = (Convert.ToInt32(Input.GetKey(KeyCode.Keypad5)) - Convert.ToInt32((Input.GetKey(KeyCode.Keypad2)))) * _rotationSpeed;
        rota = new Vector3(upDown, rotation, side);
        rb.AddRelativeForce(new Vector3(0, 0, Input.GetAxis("Vertical")*_speed));
        rb.AddRelativeTorque(rota);
        this.hizTopu.transform.position = transform.position + rb.velocity;
        if (Input.GetKey(KeyCode.P)) rb.velocity *= 0.98f;
        //rb.velocity = rb.velocity - Vector3.ProjectOnPlane(rb.velocity, transform.forward);
        /* burasi eski hareket
        float translation = Input.GetAxis ("Vertical") * _speed * Time.deltaTime;
        float rotation = Input.GetAxis ("Horizontal") * _rotationSpeed * Time.deltaTime;
        float side = (Convert.ToInt32 (Input.GetKey (KeyCode.Keypad1)) - Convert.ToInt32 (Input.GetKey (KeyCode.Keypad3))) * _rotationSpeed * Time.deltaTime;
        float upDown = (Convert.ToInt32 (Input.GetKey (KeyCode.Keypad5)) - Convert.ToInt32 ((Input.GetKey (KeyCode.Keypad2)))) * _rotationSpeed * Time.deltaTime;
        //print ("forward: " + transform.forward);

        rota += new Vector3(upDown, rotation, side);
        speed += translation;

        

        transform.Translate (0, 0, speed);
        transform.Rotate (rota);
        if(!(Input.GetKey(KeyCode.Keypad1)| Input.GetKey(KeyCode.Keypad2) | Input.GetKey(KeyCode.Keypad3) | Input.GetKey(KeyCode.Keypad5)))
            rota *= 0.99f;
        speed *= 0.999f;
        */
    }
}