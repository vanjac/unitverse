using UnityEngine;

// https://developer.valvesoftware.com/wiki/Filter_base
public abstract class Filter : Unit
{
    public UltEvents.UltEvent<GameObject> pass, fail;
    public bool searchParents;
    public bool inverse;

    protected abstract bool MatchImpl(GameObject gameObject);

    public bool Matches(GameObject gameObject)
    {
        bool foundMatch;
        if (searchParents)
        {
            Transform t = gameObject.transform;
            do
            {
                foundMatch = MatchImpl(t.gameObject);
                t = t.parent;
            }
            while (!foundMatch && t != null);
        }
        else
        {
            foundMatch = MatchImpl(gameObject);
        }

        return inverse ? !foundMatch : foundMatch;
    }

    public bool Matches(Component component)
    {
        return Matches(component.gameObject);
    }

    public void Test(GameObject gameObject)
    {
        bool match = Matches(gameObject);
        if (match && pass != null)
            pass.Invoke(gameObject);
        else if (!match && fail != null)
            fail.Invoke(gameObject);
    }

    public void Test(Component component)
    {
        Test(component.gameObject);
    }
}
