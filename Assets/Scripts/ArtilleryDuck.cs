public class ArtilleryDuck : AdultDuck
{
    public override void Attack()
    {
        return;
    }

    public void OnEnable()
    {
        if (FindObjectOfType<DuckManager>() is DuckManager dm)
            dm.numArtillery++;
    }

    public void OnDestroy()
    {
        if (FindObjectOfType<DuckManager>() is DuckManager dm)
            dm.numArtillery--;
    }
}
