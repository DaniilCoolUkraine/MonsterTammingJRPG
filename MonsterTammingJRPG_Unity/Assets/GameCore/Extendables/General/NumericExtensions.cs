namespace Jrpg.GameCore.Extendables.General
{
    public static class NumericExtensions
    {
        public static float RoundToNumbersAfterDot(this float num, int numbersAfterDot)
        {
            int multiplier = 10 * numbersAfterDot;
            int modifiedNum = (int)(multiplier * num);
            float result = modifiedNum / (float) multiplier;

            return result;
        }
    }
}