using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("The pumpkin fights back! ヽ(ಠ_ಠ)ノ");
    }
}
