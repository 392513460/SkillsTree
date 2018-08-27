using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {
    public HeroType heroType;

    public void NextSceneClick()
    {
        SceneManager.LoadScene(1);
    }
}
