using RPG.Console;
using RPG.Test.Utilities;

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
        Assert.Equal(100U, hp);
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
        Assert.Equal(0U, hp);
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
        Assert.Equal(1U, hp);
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

    [Theory(DisplayName = "Recevoir des d�g�ts diminue la vie")]
    [InlineData(0U)]
    [InlineData(1U)]
    [InlineData(2U)]
    [InlineData(Personnage.PointsDeVieMax)]
    [InlineData(1U, 1U)]
    public void RecevoirDegatsDiminueLaVie(params uint[] d�g�tsInflig�s)
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();
        var hpInitiaux = personnage.PointsDeVie;

        // QUAND il re�oit des d�g�ts
        foreach (var d�g�tInflig� in d�g�tsInflig�s)
            personnage.RecevoirD�g�ts(d�g�tInflig�);

        // ALORS ses HP diminuent de la somme de ces d�g�ts
        var hpFinaux = personnage.PointsDeVie;
        var diff�rence = hpInitiaux - hpFinaux;
        Assert.Equal(d�g�tsInflig�s.Sum(), diff�rence);
    }

    [Fact]
    public void RecevoirPlusDeD�g�tsQueLaVie()
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();

        // QUAND il re�oit plus de d�g�ts que ses points de vie
        personnage.RecevoirD�g�ts(Personnage.PointsDeVieMax + 1);

        // ALORS ses HP tombent � z�ro
        var hpFinaux = personnage.PointsDeVie;
        Assert.Equal(0U, hpFinaux);
    }

    [Fact]
    public void RecevoirPlusDeD�g�tsQueLaVieEn2Fois()
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();

        // QUAND il re�oit plus de d�g�ts que ses points de vie
        personnage.RecevoirD�g�ts(Personnage.PointsDeVieMax);
        personnage.RecevoirD�g�ts(1);

        // ALORS ses HP tombent � z�ro
        var hpFinaux = personnage.PointsDeVie;
        Assert.Equal(0U, hpFinaux);
    }
}