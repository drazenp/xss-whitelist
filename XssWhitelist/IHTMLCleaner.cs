using System.Xml.Linq;

namespace XssWhitelist
{
    public interface IHTMLCleaner
    {
        void Clean(XDocument xml);
    }
}