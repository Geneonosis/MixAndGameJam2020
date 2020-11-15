public class MageDuck : AdultDuck
{
    public override void Attack()
    {
        return;
    }

    public void OnEnable()
    {
        FindObjectOfType<DuckManager>().numMages++;
    }

    public void OnDestroy()
    {
        if (FindObjectOfType<DuckManager>())
            FindObjectOfType<DuckManager>().numMages--;
    }
}
