using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public void LoadTable(int level) {
        Registry.level = level;
        Registry.Shuffle();

        SceneManager.LoadScene("Table");
    }
}
