using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Door to Stairs" && Input.GetKey(KeyCode.E))
        {
            Debug.Log(":)");
            SceneManager.LoadScene("Bottom Lighthouse");
        }
        else if (other.gameObject.name == "Door to Stairs2" && Input.GetKey(KeyCode.E))
        {
            Debug.Log(":)");
            SceneManager.LoadScene("Top Lighthouse");
        }
    }
}
