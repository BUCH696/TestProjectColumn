using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI : MonoBehaviour
{

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}
