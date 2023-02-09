using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    private GameController _gameController;

    [SerializeField] bool _groundInstantiated = false;

    // Start is called before the first frame update
    void Start()
    {

        //_gameController = FindObjectOfType(typeof(GameController)) as GameController;
        _gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_groundInstantiated == false)
        {
            if(transform.position.x <= 0)
            {
                _groundInstantiated = true;
                GameObject groundTemporaryObject = Instantiate(_gameController.groundPrefab);
                groundTemporaryObject.transform.position = new Vector3(transform.position.x + _gameController.groundSize, transform.position.y, 0);
            }
        }

        if(transform.position.x < _gameController.destroyedGround) //-38
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        MoveGround();
    }

    void MoveGround()
    {
        transform.Translate(Vector2.left * _gameController.groundSpeed * Time.deltaTime);
    }
}
