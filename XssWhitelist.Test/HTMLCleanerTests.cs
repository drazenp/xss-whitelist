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
            var document = XDocument.Parse("<div></div>");

            // Act
            new HTMLCleaner().Clean(document);

            // Assert
            Assert.That(document.Root.ToString(), Is.EqualTo("<div></div>"));
        }

        [Test]
        public void Clean_DocumentWithOnlyText_DoesNotChange()
        {
            // Arrange
            var document = XDocument.Parse("<div>test</div>");

            // Act
            new HTMLCleaner().Clean(document);

            // Assert
            Assert.That(document.Root.ToString(), Is.EqualTo("<div>test</div>"));
        }

        [Test]
        public void Clean_WithNotAllowedTag_RemovesNotAllowedTag()
        {
            // Arrange
            var document = XDocument.Parse("<div><test></test></div>");

            // Act
            new HTMLCleaner().Clean(document);

            // Assert
            Assert.That(document.Root.ToString(), Is.EqualTo("<div />"));
        }

        [Test]
        public void Clean_WithNestedNotAllowedTag_RemovesNotAllowedTags()
        {
            // Arrange
            var document = XDocument.Parse("<div><test><test></test></test></div>");

            // Act
            new HTMLCleaner().Clean(document);

            // Assert
            Assert.That(document.Root.ToString(), Is.EqualTo("<div />"));
        }

        [Test]
        public void Clean_WithNestedAllowedTagInsideNotAllowed_RemovesNotAllowedTagAndSubTags()
        {
            // Arrange
            var document = XDocument.Parse("<div><test><div></div></test></div>");

            // Act
            new HTMLCleaner().Clean(document);

            // Assert
            Assert.That(document.Root.ToString(), Is.EqualTo("<div />"));
        }
    }
}