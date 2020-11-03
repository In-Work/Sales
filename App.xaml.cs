using System.Windows;

namespace Sales
{
    public partial class App : Application
    {
        public static EF.dbContext db = new EF.dbContext();
        public static Entities.User user;
    }
}
