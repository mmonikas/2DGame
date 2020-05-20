using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BehaviourController : MonoBehaviour
{
    public Text scoreText;
    public Text winText;
    public bool isGameWin = false;
    public bool isGameLost = false;
    private Rigidbody2D rb;
    private int points = 0;
    private int allPoints = 5; // liczba wszytskich, mowi o wygranej
   
    void Start()
    {
        scoreText.text = points.ToString() + " / " + allPoints.ToString();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameLost || isGameWin)
        {
            print("inhere");
            if (Input.GetKeyDown("space"))
            {
                ReloadMainScene();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndOfMap"))
        {
            gameObject.SetActive(false);
        }
    }

    /*
     * 1. kiedy postać spadnie, wylaczyc gre, pokazac informacje i wlaczyc od nowa na jakikolwiek przycisk
     * 2. pokazywac ile elementow na planszy, trzeba zebrać wszystkie
     * 3. chodzić i zbierać monety :(
     * 4. jeśli zdazymy to kolcowe kule mogą zabijac nas (dzieje sie to samo co jak spadnie), ale nie weim co moga robić kule
     * moze byc ze tylko stoja blisko monet i latwo na nie wejrsc i tez zabijaja.
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Killer"))
        {
            lose(collision.collider);
            //zabity
            //tu zbieram monety po tagach jakichs spoko, wszystkie monety tag tak tag
        } else if (collision.collider.CompareTag("Coin"))
        {
            
            CheckObject(collision.collider);
        }
    }

    private void CheckObject(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coin"))
        {
            points += 1;
            scoreText.text = points.ToString() + " / " + allPoints.ToString();
            other.gameObject.SetActive(false);
           // Destroy(collision.gameObject);

            print("Got coin");
        }
        if (points == allPoints)
        {
            win(other);

        }
        scoreText.text = points.ToString() + " / " + allPoints.ToString();
    }

    private void win(Collider2D other)
    {
        print("Win");
        winText.text = "YOU WIN\nPress space to play again";

        isGameWin = true;
        rb.isKinematic = true;
    }

    private void lose(Collider2D other)
    {
        print("lost");
        winText.text = "YOU LOST\nPress space to play again";

        isGameLost = true;

        gameObject.SetActive(false);
        //other.gameObject.SetActive(false);
    }

    private void ReloadMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
