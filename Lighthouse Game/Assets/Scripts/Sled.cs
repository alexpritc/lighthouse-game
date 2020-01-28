using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sled : MonoBehaviour
{
    public GameObject player;

    // Line drawing.
    private LineRenderer lineRend;
    private Vector2 l_start;
    private Vector2 l_end;


    // Player position, my position, ideal next position,.
    private Vector3 p_pos;
    private Vector3 pos;
    private Vector3 i_pos;

    // Offsets to get ideal position.
    private float x_off = 0.5f;
    private float y_off = 0.5f;
    private float right = -0.5f;
    private float left = 0.5f;
    private string facing;

    // Other.
    private bool active = false;
    public float speed = 0.1f;



    // Start is called before the first frame update.
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;

    }

    // Update is called once per frame.
    void Update()
    {
        // Update position + distance between player and me.
        p_pos = player.transform.position;
        i_pos = new Vector3(p_pos.x - x_off, p_pos.y - y_off, p_pos.z);
        pos = transform.position;
        Vector3 to_p = pos - p_pos;
        //Debug.Log(to_p);


        // Is the player moving left or right?
        float x = Input.GetAxis("Horizontal");
        if (x < 0)
        {
            facing = "right";
            x_off = right;
        }
        else if (x is 0)
        {
            facing = "still";
        }
        else if (x > 0)
        {
            facing = "left";
            x_off = left;
        }

        // Is the player dragging me.
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (active)
            {
                active = false;
            }
            else
            {
                active = true;
            }
        }

        if (active)
        {
            // Move towards players positions.
            transform.position = Vector3.Lerp(pos, i_pos, speed);

            // Draw line between me and the player.
            lineRend.enabled = true;
            lineRend.SetPosition(0, new Vector3(pos.x, pos.y, pos.z));
            lineRend.SetPosition(1, new Vector3(p_pos.x, p_pos.y, p_pos.z));
        }
        else
        {
            lineRend.enabled = false;
            transform.position = Vector3.Lerp(pos, new Vector3(pos.x, -0.3f, pos.z), speed);
        }
    }
}
