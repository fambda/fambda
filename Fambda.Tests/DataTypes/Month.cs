namespace Fambda.Tests.DataTypes
{
    public class Month : Enumeration
    {
        public static readonly Month January = new Month("#month_jan");
        public static readonly Month February = new Month("#month_feb");
        public static readonly Month March = new Month("#month_mar");
        public static readonly Month April = new Month("#month_apr");
        public static readonly Month May = new Month("#month_may");
        public static readonly Month June = new Month("#month_jun");
        public static readonly Month July = new Month("#month_jul");
        public static readonly Month August = new Month("#month_aug");
        public static readonly Month September = new Month("#month_sep");
        public static readonly Month October = new Month("#month_oct");
        public static readonly Month November = new Month("#month_nov");
        public static readonly Month December = new Month("#month_dec");

        public Month(string key) : base(key) { }
    }
}
