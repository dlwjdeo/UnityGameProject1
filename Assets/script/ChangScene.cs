using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
    public void ChangeSecneBtn()
    {
        switch (this.gameObject.name)
        {
            case "START":
                SceneManager.LoadScene("game");
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("gameOver");
            Debug.Log("lol");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("gameOver");
            Debug.Log("lol");
        }
    }
}
