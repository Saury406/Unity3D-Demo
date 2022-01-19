using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject light_end;
    //private static bool CanCallFlag = false;//需要方法传参

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            light_end.SetActive(true);
            Invoke("nextLevel",2.0f);
        }
    }
    private void nextLevel() {
        SceneManager.LoadScene("Level1");
    }

}
