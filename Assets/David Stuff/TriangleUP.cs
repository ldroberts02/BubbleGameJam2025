using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TriangleUP : MonoBehaviour
{
    public BubbleFloat bubble;
    public Wallet wallet;
    public int bubblespopped = 1;
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
