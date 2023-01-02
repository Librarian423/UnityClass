using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColorChange : MonoBehaviour
{
    public float range = 5f;
    private GameObject[] shperes;
    


    // Start is called before the first frame update
    void Start()
    {
        shperes = GameObject.FindGameObjectsWithTag("Shapes");
       
    }

    // Update is called once per frame
    void Update()
    {
        var max = shperes.Max(x => Vector3.Distance(transform.position, x.transform.position));
        var min = shperes.Min(x => Vector3.Distance(transform.position, x.transform.position));

        var diff = max - min;

        foreach (var go in shperes) 
        {
            var dist = Vector3.Distance(transform.position, go.transform.position);
            var ren = go.GetComponent<MeshRenderer>();

            var d = dist - diff;

            ren.material.color = Color.Lerp(Color.red, Color.black, d / diff);
        }
    }
}
