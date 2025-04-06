using PdfSharpCore.Pdf.Internal;
using PdfSharpCore.Pdf.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;

namespace PdfSharpCore.Pdf.Signature
{
    internal class PdfSignatureValidator
    {
        public static void AddAndValidateSignature(PdfDictionary dict, PdfDocument document, Parser parser)
        {
            // Check if the signature is valid
            if (dict.Elements.ContainsKey("/Contents"))
            {
                PdfString contents = dict.Elements["/Contents"] as PdfString;
                if (contents != null)
                {
                    byte[] pkcs7Bytes = PdfEncoders.RawEncoding.GetBytes(contents.Value);
                    PdfArray byteRange = dict.Elements["/ByteRange"] as PdfArray;

                    Debug.Assert(byteRange.Elements.Count % 4 == 0);

                    if (byteRange == null || byteRange.Elements.Count % 4 != 0)
                    {
                        throw new PdfReaderException("Invalid byte range in signature.");
                    }

                    int start1 = byteRange.Elements.GetInteger(0);
                    int length1 = byteRange.Elements.GetInteger(1);
                    int start2 = byteRange.Elements.GetInteger(2);
                    int length2 = byteRange.Elements.GetInteger(3);

                    byte[] signedData = parser.ReadSignedData(start1, length1, start2, length2);

                    var signedCms = new SignedCms(new ContentInfo(signedData), detached: true);
                    signedCms.Decode(pkcs7Bytes);

                    PdfSignature pdfSignature = new PdfSignature(signedCms.SignerInfos);
                    document.AddSignature(pdfSignature);

                    try
                    {
                        signedCms.CheckSignature(true);

                        pdfSignature.IsValid = true;
                    }
                    catch (CryptographicException)
                    {
                        //throw new PdfReaderException("The PDF Document is signed but the signature is not valid");
                    }
                }
            }
       }
    }
}
