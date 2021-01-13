using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform pos1, pos2, pos3;
    private Transform pos;
    [SerializeField]
    private float timer;
    [SerializeField]
    private GameObject gm;
    void Start()
    {
        pos1.position= new Vector3(pos1.position.x, pos1.position.y, 0);
        pos2.position= new Vector3(pos2.position.x, pos2.position.y, 0);
        pos3.position= new Vector3(pos3.position.x, pos3.position.y, 0);
        InvokeRepeating("randomPlaces", timer, timer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                pos = pos1;
                break;
            case 1:
                pos = pos2;
                break;
            case 2:
                pos = pos3;
                break;

        }

    }
    private void randomPlaces()
    {
        
        Instantiate(gm, pos.position,pos.rotation);        
    }
}
