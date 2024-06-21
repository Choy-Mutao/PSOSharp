namespace PSOSharp.Common
{
    public class NumberUtils
    {
        /// <summary>
        /// 比较 
        /// </summary>
        /// <param abstract_name="a"> a </param>
        /// <param abstract_name="b"> b </param>
        /// <param abstract_name="tol"></param>
        /// ； 如果 a < b, 返回 -1， 如果 a = b 返回 0， 如果 a > b 返回1
        /// <returns></returns>
        public static int CompValue(double a, double b, double tol = 1e-6)
        {
            if ((a - b) < -Math.Abs(tol))
                return -1; // a < b
            else if ((a - b) > Math.Abs(tol))
                return 1; // a > b
            else
                return 0; // a = b
        }
    }
}
