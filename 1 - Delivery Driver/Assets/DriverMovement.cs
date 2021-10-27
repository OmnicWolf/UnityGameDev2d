using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverMovement : MonoBehaviour
{
    [SerializeField] private float rotationFactor = 256f;
    [SerializeField] private float currentSpeedFactor = 16f;

    private bool isSpeedAltered = false;
    private float timeElapsedSinceSpeedChange = 0f;

    private readonly float normalSpeed = 16f;
    private readonly float slowSpeed = 8f;
    private readonly float boostSpeed = 32f;

    // Update is called once per frame
    private void Update()
    {
        /* Time.deltaTime = time elapsed between frames
         * Allows inputs to be performed independent of frames per second
         */

        if(isSpeedAltered) {
            if(timeElapsedSinceSpeedChange < 1.6f) {
                this.timeElapsedSinceSpeedChange += Time.deltaTime;
            } else {
                this.timeElapsedSinceSpeedChange = 0f;
                this.isSpeedAltered = false;
                this.currentSpeedFactor = this.normalSpeed;
            }
        }

        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * this.rotationFactor * Time.deltaTime);
        transform.Translate(0, Input.GetAxis("Vertical") * this.currentSpeedFactor * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.currentSpeedFactor = this.slowSpeed;
        this.isSpeedAltered = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "SpeedBoost")
        {
            this.currentSpeedFactor = this.boostSpeed;
            this.isSpeedAltered = true;
        }
    }
}
