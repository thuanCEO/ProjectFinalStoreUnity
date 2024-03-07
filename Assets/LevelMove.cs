using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int SceneManagementIndex;
    public Vector3 savedPlayerPosition;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        savedPlayerPosition = other.transform.position;
        DontDestroyOnLoad(other.gameObject);

        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            print("Swithching sceen to" + SceneManagementIndex);
            SceneManager.LoadScene(SceneManagementIndex, LoadSceneMode.Single);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                player.transform.position = savedPlayerPosition;
                player.SetActive(true);
            }
        }
        
    }
}
