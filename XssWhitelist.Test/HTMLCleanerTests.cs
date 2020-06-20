using NUnit.Framework;
using XssWhitelist;
using System.Linq;
using System.Xml.Linq;

namespace XssWhitelist.Test
{
    public class HTMLCleanerTests
    {
        [Test]
        public void Clean_EmptyDocument_Pass()
        {
            // Arrange
            var document = new XDocument();

            // Act
            new HTMLCleaner().Clean(document);

            // Assert
            Assert.That(document.Descendants().Any(), Is.False);
        }
    }
}