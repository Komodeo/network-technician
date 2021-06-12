using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModemController : MonoBehaviour
{

    private bool pluggedIn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pluggedIn = !pluggedIn;
            Debug.Log(name + " pluggedIn = " + pluggedIn);
        }
    }
}
