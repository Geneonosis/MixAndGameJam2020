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
        FindObjectOfType<DuckManager>().numArtillery--;
    }
}
