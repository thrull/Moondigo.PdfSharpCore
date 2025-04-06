using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf.IO.enums;
using System.IO;
using System.Reflection;
using Xunit;

namespace PdfSharpCore.Test.Signature
{
    public class PdfSignature
    {

        [Fact]
        public void DocumentWithValidSignature()
        {
            var root = Path.GetDirectoryName(GetType().GetTypeInfo().Assembly.Location);
            var existingPdfPath = Path.Combine(root, "Assets", "FamilyTreeSigned.pdf");

            var fs = File.OpenRead(existingPdfPath);
            PdfDocument inputDocument = Pdf.IO.PdfReader.Open(fs, PdfDocumentOpenMode.Import, PdfReadAccuracy.Strict);

            Assert.True(inputDocument.PageCount >= 1);

            Assert.True(inputDocument.IsSigned);

            fs.Dispose();

            Assert.True(true);
        }
    }
}

