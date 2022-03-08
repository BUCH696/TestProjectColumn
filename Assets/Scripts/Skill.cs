using UnityEngine;

public abstract class Skill
{

}

public class ColorSkill : Skill
{
    public Color color;

    public ColorSkill(Color color)
    {
        this.color = color;
    }
}

public class ColorAndSize : ColorSkill
{
    public int size;

    public ColorAndSize(Color color, int size) : base(color)
    {
        this.size = size;
    }
}
