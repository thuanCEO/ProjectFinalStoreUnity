using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string tenSceneMoi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player has entered the trigger zone");
            PlayerPrefs.SetFloat("PlayerPosX", other.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", other.transform.position.y);
            ChuyenScene();
        }
    }

    void ChuyenScene()
    {
        UnityEngine.Debug.Log("Chuyen scene to " + tenSceneMoi);
        SceneManager.LoadScene(tenSceneMoi);
    }

}
