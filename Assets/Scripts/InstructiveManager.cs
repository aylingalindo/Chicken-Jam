//  using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InstructiveManager : MonoBehaviour
{
    private int pageCounter = 0;

    //Text instructions
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_Text pageText;


    //Page buttons
    public Button prevPageBtn;
    public Button nextPageBtn;


    //instructions captions
    private List<string> instructions = new List<string>
    {
        "FOLLOW THE INSTRUCTIONS TO TAKE CARE OF BARTOLO CHICKEN POLLO",
        "If bartolo is sad he...", "Needs a hug",
        "If bartolo is VERY sad he...", "Needs a word encouragement",
        "If bartolo is angry he...", "Needs to play",
        "If bartolo is VERY angry he...", "Needs to eat OR sleep",
        "If bartolo is tired he...", "Needs to sleep",
        "If bartolo is VERY tired he...", "Needs water",
        "If bartolo pooped he...", "Needs to be cleaned",
        "If bartolo popped A LOT he...", "Needs a shower"
    };

    public List<string> sad;
    public List<string> tooSad;
    public List<string> tired;
    public List<string> tooTired;
    public List<string> angry;
    public List<string> tooAngry;
    public List<string> pooped;
    public List<string> tooPooped;

    public Image[] expressions = new Image[8];
    public List<int> indexesImages;
    public Image chicken;

    public int pruebas = 0;


    void Start()
    {
        sad = new List<string> { instructions[1], instructions[2] };
        tooSad = new List<string> { instructions[3], instructions[4] };
        tired = new List<string> { instructions[9], instructions[10] };
        tooTired = new List<string> { instructions[11], instructions[12] };
        angry = new List<string> { instructions[5], instructions[6] };
        tooAngry = new List<string> { instructions[7], instructions[8] };
        pooped = new List<string> { instructions[13], instructions[14] };
        tooPooped = new List<string> { instructions[15], instructions[16] };

        randomInstruction();
        pageText.text = "Page " + pageCounter + "/" + (instructions.Count - 1);
        instructionText.text = instructions[pageCounter];

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }


    void randomInstruction()
    {
        List <int> i = new List<int> { 0,1,2,3,4,5,6,7};
        instructions = new List<string> { "FOLLOW THE INSTRUCTIONS TO TAKE CARE OF BARTOLO CHICKEN POLLO" };
        indexesImages = new List<int> { };
        while (instructions.Count < 17)
       {
            int random = Random.Range(0,i.Count);
            indexesImages.Add(i[random]);

            switch (i[random])
            {
                case 0:
                    instructions.Add(sad[0]);
                    instructions.Add(sad[1]);
                    break;
                case 1:
                    instructions.Add(tooSad[0]);
                    instructions.Add(tooSad[1]);
                    break;
                case 2:
                    instructions.Add(tired[0]);
                    instructions.Add(tired[1]);
                    break;
                case 3:
                    instructions.Add(tooTired[0]);
                    instructions.Add(tooTired[1]);
                    break;
                case 4:
                    instructions.Add(angry[0]);
                    instructions.Add(angry[1]);
                    break;
                case 5:
                    instructions.Add(tooAngry[0]);
                    instructions.Add(tooAngry[1]);
                    break;
                case 6:
                    instructions.Add(pooped[0]);
                    instructions.Add(pooped[1]);
                    break;
                case 7:
                    instructions.Add(tooPooped[0]);
                    instructions.Add(tooPooped[1]);
                    break;
            }
            i.RemoveAt(random);
            
        }
    }

    public void NextPage()
    {
        Debug.Log("Inicio");
        int MAX_PAGE = (instructions.Count - 1);

        expressions[indexesImages[(pageCounter - 1) / 2]].gameObject.SetActive(false);
        chicken.gameObject.SetActive(false);

        //page behaviour
        Debug.Log(pageCounter);
        pageCounter = pageCounter+1 >= MAX_PAGE ? MAX_PAGE : pageCounter+1;
        pageCounter = pageCounter <= 0 ? 0 : pageCounter;
        Debug.Log(pageCounter);

        pageText.text = "Page " + pageCounter + "/" + MAX_PAGE;

        //instruction behaviour
        instructionText.text = instructions[pageCounter];

        //img
        //SI NO ES PAR 
        if (pageCounter % 2 != 0)
        {
            Debug.Log(indexesImages[pageCounter / 2]);
            expressions[indexesImages[pageCounter / 2]].gameObject.SetActive(true);
            chicken.gameObject.SetActive(true);
        }
    }

    public void PrevPage() 
    {
        int MAX_PAGE = (instructions.Count - 1);
        expressions[indexesImages[(pageCounter - 1) / 2]].gameObject.SetActive(false);
        chicken.gameObject.SetActive(false);

        pageCounter--;
        Debug.Log(pageCounter);
        pageCounter = pageCounter <= 0 ? 0 : pageCounter;
        Debug.Log(pageCounter);

        pageText.text = "Page " + pageCounter + "/" + MAX_PAGE;

        //instruction behaviour
        instructionText.text = instructions[pageCounter];

        if (pageCounter % 2 != 0)
        {
            expressions[indexesImages[pageCounter / 2]].gameObject.SetActive(true);
            chicken.gameObject.SetActive(true);
        }
    }

}
