using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentBox : MonoBehaviour
{

    //Detect falling box
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
