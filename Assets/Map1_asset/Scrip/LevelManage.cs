using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManage : MonoBehaviour
{
    public GameObject deathPanel;
    public Button restartButton;
    public Button respawnButton;
    public GameObject playerPrefab;

    public int maxRevives; 
    private int revivesRemaining;
    private void Start()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(false);
            restartButton.gameObject.SetActive(false);
            respawnButton.gameObject.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        DestroyOldPlayer();
        SaveHealth.flag = true;
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DestroyOldPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Destroy(player);
        }
    }

    public void SpawnNewPlayer()
    {
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }

    public void ShowDeathPanel()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
            restartButton.gameObject.SetActive(true);
            respawnButton.gameObject.SetActive(true);
        }
    }
    public void RespawnWithFullHealth()
    {
        if (GetMaxRevives() > 0)
        {
            Vector3 respawnPosition = CalculateDeathPosition();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = respawnPosition;
                Health playerHealth = player.GetComponent<Health>();
                if (playerHealth != null)
                {
                    SaveHealth.flag = true;
                    playerHealth.Respawn();
                    SetMaxRevives(GetMaxRevives() - 1); 
                }
            }

            deathPanel.SetActive(false);
            respawnButton.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("The number of respawns has expired!");
        }
    }

    public int GetMaxRevives()
    {

        return maxRevives;
    }

    public void SetMaxRevives(int value)
    {

        maxRevives = value;
    }


    private Vector3 CalculateDeathPosition()
    {
        GameObject oldPlayer = GameObject.FindGameObjectWithTag("Player");
        if (oldPlayer != null)
        {
            return oldPlayer.transform.position;
        }
        else
        {
            return transform.position;
        }
    }
}
