using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowTo : MonoBehaviour
{
    [SerializeField] Text _howto;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
