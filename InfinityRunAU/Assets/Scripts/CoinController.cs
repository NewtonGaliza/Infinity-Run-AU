using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Rigidbody2D _moedasRigidbody;
    private GameController _gameController;



    // Start is called before the first frame update
    void Start()
    {
        _moedasRigidbody = GetComponent<Rigidbody2D>();
        _moedasRigidbody.velocity = new Vector2(-6f, 0);

        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        { 
            _gameController.Pontos(1);

            _gameController.fxGame.PlayOneShot(_gameController.fxMoedaColetada);

            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }



}
