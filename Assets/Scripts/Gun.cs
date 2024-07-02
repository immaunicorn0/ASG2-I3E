using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public TMP_Text ammoText;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
        muzzleFlash.Stop();
    }

    void Update()
    {
        if (isReloading)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        ammoText.text = "Reloading...";
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
        isReloading = false;
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        Debug.Log("Shooting...");
        currentAmmo--;
        UpdateAmmoUI();
        PlayMuzzleFlash();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Stop();
        muzzleFlash.Play();
    }

    void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
    }
}