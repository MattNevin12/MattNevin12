using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropBehavior : MonoBehaviour
{
    public GameObject gameManager;
    public CropStats cStats;
    
    public SpriteRenderer rend;

    public Sprite untilledTile;
    public Sprite dryTile;
    public Sprite wateredTile;

    //seed Sprites
    public Sprite breadfruitSeed;
    public Sprite onionSeed;
    public Sprite potatoSeed;
    public Sprite tomatoSeed;

    public Sprite seedSprite;
    public Sprite phase1Sprite;
    public Sprite phase2Sprite;
    public Sprite phase3Sprite;
    public Sprite harvestSprite;

    public GameObject crop;
    public SpriteRenderer cropRenderer;

    public string cropName;

    public int daysGrowing;
    public int phase1Num;
    public int phase2Num;
    public int phase3Num;
    public int harvestNum;

    public bool planted;


    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        crop = gameObject.transform.GetChild(0).gameObject;
        cropRenderer = crop.GetComponent<SpriteRenderer>();
        crop.SetActive(false);
        planted = false;

        gameManager = GameObject.Find("GameManager");
        cStats = gameManager.GetComponent<CropStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {


        if (other.GetComponentInParent<ToolBehavior>().toolOn)
        {
            if (other.tag == "Player")
            {
                print(other.GetComponent<ToolBehavior>().toolSelectedNum);

                //till soil
                if (tag == "untilled" && other.GetComponent<ToolBehavior>().toolSelectedNum == 2)
                {
                    rend.sprite = dryTile;
                    tag = "dry";
                }

                //water tilled soil
                if (other.GetComponent<ToolBehavior>().toolSelectedNum == 3)
                {
                    if (tag == "dry")
                    {
                        rend.sprite = wateredTile;
                        gameObject.tag = "watered";
                    }
                }

                //plant seeds
                if (tag != "untilled" && !planted && other.GetComponent<ToolBehavior>().toolSelectedNum == 4)
                {
                    PlantSeed();
                }
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<ToolBehavior>().toolOn)
        {
            ShowHoveredTiles();
        }

        else
            GetComponent<SpriteRenderer>().color = Color.white;
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void PlantSeed()
    {
        crop.SetActive(true);
        cropName = gameManager.GetComponent<SeedSelection>().seedSelectedString;
        planted = true;

        daysGrowing = 0;

        GetCropStats(cStats.cropDayCounts[gameManager.GetComponent<SeedSelection>().seedTypes.value][0], 
                     cStats.cropDayCounts[gameManager.GetComponent<SeedSelection>().seedTypes.value][1], 
                     cStats.cropDayCounts[gameManager.GetComponent<SeedSelection>().seedTypes.value][2],
                     cStats.cropSprites[gameManager.GetComponent<SeedSelection>().seedTypes.value][0], 
                     cStats.cropSprites[gameManager.GetComponent<SeedSelection>().seedTypes.value][1], 
                     cStats.cropSprites[gameManager.GetComponent<SeedSelection>().seedTypes.value][2], 
                     cStats.cropSprites[gameManager.GetComponent<SeedSelection>().seedTypes.value][3], 
                     cStats.cropSprites[gameManager.GetComponent<SeedSelection>().seedTypes.value][4]);

        cropRenderer.sprite = seedSprite;
    }

    public void GrowCrop()
    {
        if (tag == "watered" && planted)
        { 
             daysGrowing++;
        }

        if (daysGrowing > phase3Num)
        {
            cropRenderer.sprite = harvestSprite;
        }

        else if (daysGrowing >= phase2Num)
        {
            cropRenderer.sprite = phase3Sprite;
        }

        else if (daysGrowing > phase1Num)
        {
            cropRenderer.sprite = phase2Sprite;
        }

        else
        {
            cropRenderer.sprite = phase1Sprite;
        }

        rend.sprite = dryTile;
        tag = "dry";
    }

    public void GetCropStats(int p1, int p2, int p3, Sprite seed, Sprite s1, Sprite s2, Sprite s3, Sprite sHarvest)
    {
        phase1Num = p1;
        phase2Num = p2;
        phase3Num = p3; 

        seedSprite = seed;
        phase1Sprite = s1;
        phase2Sprite = s2;
        phase3Sprite = s3;
        harvestSprite = sHarvest;
    }

    public void ShowHoveredTiles()
    {
        if(gameManager.GetComponent<GameManagement>().showHoverTiles)
            GetComponent<SpriteRenderer>().color = Color.green;
    }
}
