using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            gameObject.SetActive(false);
            //zabity
            //tu zbieram monety po tagach jakichs spoko, wszystkie monety tag tak tag
        } else if (collision.collider.CompareTag("Coin"))
        {
            points += 1;
            Destroy(collision.gameObject);
        }
    }
}
