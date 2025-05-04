using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ParaSpawn : MonoBehaviour
{
    public GameObject objectToSpawn; // Inspector'dan atanacak prefab
    private GameObject currentObject;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        currentObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
        currentObject.transform.localScale = transform.localScale;

        // Scripti ekle ve sürüklemeyi baþlat
        ParaTut dragScript = currentObject.AddComponent<ParaTut>();
        dragScript.StartDrag();
    }


}
