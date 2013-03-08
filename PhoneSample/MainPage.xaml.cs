using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PhoneSample
{
    using System.Collections.ObjectModel;
    using System.Globalization;

    using NCldr.Extensions;

    public partial class MainPage : PhoneApplicationPage
    {
        // Because we don't have access to `CultureInfo.GetCultures`
        // This list is for Mango and from http://awkwardcoder.blogspot.co.uk/2011/09/supported-cultures-in-windows-phone-7.html
        private string[] cultureNames = {
    "af", "af-ZA", "sq", "sq-AL", "ar", "ar-DZ", "ar-IQ", "ar-JO",
    "ar-KW", "ar-LB", "ar-LY", "ar-MA", "ar-OM", "ar-QA", "ar-SA", "ar-SY",
    "ar-TN", "ar-AE", "ar-YE", "hy", "hy-AM", "az", "az-Cyrl-AZ", "az-Latn-AZ",
    "eu", "eu-ES", "be", "be-BY", "bg", "bg-BG", "ca", "ca-ES", "zh-HK", "zh-MO",
    "zh-CN", "zh-Hans", "zh-SG", "zh-TW", "zh-Hant", "hr", "hr-BA", "hr-HR", "cs",
    "cs-CZ", "da", "da-DK", "dv", "dv-MV", "nl", "nl-BE", "nl-NL", "en", "en-AU",
    "en-BZ", "en-CA", "en-029", "en-IE", "en-JM", "en-NZ", "en-ZA", "en-TT",
    "en-GB", "en-US", "en-ZW", "et", "et-EE", "fo", "fo-FO", "fa", "fa-IR", "fi",
    "fi-FI", "fr", "fr-BE", "fr-CA", "fr-FR", "fr-LU", "fr-MC", "fr-CH", "gl",
    "gl-ES", "ka", "ka-GE", "de", "de-AT", "de-DE", "de-DE_phoneb", "de-LI",
    "de-LU", "de-", "el", "el-GR", "gu", "gu-IN", "he", "he-IL", "hi", "hi-IN",
    "hu", "hu-HU", "is", "is-IS", "id", "id-ID", "it", "it-IT", "it-CH", "ja",
    "ja-JP", "kn", "kn-IN", "kk", "kk-KZ", "kok", "kok-IN", "ko", "ko-KR", "ky",
    "ky-KG", "lv", "lv-LV", "lt", "lt-LT", "mk", "mk-MK", "ms", "ms-BN", "ms-MY",
    "mr", "mr-IN", "mn", "mn-MN", "no", "nb-NO", "nn-NO", "pl", "pl-PL", "pt",
    "pt-BR", "pt-PT", "pa", "pa-IN", "ro", "ro-RO", "ru", "ru-RU", "sa", "sa-IN",
    "sr-Cyrl-CS", "sr-Latn-CS", "sk", "sk-SK", "sl", "sl-SI", "es", "es-AR",
    "es-BO", "es-CL", "es-CO", "es-CR", "es-DO", "es-EC", "es-SV", "es-GT", "es-HN",
    "es-MX", "es-NI", "es-PA", "es-PY", "es-PE", "es-PR", "es-ES", "es-ES_tradnl",
    "es-UY", "es-VE", "sw", "sw-KE", "sv", "sv-FI", "sv-SE", "syr", "syr-SY",
    "ta", "ta-IN", "tt", "tt-RU", "te", "te-IN", "th", "th-TH", "tr", "tr-TR", "uk",
    "uk-UA", "ur", "ur-PK", "uz", "uz-Cyrl-UZ", "uz-Latn-UZ", "vi", "vi-VN"
};

        public MainPage()
        {
            InitializeComponent();

            this.Loaded += this.MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var displayedOutput = new ObservableCollection<string>();
            this.output.ItemsSource = displayedOutput;

            NCldr.NCldrLoader.NCldrDataPath = "";
            NCldr.NCldr.NCldrData = NCldr.NCldrLoader.Load();

            foreach (var culture in this.cultureNames)
            {
                try
                {
                var ci = new CultureInfo(culture);

                if (!ci.IsNeutralCulture)
                {
                    displayedOutput.Add(string.Format("{0}, {1}", ci.Name, ci.GetPostcodeRegex()));
                }
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("EXCLUDE: " + culture);
                }
            }

            //displayedOutput.Add("gregre");
            //displayedOutput.Add("gregre");
            //displayedOutput.Add("gregre");
            //displayedOutput.Add("gregre");
            //displayedOutput.Add("gregre");
            //displayedOutput.Add("gregre");
        }
    }
}