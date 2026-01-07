using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public int maxAmmoInMag = 10;        // Maximum ammo capacity in the magazine
    public int maxAmmoInStorage = 30;    // Maximum ammo capacity in the storage
    public float shootCooldown = 0.5f;   // Cooldown time between shots
    public float reloadCooldown = 0.5f;  // Reload time
    private float switchCooldown = 0.5f; // Cooldown for switching weapons
    public float shootRange = 100f;      // Range of the raycast

    public ParticleSystem impactEffect;  // Particle effect for impact

    public int currentAmmoInMag;         // Current ammo in the magazine
    public int currentAmmoInStorage;     // Current ammo in the storage
    public int damager = 25;             // Damage dealt to enemies per shot

    public bool canShoot = true;         // Flag to check if shooting is allowed
    public bool canSwitch = true;        // Flag to check if switching is allowed
    private bool isReloading = false;    // Flag to check if reloading is in progress
    private float shootTimer;            // Timer for shoot cooldown

    public Transform cartridgeEjectionPoint; // Ejection point of the cartridge
    public GameObject cartridgePrefab;       // Prefab of the cartridge
    public float cartridgeEjectionForce = 5f;

    public Animator gun;
    public ParticleSystem muzzleFlash;
    public GameObject muzzleFlashLight;
    public AudioSource shoot;

    void Start()
    {
        currentAmmoInMag = maxAmmoInMag;
        currentAmmoInStorage = maxAmmoInStorage;
        canSwitch = true;

        if (muzzleFlashLight != null)
            muzzleFlashLight.SetActive(false);
    }

    void Update()
    {
        // Clamp ammo values
        currentAmmoInMag = Mathf.Clamp(currentAmmoInMag, 0, maxAmmoInMag);
        currentAmmoInStorage = Mathf.Clamp(currentAmmoInStorage, 0, maxAmmoInStorage);

        // Shoot input
        if (Input.GetButtonDown("Fire1") && canShoot && !isReloading)
        {
            switchCooldown = shootCooldown;
            Shoot();
        }

        // Reload input
        if (Input.GetKeyDown(KeyCode.R))
        {
            switchCooldown = reloadCooldown;
            Reload();
        }

        // Cooldown timer
        if (shootTimer > 0f)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        // Check ammo and cooldown
        if (currentAmmoInMag > 0 && shootTimer <= 0f)
        {
            canSwitch = false;

            if (shoot != null) shoot.Play();
            if (muzzleFlash != null) muzzleFlash.Play();
            if (muzzleFlashLight != null) muzzleFlashLight.SetActive(true);
            if (gun != null) gun.SetBool("shoot", true);

            // Raycast shot
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position,
                                Camera.main.transform.forward,
                                out hit, shootRange))
            {
                Debug.Log("Hit: " + hit.collider.name);

                // Look on the hit object and its parents for EnemyHealth
                EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damager);
                }

                // Impact effect
                if (impactEffect != null)
                {
                    Instantiate(impactEffect, hit.point,
                        Quaternion.LookRotation(hit.normal));
                }
            }

            // Cartridge ejection
            if (cartridgePrefab != null && cartridgeEjectionPoint != null)
            {
                GameObject cartridge = Instantiate(
                    cartridgePrefab,
                    cartridgeEjectionPoint.position,
                    cartridgeEjectionPoint.rotation);

                Rigidbody cartridgeRigidbody = cartridge.GetComponent<Rigidbody>();
                if (cartridgeRigidbody != null)
                {
                    cartridgeRigidbody.AddForce(
                        cartridgeEjectionPoint.right * cartridgeEjectionForce,
                        ForceMode.Impulse);
                }
            }

            StartCoroutine(endAnimations());
            StartCoroutine(endLight());
            StartCoroutine(canswitchshoot());

            switchCooldown -= Time.deltaTime;

            // Ammo and cooldown
            currentAmmoInMag--;
            shootTimer = shootCooldown;
        }
        else
        {
            Debug.Log("Cannot shoot");
        }
    }

    void Reload()
    {
        switchCooldown -= Time.deltaTime;

        if (isReloading || currentAmmoInStorage <= 0)
            return;

        int bulletsToReload = maxAmmoInMag - currentAmmoInMag;
        if (bulletsToReload <= 0)
        {
            Debug.Log("Cannot reload");
            return;
        }

        if (gun != null) gun.SetBool("reload", true);
        StartCoroutine(endAnimations());

        int bulletsAvailable = Mathf.Min(bulletsToReload, currentAmmoInStorage);

        currentAmmoInMag += bulletsAvailable;
        currentAmmoInStorage -= bulletsAvailable;

        Debug.Log("Reloaded " + bulletsAvailable + " bullets");

        StartCoroutine(ReloadCooldown());
    }

    IEnumerator ReloadCooldown()
    {
        isReloading = true;
        canShoot = false;
        canSwitch = false;

        yield return new WaitForSeconds(reloadCooldown);

        isReloading = false;
        canShoot = true;
        canSwitch = true;
    }

    IEnumerator endAnimations()
    {
        yield return new WaitForSeconds(0.1f);
        if (gun != null)
        {
            gun.SetBool("shoot", false);
            gun.SetBool("reload", false);
        }
    }

    IEnumerator endLight()
    {
        yield return new WaitForSeconds(0.1f);
        if (muzzleFlashLight != null)
            muzzleFlashLight.SetActive(false);
    }

    IEnumerator canswitchshoot()
    {
        yield return new WaitForSeconds(shootCooldown);
        canSwitch = true;
    }
}
