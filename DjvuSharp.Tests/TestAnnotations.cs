using NUnit.Framework;

namespace DjvuSharp.Tests
{
    public class TestAnnotations
    {
        private Annotation _annotation;

        [OneTimeSetUp]
        public void SetUp()
        {
            DjvuDocument document = DjvuDocument.Create(@"../../../assets/DjVu3Spec.djvu");

            _annotation = new DjvuPage(document, 5).GetAnnotations();
        }
    }
}
