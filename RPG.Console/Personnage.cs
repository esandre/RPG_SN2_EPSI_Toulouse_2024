namespace RPG.Console;

public class Personnage
{
    public int PointsDeVie { get; private set; } = 100;

    public void Tuer()
    {
        PointsDeVie = 0;
    }

    public void Ressusciter()
    {
        if (PointsDeVie != 0) return;
        PointsDeVie = 1;
    }

    public void RecevoirDégâts(int dégâtsInfligés)
    {
    }
}