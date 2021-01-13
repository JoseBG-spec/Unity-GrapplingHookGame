using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletPlace;
    [SerializeField]
    private AudioSource laser;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("bul");
            laser.Play();
            Instantiate(bullet, bulletPlace);

        }
    }
}
