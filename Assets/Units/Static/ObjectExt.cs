public static class ObjectExt
{
    public static bool Equal(object a, object b)
    {
        if (a == null && b == null)
            return true;
        else if (a == null || b == null)
            return false;
        else
            return a.Equals(b);  // don't use == operator!
    }

    public static bool NotEqual(object a, object b)
    {
        return !Equal(a, b);
    }

    public static bool IsNull(object a)
    {
        return a == null;
    }

    public static bool IsNotNull(object a)
    {
        return a != null;
    }
}
