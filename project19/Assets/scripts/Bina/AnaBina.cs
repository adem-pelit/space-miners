using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaBina : Bina
{
    public static AnaBina create(Merkez merkez, Vector3Int konum, float size)
    {
        //GameObject ayarlari...
        //print(merkez.name + " " + konum + "size");
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = "AnaBina"+konum;
        go.GetComponent<Renderer>().material = Instantiate(Resources.resources.anaBina);
        //go.transform.localScale = new Vector3(size, size, size);

        //anabina ayarlari...
        var anabina = go.AddComponent<AnaBina>();
        anabina.merkez = merkez;
        anabina.konum = konum;
        go.transform.position = merkez.transform.position + konum;
        anabina.saglik = 100f;
        anabina.scale = size;
        //anabinayi dondur...
        return anabina;
    }
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
    }
}
