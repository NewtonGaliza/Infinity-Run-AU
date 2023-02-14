using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    private Rigidbody2D obstaculoRB;
    private GameController _gameController;

    private CameraShaker _cameraShaker;
    
    void Start()
    {
        obstaculoRB = GetComponent<Rigidbody2D>();
        // obstaculoRB.velocity = new Vector2(-5f, 0);

        _gameController = FindObjectOfType(typeof(GameController)) as  GameController;

        _cameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MoveObjeto();
        
    }

    void MoveObjeto()
    {
        transform.Translate(Vector2.left * _gameController.obstaculoVelocidade * Time.smoothDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            _gameController.vidasPlayer--;

            if(_gameController.vidasPlayer <= 0)
            {
                Debug.Log("GAME OVER");
                _gameController.txtVidas.text = "0";
            }
            else
            {
                _gameController.txtVidas.text = _gameController.vidasPlayer.ToString();
                _cameraShaker.ShakeIt();
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
