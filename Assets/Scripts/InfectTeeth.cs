using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InfectTeeth : MonoBehaviour {

    public Color infectionColour;
    public List<GameObject> teeth;
    public float nextInfectionDelay = 0.5f;

    private List<Transform> _teethLocation;

    private int _infectToothCount = 0;
    private float _elapsedTime = 0.0f;
    private bool _allTeethInfected = false;

	// Use this for initialization
	void Start () {
        //Go and store all of the initial positions/transforms of the teeth so we can sapwn new teeth at this location later

    }
	
	// Update is called once per frame
	void Update () {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= nextInfectionDelay && _allTeethInfected == false)
        {
            _elapsedTime = 0.0f;
            InfectTooth();
        } 
    }

    /// <summary>
    /// 
    /// </summary>
    public void InfectTooth()
    {
        if (teeth.Count > 0)
        {
            for (int attemptedToothCount = 0; attemptedToothCount < teeth.Count; attemptedToothCount++)
            {
                int index = (int)Random.Range(0, teeth.Count);
                GameObject selectedTooth = teeth[index];
                if (selectedTooth.GetComponent<Infection>() == null )
                {
                    Infection newInfection = selectedTooth.AddComponent<Infection>();
                    newInfection.infectedColour = infectionColour;
                    _infectToothCount++;
                    break;
                }
                else
                {
                    continue;
                } 
            }
        }

        if (_infectToothCount == teeth.Count)
            _allTeethInfected = true;
    }

    public void RemoveTooth(GameObject toothToRemove)
    {
        if (teeth.Contains(toothToRemove))
        {
            int toothIndex = teeth.IndexOf(toothToRemove);
            teeth[toothIndex] = null;
            Destroy(toothToRemove, 2.0f);
            _infectToothCount--;
            _allTeethInfected = false;
        }
    }

    public void SpawnTooth()
    {
        for (int toothIndex = 0; toothIndex < teeth.Count; toothIndex++)
        {
            if (teeth[toothIndex] == null)
            {

            }
        }
    }
}
