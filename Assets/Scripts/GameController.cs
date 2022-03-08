using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Bot> Bots;
    public List<Bot> CorrectBots;
    public List<Column> Column;
    public List<Color> ColorColumn;

    Transform UnfixColumn;

    Color currentColorColumn;

    float timeColorChange = 2f;
    [SerializeField] private float currentTimeColorChange = 0f;

    private void Start()
    {
        currentTimeColorChange = timeColorChange;
        ColorColumn.Add(Color.red);
        ColorColumn.Add(Color.green);
        ColorColumn.Add(Color.blue);
    }

    private void Update()
    {
        if (CheckColorColumn()) currentTimeColorChange -= Time.deltaTime;
   

        if (currentTimeColorChange <= 0 && CheckColorColumn())
        {
            ChangeColor();
        }
        else if (currentTimeColorChange < 0) currentTimeColorChange = timeColorChange;

        if (CheckBotSkills() && !CheckColorColumn() && CheckBotNonActive())
        {
            Debug.Log("Start Bot");
            Debug.Log(CheckBotNonActive());
            StartBot();
        }
        if (Input.GetMouseButtonDown(0)) CheckBotSkills();

    }

    public void ChangeColor()
    {
        int randomIndexColor = Random.Range(0, ColorColumn.Count);
        int randomIndexColumn = Random.Range(0, Column.Count);

        Column[randomIndexColumn].currentColor = ColorColumn[randomIndexColor];
        currentTimeColorChange = timeColorChange;
    } 

    public bool CheckColorColumn()
    {
        for (int i = 0; i < Column.Count; i++)
        {
            if (Column[i].currentColor != Color.gray)
            {
                currentColorColumn = Column[i].currentColor;
                UnfixColumn = Column[i].transform;
                return false;
            }
            else currentColorColumn = Color.gray;
        }
        
        return true;
    }

    public bool CheckBotSkills()
    {
        CorrectBots.Clear();
        foreach (Bot bot in Bots)
        {
            foreach (Skill skill in bot.BotSkills)
            {
                switch (skill.ToString())
                {
                    case "ColorSkill":
                        {
                            ColorSkill colorSkill = (ColorSkill)skill;
                            if (colorSkill.color == currentColorColumn)
                            {
                                if(CorrectBots.Count < Bots.Count) CorrectBots.Add(bot);
                                return true;
                            }
                        }
                        break;
                }
            }
            
        }
        return false;

    }

    public bool CheckBotNonActive()
    {
        foreach (Bot bot in Bots)
        {
            if (bot.BotActive == true) return false;
        }
        return true;
    }

    void StartBot()
    {
        int randomIndexRorrectBot = Random.Range(0, CorrectBots.Count - 1);
        CorrectBots[randomIndexRorrectBot].ActivateBot(UnfixColumn.gameObject); 
    }
 }

