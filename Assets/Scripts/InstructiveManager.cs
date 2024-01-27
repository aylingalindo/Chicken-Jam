using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CareInstructions
{
    public string Emotion;
    public string Instruction;
    public string Action;
    public Image expression;

    public CareInstructions(string _emotion, string _instruction, string _action)
    {
        this.Emotion = _emotion;
        this.Instruction = _instruction;
        this.Action = _action;
    }
}

public class InstructiveManager : MonoBehaviour
{
    private int pageCounter = 0;

    //Text instructions
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_Text pageText;


    //Page buttons
    public Button prevPageBtn;
    public Button nextPageBtn;

    //Care instructions
    public List<CareInstructions> instruction = new List<CareInstructions> 
    { 
        new CareInstructions("sad", "Si el pollito está triste...", "Necesita un abrazo"),
        new CareInstructions("tooSad", "Si el pollito está muy triste...", "Necesita una frase motivadora"),

        new CareInstructions("mad", "Si el pollito está enojado...", "Necesita jugar"),
        new CareInstructions("tooMad", "Si el pollito está muy enojado...", "Necesita comer y dormir"),

        new CareInstructions("tired", "Si el pollito está cansado...", "Necesita dormir"),
        new CareInstructions("tooTired", "Si el pollito está muy cansado...", "Necesita agua"),

        new CareInstructions("pooped", "Si el pollito se hizo popó...", "Necesita limpiarse"),
        new CareInstructions("tooPooped", "Si el pollito hizo mucha popó...", "Necesita bañarse"),
        
    };

    //
    private string[] instructions =
    {
        "INDICACIONES PARA CUIDADO DEL POLLITO",
        "Si el pollito está triste...", "Necesita un abrazo",
        "Si el pollito está muy triste...", "Necesita una frase motivadora",
        "Si el pollito está enojado...", "Necesita jugar",
        "Si el pollito está muy enojado...", "Necesita comer y dormir",
        "Si el pollito está cansado...", "Necesita dormir",
        "Si el pollito está muy cansado...", "Necesita agua",
        "Si el pollito se hizo popó...", "Necesita limpiarse",
        "Si el pollito hizo mucha popó...", "Necesita bañarse"
    };

    public Image[] expressions = new Image[8];

    void Start()
    {
        pageText.text = "Hoja " + pageCounter + "/" + instruction.Count * 2;
        instructionText.text = instructions[pageCounter];

    }


    public void NextPage()
    {
        expressions[pageCounter / 2].gameObject.SetActive(false);

        //page behaviour
        pageCounter++;
        int MAX_PAGE = (instruction.Count * 2);

        pageCounter = pageCounter >= MAX_PAGE ? MAX_PAGE : pageCounter;
        pageText.text = "Hoja " + pageCounter + "/" + (instruction.Count * 2);

        //instruction behaviour
        instructionText.text = instructions[pageCounter];

        //img
        int index = (pageCounter - 1) / 2;
        if(pageCounter % 2 != 0) { 
            expressions[index].gameObject.SetActive(true);
        }


    }

    public void PrevPage() 
    {
        expressions[(pageCounter - 1) / 2].gameObject.SetActive(false);

        //page behaviour
        pageCounter--;

        pageCounter = pageCounter <= 0 ? 0  : pageCounter;
        pageText.text = "Hoja " + pageCounter +  "/" + instruction.Count * 2;

        //instruction behaviour
        instructionText.text = instructions[pageCounter];

        //img
        if(pageCounter % 2 != 0)
        {
            expressions[(pageCounter - 1) / 2].gameObject.SetActive(true);
        }

    }

}
