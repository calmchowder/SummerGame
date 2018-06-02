using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float health = 100;
    [SerializeField]
    private float energy = 100;
    [SerializeField]
    private float energyRegain = 1;


    public float Health { get { return health; } set { health = value; } }

    public float Energy { get { return energy; } set { energy = value; } }

    public void Update()
    {
        if(energy < 100)
            energy += energyRegain;
    }


    void OnGUI()
    {
        GUI.Label(new Rect(0, 100, 100, 50), "Health: " + health);
        GUI.Label(new Rect(0, 150, 100, 50), "Energy: " + energy);
    }
}
