using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManage : MonoBehaviour
{
    public GameObject deathPanel;
    public Button restartButton;
    public GameObject playerPrefab;

    private void Start()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(false);
            restartButton.gameObject.SetActive(false);
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
        }
    }
}
