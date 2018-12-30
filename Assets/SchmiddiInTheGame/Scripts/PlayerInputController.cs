using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wertet Eingaben aus, die die Spielfigur steuern sollen
/// und leitet sie an das Player-Script weiter.
/// </summary>
public class PlayerInputController : MonoBehaviour {

    /// <summary>
    /// Zeiger auf das Player-Script, das durch die Eingabe
    /// gesteuert wird.
    /// </summary>
    public Player player;
    public float moveSpeed = 1f;
	
	// Update is called once per frame
	private void Update () 
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            player.change.x = moveSpeed;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            player.change.x = -moveSpeed;
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            player.change.y = moveSpeed;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            player.change.y = -moveSpeed;
    }
}
