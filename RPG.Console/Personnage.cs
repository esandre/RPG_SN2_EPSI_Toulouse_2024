namespace RPG.Console;

public class Personnage
{
    public const uint PointsDeVieMax = 100U;

    public uint PointsDeVie { get; private set; } = PointsDeVieMax;

    public void Tuer()
    {
        PointsDeVie = 0;
    }

    public void Ressusciter()
    {
        if (PointsDeVie != 0) return;
        PointsDeVie = 1;
    }

    public void RecevoirDégâts(uint dégâtsInfligés)
    {
        if (dégâtsInfligés > PointsDeVie) dégâtsInfligés = PointsDeVie;
        PointsDeVie -= dégâtsInfligés;
    }
}