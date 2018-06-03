namespace Lands.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    public class Settings
    {
        static ISettings AppSettings 
        {                            
            get                      
            {                        
                return CrossSettings.Current;    
            }

        }                      

        const string tokenId = "TokenId";

        const string tokenTypeId = "TokenTypeId";

        static readonly string stringDefault = string.Empty;

        public static string TokenId   
        {                            
            get                      
            {

                return AppSettings.GetValueOrDefault(tokenId, stringDefault);

            }                        
            set                      
            {

                AppSettings.AddOrUpdateValue(tokenId, value);

            }

        }                            
        public static string TokenTypeId
        { 
            get
            {

                return AppSettings.GetValueOrDefault(tokenTypeId, stringDefault);

            }  
            set 
            {

                AppSettings.AddOrUpdateValue(tokenTypeId, value);

            }

        }
    }
}
