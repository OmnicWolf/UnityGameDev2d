using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverDelivery : MonoBehaviour
{
    [SerializeField]
    private Color32 packageColor = new Color32(31,176,60,255);

    [SerializeField]
    private Color32 defaultColor = new Color32(255,255,255,255);

    private SpriteRenderer spriteRenderer;

    private bool hasPackage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ka-chow!");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Color32 collisionObjectColor = collider.gameObject.GetComponent<SpriteRenderer>().color;

        if(collider.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            packageColor = collisionObjectColor;
            Destroy(collider.gameObject, 0.2f);
            spriteRenderer.color = collisionObjectColor;
            // Debug.Log("Package picked up!");
        }
        else if(collider.tag == "Customer" && hasPackage && equals(packageColor, collisionObjectColor))
        {
            hasPackage = false;
            spriteRenderer.color = defaultColor;
            // Debug.Log("Package delivered!");
        }
    }

    private bool equals(Color32 c1, Color32 c2) {
        return c1.r == c2.r && c1.g == c2.g && c1.b == c2.b;
    }
}
