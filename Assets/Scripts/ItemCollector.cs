using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int melons = 0;
    [SerializeField] private TextMeshProUGUI tmp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            melons++;
            Debug.Log(melons);
            tmp.text = "Melons: " + melons;
        }
    }
}
