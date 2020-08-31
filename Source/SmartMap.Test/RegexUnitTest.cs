using System.Text.RegularExpressions;
using SmartMap.Web.Util;
using Xunit;

namespace SmartMap.Test
{
    public class RegexUnitTest
    {
        [Theory]
        [InlineData("a:1:{i:0;s:2:\"20\";}", 20)]
        [InlineData("a:1:{i:0;s:3:\"256\";}", 256)]
        [InlineData("a:1:{i:0;s:3:\"127\";}", 127)]
        public void Test_regex_for_extracting_id_from_cms_string(string value, int expected)
        {
            Regex r = new Regex("(\\\".*?\\\")");
            var idString = r.Match(value).Value.Replace("\"", "");
            int.TryParse(idString, out int id);

            Assert.Equal(expected, id);
        }

        [Theory]
        [InlineData("a:1:{i:0;s:2:\"20\";}", 20)]
        [InlineData("a:1:{i:0;s:3:\"256\";}", 256)]
        [InlineData("a:1:{i:0;s:3:\"127\";}", 127)]
        public void Test_method_for_extracting_id_from_cms_string(string value, int expected)
        {
            var id = StringHelper.ReturnId(value);

            Assert.Equal(expected, id);
        }

        //[Theory]
        //[InlineData("website", "a:3:{s:5:\"title\";s:0:\"\";s:3:\"url\";s:26:\"https://apparkingspot.com/\";s:6:\"target\";s:0:\"\";}", "https://apparkingspot.com/")]
        //[InlineData("website", "a:3:{s:5:\"title\";s:0:\"\";s:3:\"url\";s:280:\"https://goteborg.se/wps/portal/enhetskatalogen/!ut/p/z1/hYtLDoIwFEXXwtTJe7U_psVBlZqoASLthKA2pokiUVIjqxcWYLyjc3_goAbXtTFc2yE8uvY2eetEsyf5Ic2Iwp0mKW5KFIqtDdEFheO_gZtq_CGFYKe_bNhSI8kZManIJKqtWVFhZJVVHApw4MIFLKecz_zyzxjOfvj0HuxiTmLw7xn7ez2W_jQqlSRfuDIceA!!/dz/d5/L2dBISEvZ0FBIS9nQSEh/\";s:6:\"target\";s:0:\"\";}", "https://goteborg.se/wps/portal/enhetskatalogen/!ut/p/z1/hYtLDoIwFEXXwtTJe7U_psVBlZqoASLthKA2pokiUVIjqxcWYLyjc3_goAbXtTFc2yE8uvY2eetEsyf5Ic2Iwp0mKW5KFIqtDdEFheO_gZtq_CGFYKe_bNhSI8kZManIJKqtWVFhZJVVHApw4MIFLKecz_zyzxjOfvj0HuxiTmLw7xn7ez2W_jQqlSRfuDIceA!!/dz/d5/L2dBISEvZ0FBIS9nQSEh/")]
        //[InlineData("website", "a:3:{s:5:\"title\";s:0:\"\";s:3:\"url\";s:20:\"http://bagarbil.com/\";s:6:\"target\";s:0:\"\";}", "http://bagarbil.com/")]
        //[InlineData("facebook", "a:3:{s:5:\"title\";s:0:\"\";s:3:\"url\";s:56:\"https://www.facebook.com/groups/659539954080345/?fref=ts\";s:6:\"target\";s:0:\"\";}", "https://www.facebook.com/groups/659539954080345/?fref=ts")]
        //[InlineData("facebook", "a:3:{s:5:\"title\";s:0:\"\";s:3:\"url\";s:48:\"https://www.facebook.com/groups/153296841451958/\";s:6:\"target\";s:0:\"\";}", "https://www.facebook.com/groups/153296841451958/")]
        //public void Test_method_for_extracting_url_from_weird_wordpress_format(string type, string url, string expected)
        //{
        //    var urlValue = BusinessFileGenerator.GetUrlFromWpString(url, type);

        //    Assert.Equal(expected, urlValue);
        //}

        [Theory]
        [InlineData(851971890, "08-51971890")]
        [InlineData(738130041, "0738-130041")]
        [InlineData(40341000, "040-341000")]
        [InlineData(104980000, "010-4980000")]
        [InlineData(313689696, "031-3689696")]
        [InlineData(31254811, "031-254811")]
        public void Test_method_for_formatting_phonenumbers(int value, string expected)
        {
            var phone = StringHelper.FormatPhone(value);

            Assert.Equal(expected, phone);
        }
    }
}