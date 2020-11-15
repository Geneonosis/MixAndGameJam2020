public class ArtilleryDuck : AdultDuck
{
    public override void Attack()
    {
        return;
    }

    public void OnEnable()
    {
        FindObjectOfType<DuckManager>().numArtillery++;
    }

    public void OnDestroy()
    {
        if (FindObjectOfType<DuckManager>())
            FindObjectOfType<DuckManager>().numArtillery--;
    }
}
