using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleManager.instance.CollectCrystal();
            Destroy(gameObject);
        }
    }
}