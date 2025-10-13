using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReseter : MonoBehaviour
{
    private Vector3 startPos;          
    private Quaternion startRot;       
    private Rigidbody rb;

    public float resetHeight = -5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void Update()
    {
        if (transform.position.y < resetHeight)
        {
            ResetBall();
        }
    }

    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;

        transform.SetPositionAndRotation(startPos, startRot);

        Invoke(nameof(ReenableGravity), 0.2f);
    }

    private void ReenableGravity()
    {
        rb.useGravity = true;
    }
}
