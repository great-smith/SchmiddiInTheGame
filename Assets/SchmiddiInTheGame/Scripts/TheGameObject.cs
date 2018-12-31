using UnityEngine;
using System.Collections;

/// <summary>
/// Oberste Klasse für Spielobjekte des PixelArt-Games.
/// Enthält allgemeine Funktionen, die für die meisten Szenenobjekte
/// potentiell nützlich sind.
/// </summary>
public class TheGameObject : MonoBehaviour
{
    /// <summary>
    /// Größe eines PixelArt-Pixels in Unity-Einheiten.
    /// </summary>
    private static float pixelFrac = 1f / 32f; //32 = Pixels per Unit

    /// <summary>
    /// Runde auf PixelArt-Pixel.
    /// </summary>
    /// <param name="f">Zahl, die gerundet werden soll.</param>
    /// <returns>f, eingerastet im PixelArt-Raster.</returns>
    protected float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }

    /// <summary>
    /// Zeiger auf den Box-Collider für die Kollisionserkennung
    /// mittels isColliding, um die Suchfunktion (getComponent) einzusparen.
    /// </summary>
    private BoxCollider2D boxCollider;
    /// <summary>
    /// Ergebnis-Zwischenspeicher für die Kollisionserkennung
    /// mittels isColliding.
    /// </summary>
    private Collider2D[] colliders;

    private Animator anim;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        colliders = new Collider2D[10];
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Prüft, ob eine Kollision zwischen dem BoxColider2D dieses Spielobjekts
    /// und anderen 2D-Kollidern stattfindet.
    /// </summary>
    /// <returns><c>true</c>, bei Kollision, <c>false</c> sonst.</returns>
    protected bool isColliding()
    {
        return boxCollider.OverlapCollider(new ContactFilter2D(), colliders) > 0;
    }

    /// <summary>
    /// Bewegung, die die Figur in diesem Frame vollziehen soll.
    /// moveSpeed = nach rechts/oben, -moveSpeed = nach links/unten
    /// </summary>
    public Vector3 change = new Vector3();

    private void LateUpdate()
    {
        anim.SetFloat("change_x", change.x);
        anim.SetFloat("change_y", change.y);

        if (change.y <= -1f) anim.SetFloat("lookAt", 0f);
        else if (change.x <= -1f) anim.SetFloat("lookAt", 1f);
        else if (change.y >= 1f) anim.SetFloat("lookAt", 2f);
        else if (change.x >= 1f) anim.SetFloat("lookAt", 3f);

        // Anwenden der in change gesetzten Bewegung.
        float step = roundToPixelGrid(1f * Time.deltaTime);
        Vector3 oldPos = transform.position;
        transform.position += change * step;
        if (isColliding()) transform.position = oldPos;
        change = Vector3.zero;
    }
}
