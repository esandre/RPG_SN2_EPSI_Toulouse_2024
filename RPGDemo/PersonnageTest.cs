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

    [Fact]
    public void RessusciterSansTuerNeChangeRien()
    {
        // ETANT DONNE un Personnage vivant
        var personnage = new Personnage();
        var hpInitiaux = personnage.PointsDeVie;

        // QUAND on le ressuscite
        personnage.Ressusciter();

        // ALORS ses HP ne changent pas
        var hpFinaux = personnage.PointsDeVie;
        Assert.Equal(hpInitiaux, hpFinaux);
    }

    [Fact(DisplayName = "Recevoir des d�g�ts diminue la vie")]
    public void RecevoirDegatsDiminueLaVie()
    {
        // ETANT DONNE un Personnage
        const int d�g�tsInflig�s = 1;
        var personnage = new Personnage();
        var hpInitiaux = personnage.PointsDeVie;

        // QUAND il re�oit un d�g�t
        personnage.RecevoirD�g�ts(d�g�tsInflig�s);

        // ALORS ses HP diminuent de 1
        var hpFinaux = personnage.PointsDeVie;
        var diff�rence = hpInitiaux - hpFinaux;
        Assert.Equal(d�g�tsInflig�s, diff�rence);
    }
}