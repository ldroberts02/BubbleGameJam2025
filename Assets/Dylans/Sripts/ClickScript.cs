using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public Wallet wallet;

    public int bubblesPerClick = 1;
    private BubbleFloat bubbleFloat;
    // Start is called before the first frame update
    void Start()
    {
        wallet = GameObject.Find("WalletManager").GetComponent<Wallet>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
         if (hit.collider !=null) {
             hit.collider.gameObject.GetComponent<BubbleFloat>().Clicked();
             wallet.AddBubbles(bubblesPerClick);
            }
        }
    }
}
