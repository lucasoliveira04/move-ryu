using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coli : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DuckRed")
        {
            Destroy(collision.gameObject);
        }
    }
}
