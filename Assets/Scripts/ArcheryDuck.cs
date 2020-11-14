public class ArcheryDuck : AdultDuck
{
    public override void Attack()
    {
        // need the definition on how this player attacks? Ranges? etc? damages? arch visibility? etc.
    }

    public void OnEnable()
    {
        FindObjectOfType<DuckManager>().numArchers++;
    }

    public void OnDestroy()
    {
        FindObjectOfType<DuckManager>().numArchers--;
    }
}
