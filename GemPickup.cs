using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    //gems picked up by the player
    public GameObject gem1;
    public GameObject gem2;
    public GameObject gem3;
    public GameObject gem4;

    //gem icons that indicate what the player has picked up
    public GameObject gemIcon1;
    public GameObject gemIcon2;
    public GameObject gemIcon3;
    public GameObject gemIcon4;

    public Color gemColor1;
    public Color gemColor2;
    public Color gemColor3;
    public Color gemColor4;

    public bool haveGem1;
    public bool haveGem2;
    public bool haveGem3;
    public bool haveGem4;

    public static bool depositedGem1;
    public static bool depositedGem2;
    public static bool depositedGem3;
    public static bool depositedGem4;



    // Start is called before the first frame update
    void Start()
    {
        gemIcon1.GetComponent<SpriteRenderer>().color = new Color(gemColor1.r, gemColor1.g, gemColor1.b, 0f);
        gemIcon2.GetComponent<SpriteRenderer>().color = new Color(gemColor2.r, gemColor1.g, gemColor2.b, 0f);
        gemIcon3.GetComponent<SpriteRenderer>().color = new Color(gemColor3.r, gemColor1.g, gemColor3.b, 0f);
        gemIcon4.GetComponent<SpriteRenderer>().color = new Color(gemColor4.r, gemColor1.g, gemColor4.b, 0f);

        haveGem1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "g1" && haveGem2 == false && haveGem3 == false && haveGem4 == false)
        {
            TouchGem(haveGem1 = true, gem1, gemIcon1, gemColor1);

        }

        if (collision.tag == "g2" && haveGem1 == false && haveGem3 == false && haveGem4 == false)
        {
            TouchGem(haveGem2 = true, gem2, gemIcon2, gemColor2);

        }

        if (collision.tag == "g3" && haveGem1 == false && haveGem2 == false && haveGem4 == false)
        {
            TouchGem(haveGem3 = true, gem3, gemIcon3, gemColor3);

        }

        if (collision.tag == "g4" && haveGem1 == false && haveGem2 == false && haveGem3 == false)
        {
            TouchGem(haveGem4 = true, gem4, gemIcon4, gemColor4);

        }

        if (collision.tag == "backpack")
        {

            print("Backpack");


            if (haveGem1 == true)
            {
                DepositGem(haveGem1 = false, gem1, gemIcon1, gemColor1, depositedGem1 = true);
            }

            if (haveGem2 == true)
            {
                DepositGem(haveGem2 = false, gem2, gemIcon2, gemColor2, depositedGem2 = true);
            }

            if (haveGem3 == true)
            {
                DepositGem(haveGem3 = false, gem3, gemIcon3, gemColor3, depositedGem3 = true);
            }

            if (haveGem4 == true)
            {
                DepositGem(haveGem4 = false, gem4, gemIcon4, gemColor4, depositedGem4 = true);
            }
        }
    }

    public void TouchGem(bool haveG, GameObject G, GameObject gIcon, Color gemCol)
    {
        G.SetActive(false);
        gIcon.GetComponent<SpriteRenderer>().color = new Color(gemCol.r, gemCol.g, gemCol.b, .5f);
    }

    public void DepositGem(bool haveG, GameObject G, GameObject gIcon, Color gemCol, bool deposit)
    {
        gIcon.GetComponent<SpriteRenderer>().color = new Color(gemCol.r, gemCol.g, gemCol.b, 1f);
    }
}
