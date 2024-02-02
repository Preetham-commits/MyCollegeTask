using MyCollegeTask.Debugging;

namespace MyCollegeTask
{
    public class MyCollegeTaskConsts
    {
        public const string LocalizationSourceName = "MyCollegeTask";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "bf6162a3cc714535a3561bb8c1db8bc0";
    }
}
