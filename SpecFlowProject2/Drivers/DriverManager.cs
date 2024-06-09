using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class DriverManager
{
    private static IWebDriver driver;
    private static ChromeOptions options;

    public static IWebDriver GetDriver()
    {
        
        if (driver == null)
        {   
            SetDriverOptions();
            driver = new ChromeDriver(options);
        }

        return driver;
    }

    private static void SetDriverOptions()
    {
        if (options == null) {

            options = new ChromeOptions();    
        }

        // options.AddArguments("--headless"); //Runs test headless
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("autofill.profile_enabled", false);
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-save-password");
        options.AddUserProfilePreference("download.default_directory", Environment.CurrentDirectory);
        options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
        options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
        options.AddArgument("--start-maximized");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--ignore-ssl-errors");
        options.AcceptInsecureCertificates = true;
        options.AddUserProfilePreference("disable-popup-blocking", "true");
    }
}
