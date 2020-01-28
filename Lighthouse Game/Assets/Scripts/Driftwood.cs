using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driftwood : MonoBehaviour
{
    public GameObject floor;

    // Vector for next position and to check that position, floors position.
    private Vector3 pos;
    private Vector3 n_pos;
    private Vector3 f_pos;

    private Vector2 spawn_range = new Vector2(-15f, 15f);

    // Plops me somewhere random on start.
    void Start()
    {
        f_pos = floor.transform.position;
        n_pos = new Vector3(f_pos.x + Random.Range(spawn_range.x, spawn_range.y), f_pos.y + 0.7f, -0.005f);
        pos = n_pos;
        transform.position = pos;
    }

    // Update is called once per frame.
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && Input.GetKey(KeyCode.E))
        {
            ResetPosition();
        }
    }

    // Jumps me too a new position when I've been gathered.
    void ResetPosition()
    {
        f_pos = floor.transform.position;
        n_pos = new Vector3(f_pos.x + Random.Range(spawn_range.x, spawn_range.y), f_pos.y + 0.7f, -0.005f);
        pos = n_pos;
        transform.position = pos;
    }

}
