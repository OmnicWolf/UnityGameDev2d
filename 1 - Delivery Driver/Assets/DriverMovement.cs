using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverMovement : MonoBehaviour
{
    [SerializeField] private float rotationFactor = 256f;
    [SerializeField] private float speedFactor = 16f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /* Time.deltaTime = time elapsed between frames
         * Allows inputs to be performed independent of frames per second
         */
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * this.rotationFactor * Time.deltaTime);
        transform.Translate(0, Input.GetAxis("Vertical") * this.speedFactor * Time.deltaTime, 0);
    }
}
