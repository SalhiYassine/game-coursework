using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void PlayAgainBtn()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}