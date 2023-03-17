namespace SurveyRestApi.DataAccessLayer
{
    public static class Helper
    {

        public static int AsInt(this object o)
        {
            int i = 0;

            if (int.TryParse(o.ToString(), out i))
            {
                return i;
            }
            else return 0;
        }

        public static double AsDouble(this object o)
        {
            double i = 0d;

            if (double.TryParse(o.ToString(), out i))
            {
                return i;
            }
            else return 0d;
        }
    }
}
