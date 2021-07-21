using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBehavior : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject tool;
    public GameObject toolSeedImage;

    public Transform posL;
    public Transform posR;

    public Transform waterPosL;
    public Transform waterPosR;

    public Sprite tillerToolSprite;
    public Sprite waterToolSprite;
    public Sprite seederToolSprite;

    public Image toolLight;

    public Color greenColor = Color.green;
    public Color redColor = Color.red;

    public int toolSelectedNum = 1;

    public bool toolOn;


    // Start is called before the first frame update
    void Start()
    {
        toolOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        ToolPosition();
        ToolSelection();
        ActiveTool();
    }

    public void ToolPosition()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            tool.transform.position = posR.position;
            tool.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            tool.transform.position = posL.position;
            tool.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void ToolSelection()
    {
        if (gameObject.GetComponent<PlayerBehavior>().isTractor == false)
        {
            tool.tag = "noTool";
            toolSelectedNum = 1;
            toolOn = false;
        }

        else 
        {
            //no tool out
            if (Input.GetKey(KeyCode.Alpha1))
            {
                tool.SetActive(false);
                toolSelectedNum = 1;
                tool.tag = "noTool";
                toolOn = false;
            }

            //tiller tool
            if (Input.GetKey(KeyCode.Alpha2))
            {
             //   tool.SetActive(true);
                tool.GetComponent<SpriteRenderer>().sprite = tillerToolSprite;
                toolSelectedNum = 2;
                tool.tag = "tillerTool";
            }

            //water tool
            if (Input.GetKey(KeyCode.Alpha3))
            {
             //   tool.SetActive(true);
                tool.GetComponent<SpriteRenderer>().sprite = waterToolSprite;
                toolSelectedNum = 3;
                tool.tag = "waterTool";
            }

            //seeding tool
            if (Input.GetKey(KeyCode.Alpha4))
            {
              //  tool.SetActive(true);
                tool.GetComponent<SpriteRenderer>().sprite = seederToolSprite;
                toolSelectedNum = 4;
                tool.tag = "seederTool";
            }
        }     
    }

    public void ActiveTool()
    {
        if (Input.GetKeyUp(KeyCode.Space) && toolSelectedNum != 1)
        {
            toolOn = !toolOn;
        }

        if (toolOn == true)
        {
            toolLight.color = greenColor;  
        }

        else 
        {
            toolLight.color = redColor;
        }

        if (toolSelectedNum == 4)
        {
            toolSeedImage.SetActive(true);
        }

        else if (toolSelectedNum != 4)
        {
            toolSeedImage.SetActive(false);
        }
    }
}
