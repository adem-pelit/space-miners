using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bina : Varlik {
    public static List<Vector3Int> klist = new List<Vector3Int>()
    {
        new Vector3Int( 1,0,0),
        new Vector3Int(-1,0,0),
        new Vector3Int(0, 1,0),
        new Vector3Int(0,-1,0),
        new Vector3Int(0,0, 1),
        new Vector3Int(0,0,-1),
};
    public Vector3Int konum;
    public bool aktif;

    public Dictionary<Vector3Int, Bina> komsu = new Dictionary<Vector3Int, Bina>();

    public float scale {
        get { return (transform.localScale.x+transform.localScale.y+transform.localScale.z)/3f; }   // get method
        set { transform.localScale = new Vector3(value, value, value); }  // set method
    }

    public void Start () {
        base.Start();
    }

    // Update is called once per frame
    public void Update () {
        base.Update();
        add ();
    }

    public void add () {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast (ray, out hit)) {

            if (hit.transform == transform && Input.GetMouseButtonDown (1)){
                var pos = hit.point-transform.position;
                if(pos.z == -0.5f) AnaBina.create(merkez, new Vector3Int(0, 0, -1) + this.konum, 500);
                if(pos.z ==  0.5f) AnaBina.create(merkez, new Vector3Int(0, 0, 1) + this.konum, 500);
                if(pos.x == -0.5f) AnaBina.create(merkez, new Vector3Int(-1, 0, 0) + this.konum, 500);
                if(pos.x ==  0.5f) AnaBina.create(merkez, new Vector3Int(1, 0, 0) + this.konum, 500);
                if(pos.y == -0.5f) AnaBina.create(merkez, new Vector3Int(0, -1, 0) + this.konum, 500);
                if(pos.y ==  0.5f) AnaBina.create(merkez, new Vector3Int(0, 1, 0) + this.konum, 500);
                ScreenCapture.CaptureScreenshot("SomeLevel.png");
            }
        }
    }
    public enum Varsa
    {
        silEkle,
        ekleme
    }
    public Bina create(Vector3Int pos, Varsa var_mi)
    {
        //GameObject ayarlari...
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = "AnaBina" + (konum + pos);
        go.GetComponent<Renderer>().material = Instantiate(Resources.resources.anaBina);

        //bina ayarlari...
        var bina = go.AddComponent<Bina>();
        bina.merkez = merkez;
        bina.konum = (konum + pos);
        go.transform.position = merkez.transform.position + (Vector3)(konum + pos)* scale;
        bina.saglik = 100f;
        bina.scale = this.scale;

        /*
        if (this.komsu.ContainsKey(pos))
        {
            if()
        }
        else {
            this.komsu[pos] = bina;
            bina.komsu[new Vector3Int(pos.x * -1, pos.y * -1, pos.z * -1)] = this;
        */

        //binayi dondur...
        return bina;
    }
}