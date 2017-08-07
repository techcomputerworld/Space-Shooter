﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        //if (other.tag == "Boundary") return;
        if (other.CompareTag("Boundary")) return;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
