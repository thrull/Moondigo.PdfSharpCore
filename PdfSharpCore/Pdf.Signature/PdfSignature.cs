using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;


namespace PdfSharpCore.Pdf.Signature
{
    public class PdfSignature
    {
        public X509Certificate2Collection Certificates;

        private bool isValid = false;

        public PdfSignature(SignerInfoCollection signerInfos)
        {
            Certificates = new X509Certificate2Collection();

            foreach (SignerInfo signer in signerInfos)
            {
                Certificates.Add(signer.Certificate);
            }
        }

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }
    }
}
