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
        var hp = personnage.HealthPoints;
        Assert.Equal(100, hp);
    }
}