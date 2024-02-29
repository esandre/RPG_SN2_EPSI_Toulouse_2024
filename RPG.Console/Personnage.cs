namespace RPG.Console;

public class Personnage
{
    public const uint PointsDeVieMax = 100U;

    public PointsDeVie PointsDeVie { get; private set; }

    public Personnage()
    {
        PointsDeVie = new PointsDeVie(PointsDeVieMax);
    }

    public void Tuer()
    {
        PointsDeVie = PointsDeVie.Zero;
    }

    public void Ressusciter()
    {
        PointsDeVie = PointsDeVie.Ressusciter();
    }

    public void RecevoirDégâts(uint dégâtsInfligés)
    {
        PointsDeVie -= dégâtsInfligés;
    }
}