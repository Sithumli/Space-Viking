using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gaemmanager : MonoBehaviour
{
    // This method is called when the button is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
