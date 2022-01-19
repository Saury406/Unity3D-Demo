using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTra;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTra.position.x,playerTra.position.y,-10f);
    }
}
