using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    private AudioSource audio;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;


	void Start () {
        audio = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay,  fireRate);
	}
	
    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audio.Play();



    }

}
