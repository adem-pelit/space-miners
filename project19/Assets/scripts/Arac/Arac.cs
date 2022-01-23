using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arac : Varlik
{
    public static Arac player = null;
    GameObject hizTopu;
    public string user = "player";
    public float _speed = 10;
    public float _rotationSpeed = 10;

    public float MaxSpeed = 200f;
    public float speed = 0;
    public Vector3 rota = Vector3.zero;
    public GameObject bullet;
    public Rigidbody rb;
    private AudioSource auso;

    public void Start()
    {
        base.Start();
        if (user == "player") Arac.player = this;

        this.hizTopu = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.hizTopu.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(this.hizTopu.GetComponent<BoxCollider>());
        this.rb = GetComponent<Rigidbody>();
        this.auso = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        if (user == "player")
        {
            move();
            shoot();
            if(Merkez.merkezs!=null)
            foreach (var mer in Merkez.merkezs)
                if (Vector3.Distance(mer.transform.position, transform.position) < 10000)
                {
                    Main.main.resimler[mer.name].gameObject.SetActive(false);
                    if (rb.velocity.magnitude > this.MaxSpeed) rb.velocity = rb.velocity.normalized * this.MaxSpeed;
                }
                else
                {
                    bool ekranda = false;
                    var ekran = Camera.main.WorldToViewportPoint(mer.transform.position);
                    if (ekran.x < 1 && ekran.x > 0 && ekran.y < 1 && ekran.y > 0 && ekran.z > 0) ekranda = true;
                    else ekranda = false;
                    if (ekranda)
                    {
                        Main.main.resimler[mer.name].gameObject.SetActive(true);
                        Vector3 vect = Camera.main.WorldToScreenPoint(mer.transform.position);
                        vect.z = 0;
                        //print(Camera.main.WorldToViewportPoint(mer.transform.position));
                        Main.main.resimler[mer.name].GetComponent<Image>().transform.position = vect;
                    }
                    else Main.main.resimler[mer.name].gameObject.SetActive(false);

                    /*Main.main.resimler[mer.name].anchoredPosition = mer.transform.position; //vect;
                    */
                    //Main.main.resimler[mer.name].transform.position = Camera.main.WorldToScreenPoint(mer.transform.position);
                    /*
                    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Main.main.canv, WorldToGuiPoint(mer.transform.position), Camera.main, out zer))
                        Main.main.resimler[mer.name].anchoredPosition = zer;
                    */
                }
        }
    }
    public Vector3 WorldToGuiPoint(Vector3 position)
    {
        var guiPosition = Camera.main.WorldToScreenPoint(position);
        guiPosition.y = Screen.height - guiPosition.y;

        return guiPosition;
    }
    public void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            auso.pitch = UnityEngine.Random.Range(0.95f, 1.05f);
            this.auso.Play();
            Bullet.create(transform.forward * 5 + transform.position, transform.rotation, rb.velocity, transform.forward * 1000, Color.red);
        }
    }
    public void move()
    {

        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;
        float side = (Convert.ToInt32(Input.GetKey(KeyCode.Keypad1)) - Convert.ToInt32(Input.GetKey(KeyCode.Keypad3))) * _rotationSpeed;
        float upDown = (Convert.ToInt32(Input.GetKey(KeyCode.Keypad5)) - Convert.ToInt32((Input.GetKey(KeyCode.Keypad2)))) * _rotationSpeed;
        rota = new Vector3(upDown, rotation, side);
        rb.AddRelativeForce(new Vector3(0, 0, Input.GetAxis("Vertical") * _speed));
        rb.AddRelativeTorque(rota);
        this.hizTopu.transform.position = transform.position + rb.velocity;
        if (Input.GetKey(KeyCode.P)) rb.velocity *= 0.98f;
        rb.velocity = rb.velocity - Vector3.ProjectOnPlane(rb.velocity, transform.forward);
        this.speed = rb.velocity.magnitude;
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