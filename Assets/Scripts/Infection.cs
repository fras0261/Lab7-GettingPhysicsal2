using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Infection : MonoBehaviour {

    public Color infectedColour;
    public bool _isFullyInfected = false;


    private float _infectionRate = 0.5f;
    private Color _oldColour;
    private Material _rendererMaterial;
    private float _elapsedTime = 0.0f;
    private float _elapsedInfectedTime = 0.0f;

    
	// Use this for initialization
	void Start () {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (renderer != null)
        {
            _rendererMaterial = renderer.material;
            _oldColour = _rendererMaterial.color;
        }   
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (_elapsedTime < 1.0f)
        {
            _elapsedTime += Time.deltaTime * _infectionRate;
            _rendererMaterial.color = Color.Lerp(_oldColour, infectedColour, _elapsedTime);
        }

        if (_rendererMaterial.color == infectedColour)
            _isFullyInfected = true;

	}

   
}
