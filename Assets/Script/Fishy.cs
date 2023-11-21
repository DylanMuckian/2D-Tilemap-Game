using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Fishy : MonoBehaviour, ICollectible
{
    public static event Action OnCoinCollected;
    public void Collect()
    {
        Debug.Log("Fishy Collected");
        Destroy(gameObject);
        OnCoinCollected?.Invoke();
    }
}
