public static class BooleanExt
{
    public static bool Not(bool a)
    {
        return !a;
    }

    public static bool And(bool a, bool b)
    {
        return a && b;
    }

    public static bool Or(bool a, bool b)
    {
        return a || b;
    }

    public static bool Xor(bool a, bool b)
    {
        return a ^ b;
    }

    public static bool Nand(bool a, bool b)
    {
        return !(a && b);
    }

    public static bool Nor(bool a, bool b)
    {
        return !(a || b);
    }

    public static bool Xnor(bool a, bool b)
    {
        return !(a ^ b);
    }
}
