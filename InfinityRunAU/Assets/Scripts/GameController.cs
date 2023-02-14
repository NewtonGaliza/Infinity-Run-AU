using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    [Header("Obstaculo Config")]
    [SerializeField] float _obstaculoTempo;
    [SerializeField] GameObject _obstaculoPrefab;
    [SerializeField] float _obstaculoVelocidade;
    public float obstaculoVelocidade
    {
        get { return _obstaculoVelocidade; }
        set { _obstaculoVelocidade = value; }
    }


    [Header("Coin Config")]
    [SerializeField] float _coinTempo;
    [SerializeField] GameObject _coinPrefab;

    
    [Header("UI Config")]
    [SerializeField] int _pontosPlayer;
    [SerializeField] Text _txtPontos;
    [SerializeField] int _vidasPlayer;
    public int vidasPlayer
    {
        get { return _vidasPlayer; }
        set { _vidasPlayer = value; }
    }
    [SerializeField] Text _txtVidas;
    public Text txtVidas
    {
        get { return _txtVidas; }
        set { _txtVidas = value; }
    }
    [SerializeField] Text _txtMetros;


    [Header("Controle de Distância")]
    [SerializeField] int _metrosPercorridos = 0;


    [Header("Sons e Efeitos")]
    [SerializeField ] AudioSource _fxGame;
    public AudioSource fxGame
    {
        get { return _fxGame; }
        set { _fxGame = value; }
    }
    [SerializeReference] AudioClip _fxMoedaColetada;
    public AudioClip fxMoedaColetada
    {
        get { return _fxMoedaColetada; }
        set { _fxMoedaColetada = value;}
    }
    [SerializeField ] AudioClip  _fxJump;
    public AudioClip fxJump
    {
        get { return _fxJump; }
        set { _fxJump = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaculo");
        StartCoroutine("SpawnCoin");
        InvokeRepeating("DistanciaPercorrida", 0f, 0.2f);
    }


    IEnumerator SpawnObstaculo()
    {
        yield return new WaitForSeconds(_obstaculoTempo);

        GameObject ObjetoObstaculoTemp = Instantiate(_obstaculoPrefab);

        StartCoroutine("SpawnObstaculo");

        yield return new WaitForSeconds(Random.Range(1, 3));

        //instanciar moedas
        StartCoroutine("SpawnCoin");
    }

    IEnumerator SpawnCoin()
    {
        int moedasAleatorias = Random.Range(1 ,5);
        for(int contagem = 1; contagem <= moedasAleatorias; contagem++)
        {
            yield return new WaitForSeconds(_coinTempo);
            GameObject _objetoSpawn = Instantiate(_coinPrefab);
            _objetoSpawn.transform.position = new Vector3(_objetoSpawn.transform.position.x, _objetoSpawn.transform.position.y, 0);
        }

    }

    public void Pontos(int qtdPontos)
    {
        _pontosPlayer += qtdPontos;
        _txtPontos.text = _pontosPlayer.ToString();
    }

    void DistanciaPercorrida()
    {
        _metrosPercorridos++;
        _txtMetros.text = _metrosPercorridos.ToString() + " M";

        if((_metrosPercorridos % 100) == 0)
        {
            _groundSpeed += 0.5f;
            _obstaculoTempo -= 0.15f;
            _obstaculoVelocidade += 0.15f;
        }
    }
   

}
