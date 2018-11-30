using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	void Update ()
    {
        var mytransform = GetComponent<Transform>();
        mytransform.position += Vector3.forward;
	}
}
