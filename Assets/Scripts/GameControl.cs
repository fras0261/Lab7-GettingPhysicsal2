using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public Text healthText;
    public int healthPoints = 10;
    public GameObject skull;
    public Material skullMaterial;

    private Color[] _healthColours;

    // Use this for initialization
    void Start () {
        _healthColours = new Color[healthPoints];
        FillHealthColourList();
        skullMaterial.color = new Color (1, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void FillHealthColourList()
    {
        float colorVarFactor = 255 / healthPoints;
        float greenValue = 255.0f;

        for (int i = 0; i < healthPoints; i++)
        {
            _healthColours[i] = new Color(1, greenValue/255, 1);
            greenValue -= colorVarFactor;
        }
    }

    public void DecreaseHealth()
    {
        healthPoints--;
        healthText.text = "Skull Health: " + healthPoints;

        if (healthPoints >= 1)
            skullMaterial.color = _healthColours[healthPoints-1];

        Debug.Log(skullMaterial.color);

        if (healthPoints <= 0)
        {
            SceneManager.LoadScene("Dentist");
        }
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }

}
