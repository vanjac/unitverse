public static class ObjectExt
{
    public static bool IsNull(object a)
    {
        return a == null;
    }

    public static bool IsNotNull(object a)
    {
        return a != null;
    }
}
