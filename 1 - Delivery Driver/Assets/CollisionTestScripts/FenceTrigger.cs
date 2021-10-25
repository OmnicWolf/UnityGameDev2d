using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("The pumpkin observes a hoodlum cross the fence...");
    }

    private void OnTriggerExit2D() {
        Debug.Log("The pumpkin readies for battle &x&");
    }
}
