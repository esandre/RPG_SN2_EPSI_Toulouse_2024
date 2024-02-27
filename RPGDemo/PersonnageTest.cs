using RPG.Console;

namespace RPG.Test;

public class PersonnageTest
{
    [Fact]
    public void HpInitiaux()
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();

        // ALORS il a 100 HP
        var hp = personnage.PointsDeVie;
        Assert.Equal(100, hp);
    }

    [Fact]
    public void TuerAmeneLesHpAZero()
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();

        // QUAND on le tue
        personnage.Tuer();

        // ALORS il a 0 HP
        var hp = personnage.PointsDeVie;
        Assert.Equal(0, hp);
    }

    [Fact]
    public void RessusciterAmeneLesHpAUn()
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();

        // QUAND on le tue puis on le ressuscite
        personnage.Tuer();
        personnage.Ressusciter();

        // ALORS il a 1 HP
        var hp = personnage.PointsDeVie;
        Assert.Equal(1, hp);
    }
}