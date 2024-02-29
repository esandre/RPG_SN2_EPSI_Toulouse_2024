namespace RPG.Console;

public record PointsDeVie
{
    public static readonly PointsDeVie Zero = new (0);
    private static readonly PointsDeVie Un = new (1);

    private readonly uint _montant;

    internal PointsDeVie(uint pointsDeVie)
    {
        _montant = pointsDeVie;
    }

    public static PointsDeVie operator -(PointsDeVie a, PointsDeVie b)
    {
        return b._montant > a._montant 
            ? Zero 
            : new PointsDeVie(a._montant - b._montant);
    }

    public static PointsDeVie operator -(PointsDeVie pointsDeVie, uint montant)
    {
        return montant > pointsDeVie._montant 
            ? Zero 
            : new PointsDeVie(pointsDeVie._montant - montant);
    }

    public static implicit operator PointsDeVie(uint montant)
    {
        return new PointsDeVie(montant);
    }

    internal PointsDeVie Ressusciter()
    {
        if(_montant != 0) return this;
        return Un;
    }
}