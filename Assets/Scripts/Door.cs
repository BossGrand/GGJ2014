﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }	
    
    // Update is called once per frame
    void Update () {

    }

    public void open()
    {
        Invoke("close", 3f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        foreach(Transform t in transform)
        {

            if(t.tag == "OpenDoor")
                t.gameObject.SetActive(true);
            if (t.tag == "ClosedDoor")
                t.gameObject.SetActive(false);
        }


    }

    private void close()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        foreach (Transform t in transform)
        {
            if (t.tag == "OpenDoor")
                t.gameObject.SetActive(false);
            if (t.tag == "ClosedDoor")
                t.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            Player p = collider.gameObject.GetComponent<Player>();
            p.nearestDoor = this;

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Player p = collider.gameObject.GetComponent<Player>();
            p.nearestDoor = null;

        }
    }

}
