using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int SceneManagementIndex;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            print("Swithching sceen to" + SceneManagementIndex);
            SceneManager.LoadScene(SceneManagementIndex, LoadSceneMode.Single);
        }
    }
}
