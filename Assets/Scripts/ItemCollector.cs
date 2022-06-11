using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;

    //OnTriggerEnter2D in case of no-trigger selected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            cherries++;
            Destroy(collision.gameObject);

            cherriesText.text = "Cherries: " + cherries;

            //Debug.Log("Cherries: " + cherries);
        }
    }
}
