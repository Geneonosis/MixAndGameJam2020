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
        FindObjectOfType<DuckManager>().numMages--;
    }
}
