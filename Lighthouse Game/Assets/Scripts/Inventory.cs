using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject sled;

    // My width, height, and the gap between my tiles.
    public int grid_w = 4;
    public int grid_h = 2;
    public float tile_size = 1f;

    // My y value to modify the sled's with.
    public float base_y_adjust = 0.15f;
    private float y_adjust;
    private float offscreen = -15f;

    // Am I visible?.
    public bool active = true;

    // Sled position.
    private Vector3 sled_pos;

    // Start is called before the first frame update.
    void Start()
    {
        y_adjust = base_y_adjust;
        GenerateGrid();
    }

    // Update is called once per frame.
    void Update()
    {
        sled_pos = sled.transform.position;
        Vector3 pos = transform.position;

        //Toggle active and visible (WORKS BADLY- DOESNT ACTUALLY WORK)
        if (Input.GetKeyUp(KeyCode.Q))
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
        Debug.Log(active);
    }


    private void GenerateGrid()
    {   
        // Get reference object from resource file.
        GameObject ref_tile = (GameObject)Instantiate(Resources.Load("blank_tile"));  
        // Create a row.
        for (int row = 0; row < grid_h; row++)
        {
            // For every cell in a row, create a column down.
            for (int col = 0; col < grid_w; col++)
            {
                // Create a sprite for each cell and shift each cell to its grid position.
                GameObject tile = (GameObject)Instantiate(ref_tile, transform);
                float posX = col * tile_size;
                float posY = row * -tile_size;
                tile.transform.position = new Vector3(posX -0.2f, posY + y_adjust, 0);
            }
        }
        Destroy(ref_tile);
    }
}