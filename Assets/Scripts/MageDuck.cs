public class MageDuck : AdultDuck
{
    public override void Attack()
    {
        return;
    }

    public void OnEnable()
    {
        if (FindObjectOfType<DuckManager>() is DuckManager dm)
            dm.numMages++;
    }

    public void OnDestroy()
    {
        if (FindObjectOfType<DuckManager>() is DuckManager dm)
            dm.numMages--;
    }
}
