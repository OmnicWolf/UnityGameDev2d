using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverMovement : MonoBehaviour
{
    [SerializeField] private float rotationFactor = 256f;
    [SerializeField] private float currentSpeedFactor = 16f;
    private float timeSinceSpeedChange = 3f;
    private bool isSpeedAltered = false;
    [SerializeField] private readonly float normalSpeed = 16f;
    [SerializeField] private readonly float slowSpeed = 8f;
    [SerializeField] private readonly float boostSpeed = 32f;

    // Update is called once per frame
    private void Update()
    {
        /* Time.deltaTime = time elapsed between frames
         * Allows inputs to be performed independent of frames per second
         */

        if(isSpeedAltered && timeSinceSpeedChange < 1.6f) {
            this.timeSinceSpeedChange += Time.deltaTime;
        } else {
            this.currentSpeedFactor = this.normalSpeed;
            this.isSpeedAltered = false;
        }

        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * this.rotationFactor * Time.deltaTime);
        transform.Translate(0, Input.GetAxis("Vertical") * this.currentSpeedFactor * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.currentSpeedFactor = this.slowSpeed;
        this.timeSinceSpeedChange = 0f;
        this.isSpeedAltered = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "SpeedBoost")
        {
            this.currentSpeedFactor = this.boostSpeed;
            this.timeSinceSpeedChange = 0f;
            this.isSpeedAltered = true;
        }
    }
}
