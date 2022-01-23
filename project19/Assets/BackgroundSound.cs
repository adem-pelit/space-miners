using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSound : MonoBehaviour
{
    public static BackgroundSound bs;
    public AudioSource aus;
    public AudioClip menu;
    public AudioClip main;

    public Vector3 position;
    public Quaternion quaternion;
    public Vector3 scale;
    public string scene;
    public bool setted = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (bs == null) bs = this;
        if (SceneManager.GetActiveScene().name == "Menu") sound(0);
        if (SceneManager.GetActiveScene().name == "main") sound(1);
        print("çalıştı:)");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void save(Transform tr)
    {
        this.position = tr.position;
        this.quaternion = tr.rotation;
        this.scale = tr.localScale;
        this.scene = SceneManager.GetActiveScene().name;
        this.setted = true;
        print("kaydetme işlemi başarılı!");
    }

    public void set(Transform tr)
    {
        if (setted)
        {
            tr.position = this.position;
            tr.rotation = this.quaternion;
            tr.localScale = this.scale;
            print("set etme işlemi başarılı!");
        }
    }

    public static void sound(int i)
    {
        if (bs != null)
        {
            print("çalıştı:)" + i);
            if (i == 0)
            {
                bs.aus.clip = bs.menu;
                bs.aus.Play();
            }
            if (i == 1)
            {
                bs.aus.clip = bs.main;
                bs.aus.Play();
            }
        }
    }
}
