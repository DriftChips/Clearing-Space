using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : MonoBehaviour
{

    public float speed = 10.0f;      //Speed of junk.
    public float radius = 100f;     //Radius of magnet, junk will move in this radius at above speed

    private Transform target;
    private GameObject player;
    private Cargo playerInventory;
    private bool init = false;

    private void Start()
    {
        player = GlobalReferences.Singleton.Player;
        playerInventory = GlobalReferences.Singleton.PlayerCargo;
        
        if (player && playerInventory) { init = true; }
        else { Debug.LogError("!Junk Initalisation Failed!"); }
    }

    void FixedUpdate()
    {
        if (!init) { return; }

        if (Vector3.Distance(transform.position,  player.transform.position) < radius)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            // Check if the position of the player and junk are approximately equal.
            if (Vector3.Distance(transform.position, player.transform.position) < 1f)
            {
                AddCargo(1);
            }
        }
    }

    private void AddCargo(int amount)
    {
        if (playerInventory.AddCargo(amount)) { Destroy(gameObject); }   //Add junk to inventory if successful
    }
}
