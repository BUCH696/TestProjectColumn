using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : AiBot
{
    public int countSkills; //Для визуала
    public float speedBot = 5f; 

    [Header("Скиллы:")] 
    // Для визуала
    // -->
    public bool ColorRed;
    public bool ColorGreen;
    public bool ColorBlue;
    public bool BotActive = false;
    // <--

    [Space]
    Vector3 startBotPosition;
    GameObject TargetColumn;

    private void Start()
    {
        startBotPosition = transform.position;
        countSkills = BotSkills.Count;

        if (ColorRed)
            BotSkills.Add(new ColorSkill(Color.red));

        if (ColorGreen)
            BotSkills.Add(new ColorSkill(Color.green));

        if (ColorBlue)
            BotSkills.Add(new ColorSkill(Color.blue)); 
    }

    private void Update()
    {
        if (BotActive)
        {
            MoveBotToColumn(TargetColumn.transform.position);
        }
        else
        {
            RemoveBotToStartPosition();
        }
    }

    public void MoveBotToColumn(Vector3 columnPosition)
    { 
        transform.position = Vector3.MoveTowards(transform.position, columnPosition, speedBot * Time.deltaTime);
    }

    public void RemoveBotToStartPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, startBotPosition, speedBot * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Column"))
        {
            collision.transform.GetComponent<Column>().FixColor();
            BotActive = false;
        }
    }

    public void ActivateBot(GameObject columnObj)
    {
        BotActive = true;
        TargetColumn = columnObj;
    }
}
