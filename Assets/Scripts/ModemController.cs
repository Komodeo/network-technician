using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModemController : MonoBehaviour
{
    private bool connected = true;
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
            StartCoroutine(ConnectDisconnect());
        }
    }

    IEnumerator ConnectDisconnect()
    {
        pluggedIn = !pluggedIn;
        Debug.Log(name + " pluggedIn = " + pluggedIn);
        if (pluggedIn)
        {
            yield return new WaitForSeconds(2);
            if (pluggedIn)
            {
                connected = true;
            }
        }
        else
        {
            StopAllCoroutines();
            connected = false;
        }
        Debug.Log(name + " connected = " + connected);
    }
}
