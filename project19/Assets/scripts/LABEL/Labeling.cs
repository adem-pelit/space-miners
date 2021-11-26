using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class Labeling : MonoBehaviour
{
    public static Labeling labeling;
    public MeshFilter meshFilter;
    public Mesh mesh;
    public List<Vector3> kon;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        Labeling.labeling = this;
        image = GameObject.Find("Image");

        /*
        kon = new List<Vector3>();
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        print(mesh.vertices.Length);
        for(int i=0; i<mesh.vertices.Length; i++){
            var pos = Camera.main.WorldToScreenPoint(mesh.vertices[i]+transform.position);
            kon.Add(pos);
        }
        ScreenCapture.CaptureScreenshot("deneme.png");
        File.WriteAllText("deneme.txt", screenToYolo(start(kon),stop(kon)));*/
    }

    Vector3 start(List<Vector3> kons){
        float xmin=99999,ymin=-1;
        foreach (var item in kons)
        {
            if(item.x < xmin) xmin = item.x;
            if(item.y > ymin) ymin = item.y;
        }
        return new Vector3(xmin,ymin,0);
    }
    Vector3 stop(List<Vector3> kons){
        float xmax=-1,ymax=99999;
        foreach (var item in kons)
        {
            if(item.x > xmax) xmax = item.x;
            if(item.y < ymax) ymax = item.y;
        }
        return new Vector3(xmax,ymax,0);
    }

    string screenToYolo(Vector3 a, Vector3 b){
        image.transform.position = new Vector3(a.x + (b.x - a.x)/2f, b.y + (a.y - b.y)/2f,0);
        image.GetComponent<RectTransform>().sizeDelta = new Vector2((b.x - a.x), (a.y - b.y));
        //print("kayit");
        var xLen = (b.x - a.x)/(float)Screen.width;
        var yLen = (a.y - b.y)/(float)Screen.height;
        var xst = a.x/(float)Screen.width + xLen/2f;
        var yst = 1-a.y/(float)Screen.height + yLen/2f;

        return ("0 "+xst+" "+yst+" " + xLen + " " + yLen).Replace(',','.');
    }
    
    public void save(string path){
        kon = new List<Vector3>();
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        //print(mesh.bounds);
        //Vertice'ler yerine bounds ozelligini kullanicam
        /*for(int i=0; i<mesh.vertices.Length; i++){
            var pos = Camera.main.WorldToScreenPoint(mesh.vertices[i]+transform.position);
            kon.Add(pos);
        }*/
        
        var pos = transform.position + new Vector3(mesh.bounds.center.x+mesh.bounds.extents.x*transform.localScale.x,
                              mesh.bounds.center.y+mesh.bounds.extents.y*transform.localScale.y,
                              mesh.bounds.center.z+mesh.bounds.extents.z*transform.localScale.z);
        kon.Add(Camera.main.WorldToScreenPoint(pos));
        pos = transform.position + new Vector3(mesh.bounds.center.x-mesh.bounds.extents.x*transform.localScale.x,
                          mesh.bounds.center.y+mesh.bounds.extents.y*transform.localScale.y,
                          mesh.bounds.center.z+mesh.bounds.extents.z*transform.localScale.z);
        kon.Add(Camera.main.WorldToScreenPoint(pos));
        pos = transform.position + new Vector3(mesh.bounds.center.x+mesh.bounds.extents.x*transform.localScale.x,
                          mesh.bounds.center.y-mesh.bounds.extents.y*transform.localScale.y,
                          mesh.bounds.center.z+mesh.bounds.extents.z*transform.localScale.z);
        kon.Add(Camera.main.WorldToScreenPoint(pos));
        pos = transform.position + new Vector3(mesh.bounds.center.x+mesh.bounds.extents.x*transform.localScale.x,
                          mesh.bounds.center.y+mesh.bounds.extents.y*transform.localScale.y,
                          mesh.bounds.center.z-mesh.bounds.extents.z*transform.localScale.z);
        kon.Add(Camera.main.WorldToScreenPoint(pos));
        pos = transform.position + new Vector3(mesh.bounds.center.x-mesh.bounds.extents.x*transform.localScale.x,
                          mesh.bounds.center.y-mesh.bounds.extents.y*transform.localScale.y,
                          mesh.bounds.center.z+mesh.bounds.extents.z*transform.localScale.z);
        kon.Add(Camera.main.WorldToScreenPoint(pos));
        pos = transform.position + new Vector3(mesh.bounds.center.x-mesh.bounds.extents.x*transform.localScale.x,
                          mesh.bounds.center.y+mesh.bounds.extents.y*transform.localScale.y,
                          mesh.bounds.center.z-mesh.bounds.extents.z*transform.localScale.z);
        kon.Add(Camera.main.WorldToScreenPoint(pos));
        pos = transform.position + new Vector3(mesh.bounds.center.x+mesh.bounds.extents.x*transform.localScale.x,
                          mesh.bounds.center.y-mesh.bounds.extents.y*transform.localScale.y,
                          mesh.bounds.center.z-mesh.bounds.extents.z*transform.localScale.z);
        kon.Add(Camera.main.WorldToScreenPoint(pos));
        pos = transform.position + new Vector3(mesh.bounds.center.x-mesh.bounds.extents.x*transform.localScale.x,
                          mesh.bounds.center.y-mesh.bounds.extents.y*transform.localScale.y,
                          mesh.bounds.center.z-mesh.bounds.extents.z*transform.localScale.z);
        kon.Add(Camera.main.WorldToScreenPoint(pos));
        print(mesh.bounds);
        ScreenCapture.CaptureScreenshot(path + ".png");
        File.WriteAllText(path + ".txt", screenToYolo(start(kon),stop(kon)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
