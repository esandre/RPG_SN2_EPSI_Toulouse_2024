namespace RPG.Console;

public class Personnage
{
    public int PointsDeVie { get; private set; } = 100;

    public void Tuer()
    {
        PointsDeVie = 0;
    }
}