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

    [Theory(DisplayName = "Recevoir des dégâts diminue la vie")]
    [InlineData(0U)]
    [InlineData(1U)]
    [InlineData(2U)]
    [InlineData(Personnage.PointsDeVieMax)]
    [InlineData(1U, 1U)]
    public void RecevoirDegatsDiminueLaVie(params uint[] dégâtsInfligés)
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();
        var hpInitiaux = personnage.PointsDeVie;

        // QUAND il reçoit des dégâts
        foreach (var dégâtInfligé in dégâtsInfligés)
            personnage.RecevoirDégâts(dégâtInfligé);

        // ALORS ses HP diminuent de la somme de ces dégâts
        var hpFinaux = personnage.PointsDeVie;
        var différence = hpInitiaux - hpFinaux;
        Assert.Equal(dégâtsInfligés.Sum(), différence);
    }

    [Fact]
    public void RecevoirPlusDeDégâtsQueLaVie()
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();

        // QUAND il reçoit plus de dégâts que ses points de vie
        personnage.RecevoirDégâts(Personnage.PointsDeVieMax + 1);

        // ALORS ses HP tombent à zéro
        var hpFinaux = personnage.PointsDeVie;
        Assert.Equal(0U, hpFinaux);
    }

    [Fact]
    public void RecevoirPlusDeDégâtsQueLaVieEn2Fois()
    {
        // ETANT DONNE un Personnage
        var personnage = new Personnage();

        // QUAND il reçoit plus de dégâts que ses points de vie
        personnage.RecevoirDégâts(Personnage.PointsDeVieMax);
        personnage.RecevoirDégâts(1);

        // ALORS ses HP tombent à zéro
        var hpFinaux = personnage.PointsDeVie;
        Assert.Equal(0U, hpFinaux);
    }
}