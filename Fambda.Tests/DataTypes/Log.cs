namespace Fambda.DataTypes
{
    public static class Log
    {
        private static string _holder = string.Empty;

        public static void Init()
        {
            _holder = string.Empty;
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
