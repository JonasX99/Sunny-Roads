using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour
{
    public void Scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
