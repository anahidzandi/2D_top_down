using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnTriggerEnter2D called.");
        if (col.transform.tag == "Player")
        {
            Debug.Log("Door hit");
            SceneManager.LoadScene("Outside");
        }
    }
}
