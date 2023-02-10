using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeslocamentoBG : MonoBehaviour
{
    private Renderer objetoRender;
    private Material objetoMaterial;
    [SerializeField] float offset; //deslocamento
    [SerializeField] float offsetIncremento;
    [SerializeField] float offsetVelocidade;

    [SerializeField] string sortingLayer;
    [SerializeField ] int orderinLayer;

    // Start is called before the first frame update
    void Start()
    {
        objetoRender = GetComponent<MeshRenderer>();

        objetoRender.sortingLayerName = sortingLayer;
        objetoRender.sortingOrder = orderinLayer;

        objetoMaterial = objetoRender.material;
    }

    // Update is called once per frame
    void Update()
    {
        Deslocando();
    }

    void Deslocando()
    {
        offset += offsetIncremento;
        objetoMaterial.SetTextureOffset("_MainTex", new Vector2(offset * offsetVelocidade, 0));
    }
}
