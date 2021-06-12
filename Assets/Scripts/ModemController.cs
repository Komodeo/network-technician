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
        StopAllCoroutines();
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
        yield return new WaitForSeconds(2);
        if (pluggedIn && rested)
        {
            connected = true;
            rested = false;
            StartCoroutine(Entropy());
        }
        Debug.Log(name + " connected = " + connected);
    }

    IEnumerator Disconnect()
    {
        connected = false;
        yield return new WaitForSeconds(2);
        if (!pluggedIn)
        {
            rested = true;
        }
        Debug.Log(name + " connected = " + connected);
    }

    IEnumerator Entropy()
    {
        yield return new WaitForSeconds(5);
        connected = false;
        Debug.Log(name + " connected = " + connected);
    }
}
