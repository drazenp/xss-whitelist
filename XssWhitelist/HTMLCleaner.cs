using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XssWhitelist
{
    public class HTMLCleaner : IHTMLCleaner
    {
        private HashSet<string> _allowedNodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "h1", "div" };

        public void Clean(XDocument xml)
        {
            xml.Root.Descendants().Where(x => !_allowedNodes.Contains(x.Name.LocalName)).Remove();
        }
    }
}
