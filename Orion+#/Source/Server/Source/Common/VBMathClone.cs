using Microsoft.VisualBasic.CompilerServices;
using System;

public sealed partial class VBMathClone
{
    private static int[] Power2;
    private static int m_rndSeed;

    static VBMathClone()
    {
        var numArray = new[] { 0, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, 1073741824 };
        Power2 = numArray;
    }

    private static float GetTimer()
    {
        var now = DateTime.Now;
        return Conversions.ToSingle(Conversions.ToDouble((60 * now.Hour + now.Minute) * 60 + now.Second) + Conversions.ToDouble(now.Millisecond) / (1000));
    }

    public static void Randomize()
    {
        float timer = GetTimer();
        int mRndSeed = m_rndSeed;
        int num = BitConverter.ToInt32(BitConverter.GetBytes(timer), 0);
        num = ShiftLeft(num & 65535 ^ ShiftRight(num, 16), 8);
        m_rndSeed = mRndSeed & -16776961 | num;
    }

    public static void Randomize(double Number)
    {
        int num;
        int mRndSeed = m_rndSeed;
        num = !BitConverter.IsLittleEndian ? BitConverter.ToInt32(BitConverter.GetBytes(Number), 0) : BitConverter.ToInt32(BitConverter.GetBytes(Number), 4);
        num = ShiftLeft(num & 65535 ^ ShiftRight(num, 16), 8);
        mRndSeed = mRndSeed & -16776961 | num;
        m_rndSeed = mRndSeed;
    }

    public static float Rnd()
    {
        return Rnd(1.0F);
    }

    public static float Rnd(float Number)
    {
        int mRndSeed = m_rndSeed;
        if (Conversions.ToDouble(Number) != (0))
        {
            if (Conversions.ToDouble(Number) < (0))
            {
                mRndSeed = BitConverter.ToInt32(BitConverter.GetBytes(Number), 0);
                long num = Conversions.ToLong(mRndSeed);
                num = num & 4294967295L;
                mRndSeed = Conversions.ToInteger(Conversions.ToLong((num) + (num) / (double)16777216L) & 16777215L);
            }
            mRndSeed = Conversions.ToInteger(Conversions.ToLong(mRndSeed) * 1140671485L + 12820163L & 16777215L);
        }
        m_rndSeed = mRndSeed;
        return Conversions.ToSingle(mRndSeed) / 16777216.0F;
    }

    private static int ShiftLeft(int value, int shift)
    {
        long power2 = Conversions.ToLong(value);
        power2 = power2 * Conversions.ToLong(Power2[shift]);
        power2 = power2 & 4294967295L;
        if ((power2 & 2147483648L) != 0L)
            power2 = power2 | -4294967296L;
        return Conversions.ToInteger(power2);
    }

    private static int ShiftRight(int value, int shift)
    {
        long power2 = Conversions.ToLong(value & 2147483647);
        if (((value) & -2147483648) != (0))
            power2 = power2 | 2147483648L;
        power2 = Conversions.ToLong((power2) / (double)Conversions.ToLong(Power2[shift]));
        return Conversions.ToInteger(power2);
    }
}
