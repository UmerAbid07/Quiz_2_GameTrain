using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class SceneManagerCustom : MonoBehaviour
{
    PlayerControl playerControl;
    private void Start()
    {
        Invoke("playerControlSearch", 12f);
    }
    private void Update()
    {
        if (playerControl.nextLevel)
        {
            //winner
            print("Winner");
        }
    }
    void playerControlSearch()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }
}
