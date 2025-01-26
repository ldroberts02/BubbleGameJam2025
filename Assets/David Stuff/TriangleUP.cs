using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class TriangleUP : MonoBehaviour
{
    public BubbleFloat bubble;
    public Wallet wallet;
    public Upgrades upgrades;
    public int bubblespopped = 0;
    private void Start()
    {
        wallet = GameObject.Find("WalletManager").GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<BubbleFloat>().Clicked();
        wallet.AddBubbles(bubblespopped);
    }
}