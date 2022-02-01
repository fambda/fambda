namespace Fambda.DataTypes
{
    public static class Log
    {
        private static string _holder = null;

        public static void Init()
        {
            _holder = null;
        }

        public static void Message(string message)
        {
            _holder = message;
        }

        public static string Read()
        {
            return _holder;
        }
    }
}
