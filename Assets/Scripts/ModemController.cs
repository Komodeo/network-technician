using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModemController : MonoBehaviour
{
    private bool connected = true;
    private bool pluggedIn = true;
    private bool rested;

    private Renderer indicatorRenderer;
    private Color indicatorOff = Color.black;
    private Color indicatorConnected = Color.green;
    private Color indicatorConnecting = new Color(1f, .5f, 0f, 1f);
    private Color indicatorDisconnected = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        indicatorRenderer = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        StartCoroutine(Entropy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Plug or unplug modem on click
    private void OnMouseDown()
    {
        StopAllCoroutines();
        pluggedIn = !pluggedIn;
        if (pluggedIn)
        {
            StartCoroutine(Connect());
        }
        else
        {
            StartCoroutine(Disconnect());
        }
    }

    // Plug modem in
    IEnumerator Connect()
    {
        indicatorRenderer.material.SetColor("_Color", indicatorConnecting);
        yield return new WaitForSeconds(.5f);
        indicatorRenderer.material.SetColor("_Color", indicatorOff);
        yield return new WaitForSeconds(.5f);
        indicatorRenderer.material.SetColor("_Color", indicatorConnecting);
        yield return new WaitForSeconds(.5f);
        indicatorRenderer.material.SetColor("_Color", indicatorOff);
        yield return new WaitForSeconds(.5f);
        if (pluggedIn && rested)
        {
            connected = true;
            rested = false;
            indicatorRenderer.material.SetColor("_Color", indicatorConnected);
            StartCoroutine(Entropy());
        }
        else
        {
            indicatorRenderer.material.SetColor("_Color", indicatorDisconnected);
        }
    }

    // Unplug modem
    IEnumerator Disconnect()
    {
        connected = false;
        indicatorRenderer.material.SetColor("_Color", indicatorOff);
        yield return new WaitForSeconds(2);
        if (!pluggedIn)
        {
            rested = true;
        }
    }

    IEnumerator Entropy()
    {
        yield return new WaitForSeconds(5);
        connected = false;
        indicatorRenderer.material.SetColor("_Color", indicatorDisconnected);
    }
}
