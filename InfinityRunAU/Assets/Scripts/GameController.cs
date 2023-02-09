using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //ground property
    [Header("Ground Config")]

    [SerializeField] float      _destroyedGround;
    public float destroyedGround
    {
        get { return _destroyedGround; }
        set { _destroyedGround = value;}
    }
    

    [SerializeField] float      _groundSize;
    public float groundSize
    {
        get { return _groundSize; }
        set { _groundSize = value; }
    }


    [SerializeField] float      _groundSpeed;
    public float groundSpeed
    {
        get { return _groundSpeed; }
        set { _groundSpeed = value; }
    }


    [SerializeField] GameObject _groundPrefab;
    public GameObject groundPrefab
    {
        get { return _groundPrefab; }
        set { _groundPrefab = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
