
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Gun damage
    public float damage = 10f;

    //gun range
    public float range = 100f;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;
    
    //camera that the raycast is shot out of
    public Camera fpsCam;

    //muzzle flash effect during shot
    public ParticleSystem muzzleFlash;

    //the impact effect that shows after shot
    public GameObject impactEffect;

    //force of the bullet impact
    public float impactForce = 30f;

    public AudioSource shootAudio;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/fireRate;
            shoot();
        }
    }
    //Shooting using raycasting;
    void shoot(){
        muzzleFlash.Play();
        shootAudio.Play();
        RaycastHit hit;

        //Shoots out a ray from the camera position in the forward direction.
        //outputs the information in the hit variable and range will make sure the ray isnt over that length(optional)
        //evaluates true if it hits something
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            //Sets what is at the other end of ray as enemy if the thing is of type enemy
            Enemy target = hit.transform.GetComponent<Enemy>();

            //Checks to make sure that the target is not an environment piece
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            //access the hit object's ridgid body if it has one
            if (hit.rigidbody != null){
                //adds the force of the bullet to the object so it moves
                hit.rigidbody.AddForce(-hit.normal*impactForce);
            }

            //create the impact effect object after there is a hit in the normal direction away from the surface
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }
    }
}
