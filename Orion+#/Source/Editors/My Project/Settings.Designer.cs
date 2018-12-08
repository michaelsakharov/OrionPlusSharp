namespace Engine
{
    namespace My
    {
        internal sealed partial class MySettings : global::System.Configuration.ApplicationSettingsBase
        {
            private static MySettings defaultInstance = (MySettings)global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySettings());
            
            private static bool addedHandler;

            private static object addedHandlerLockObject = new object();
            
            private static void AutoSaveSettings(global::System.Object sender, global::System.EventArgs e)
            {
            //    if (My.MyProject.Application.SaveMySettingsOnExit)
            //        My.MySettingsProperty.Settings.Save();
            }
            public static MySettings Default
            {
                get
                {
                    
                    if (!addedHandler)
                    {
                        lock (addedHandlerLockObject)
                        {
                            if (!addedHandler)
                            {
                            //    My.MyProject.Application.Shutdown += AutoSaveSettings;
                                addedHandler = true;
                            }
                        }
                    }
                    return defaultInstance;
                }
            }
        }
    }

    namespace My
    {
        internal static class MySettingsProperty
        {
            internal static global::Engine.My.MySettings Settings
            {
                get
                {
                    return global::Engine.My.MySettings.Default;
                }
            }
        }
    }
}
