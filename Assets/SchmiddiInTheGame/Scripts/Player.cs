using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 1f;

    private void FixedUpdate () 
    {
        float step = roundToPixelGrid(moveSpeed * Time.deltaTime);

        Vector3 change = new Vector3();

        if (Input.GetKey(KeyCode.D))
            change.x = step;
        else if (Input.GetKey(KeyCode.A))
            change.x = -step;
        else if (Input.GetKey(KeyCode.W))
            change.y = step;
        else if (Input.GetKey(KeyCode.S))
            change.y = -step;

        Vector3 oldPos = transform.position;
        transform.position += change;
        if (isColliding()) transform.position = oldPos;
	}

    private bool isColliding()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Collider2D[] colliders = new Collider2D[10];
        return boxCollider.OverlapCollider(new ContactFilter2D(), colliders) > 0;
    }

    /// <summary>
    /// Größe eines PixelArt-Pixels in Unity-Einheiten.
    /// </summary>
    private static float pixelFrac = 1f / 32f; //32 = Pixels per Unit

    /// <summary>
    /// Runde auf PixelArt-Pixel.
    /// </summary>
    /// <param name="f">Zahl, die gerundet werden soll.</param>
    /// <returns>f, eingerastet im PixelArt-Raster.</returns>
    private float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }
}
