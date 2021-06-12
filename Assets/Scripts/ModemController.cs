using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModemController : MonoBehaviour
{
    private bool connected = true;
    private bool pluggedIn = true;
    private bool rested;

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
        pluggedIn = !pluggedIn;
        Debug.Log(name + " pluggedIn = " + pluggedIn);
        if (pluggedIn)
        {
            StartCoroutine(Connect());
        }
        else
        {
            StartCoroutine(Disconnect());
        }
    }

    IEnumerator Connect()
    {
        StopCoroutine(Disconnect());
        yield return new WaitForSeconds(2);
        if (pluggedIn && rested)
        {
            connected = true;
            rested = false;
        }
        Debug.Log(name + " connected = " + connected);
    }

    IEnumerator Disconnect()
    {
        StopCoroutine(Connect());
        connected = false;
        yield return new WaitForSeconds(2);
        if (!pluggedIn)
        {
            rested = true;
        }
        Debug.Log(name + " connected = " + connected);
    }
}
