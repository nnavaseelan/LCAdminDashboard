using System;
using CERTENROLLLib;
using CERTCLILib;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Security.Cryptography;

namespace CACertificate
{
    public class CertificateGenerator:IDisposable
    {
        private const int CC_DEFAULTCONFIG = 0;
        private const int CC_UIPICKCONFIG = 0x1;
        private const int CR_IN_BASE64 = 0x1;
        private const int CR_IN_FORMATANY = 0;
        private const int CR_IN_PKCS10 = 0x100;
        private const int CR_DISP_ISSUED = 0x3;
        private const int CR_DISP_UNDER_SUBMISSION = 0x5;
        private const int CR_OUT_BASE64 = 0x1;
        private const int CR_OUT_CHAIN = 0x100;

        public string CreateCertRequestMessage(string objectId, string subjectName)
        {
            var objCSPs = new CCspInformations();
            objCSPs.AddAvailableCsps();

            var objPrivateKey = new CX509PrivateKey();

            //Length: The key length of the private key.Normally the key length should NOT less than 1024 for security consideration.
            //Key Spec: Define how this key pair, and the certificate will be used. For example digital signature or key exchange.
            //Key Usage: The key usage value will be upgrade based on the Key Spec we defined.
            //Machine Context: Specify whether the certificate will be used for current user and machine.
            //Export Policy: Specify whether the private key can be exported or not from this machine.
            //CSP Information: The valid CSPs for this key pair.

            objPrivateKey.Length = 2048;
            objPrivateKey.KeySpec = X509KeySpec.XCN_AT_SIGNATURE;
            objPrivateKey.KeyUsage = X509PrivateKeyUsageFlags.XCN_NCRYPT_ALLOW_ALL_USAGES;
            objPrivateKey.MachineContext = false;
            objPrivateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_EXPORT_FLAG;
            objPrivateKey.CspInformations = objCSPs;
            objPrivateKey.Create();

            var objPkcs10 = new CX509CertificateRequestPkcs10();
            objPkcs10.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextUser,
                  objPrivateKey,
                  string.Empty);

            var objExtensionKeyUsage = new CX509ExtensionKeyUsage();
            objExtensionKeyUsage.InitializeEncode(
                   CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_DIGITAL_SIGNATURE_KEY_USAGE |
                 CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_NON_REPUDIATION_KEY_USAGE |
                   CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_KEY_ENCIPHERMENT_KEY_USAGE |
                  CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_DATA_ENCIPHERMENT_KEY_USAGE);
            objPkcs10.X509Extensions.Add((CX509Extension)objExtensionKeyUsage);

            var objObjectId = new CObjectId();
            var objObjectIds = new CObjectIds();
            var objX509ExtensionEnhancedKeyUsage = new CX509ExtensionEnhancedKeyUsage();
            
            //identity named Object ID (OID)
            //all extensions in certificate will be defined by an identity named Object ID (OID).
            //Here I added “Client Authentication” enhanced key usage extension to the certificate by specifying its OID “1.3.6.1.5.5.7.3.2”.

            //objObjectId.InitializeFromValue("1.3.6.1.5.5.7.3.2");
            objObjectId.InitializeFromValue(objectId);

            objObjectIds.Add(objObjectId);
            objX509ExtensionEnhancedKeyUsage.InitializeEncode(objObjectIds);
            objPkcs10.X509Extensions.Add((CX509Extension)objX509ExtensionEnhancedKeyUsage);

            var objDN = new CX500DistinguishedName();
                       
            //CN:Common Name
            //C: Country(Must be 2 letter.)
            //S: State
            //L: Locality
            //O: Organization
            //OU:Organization Unit
            //E: Email
            //subjectName = "CN = seucredP@yment, OU = secUreADCS, O = mBrain, L = SriL@nKan, S = R@g@ma, C = SL, E = navaseelan4u@gmail.com";

            objDN.Encode(subjectName, X500NameFlags.XCN_CERT_NAME_STR_NONE);
            objPkcs10.Subject = objDN;
           
            var objEnroll = new CX509Enrollment();
            objEnroll.InitializeFromRequest(objPkcs10);
            var strRequest = objEnroll.CreateRequest(EncodingType.XCN_CRYPT_STRING_BASE64);
            
            return strRequest;


        }

        public string CreateCertRequestMessage(string AccessToken, string ClientId,
            string UserName, string EmailId, string DeviceId, string PlatForm, string UserNIC, string PassportNo,
            string MobileNo, string Bank, string objectId, string subjectName)
        {
            var objCSPs = new CCspInformations();
            objCSPs.AddAvailableCsps();

            var objPrivateKey = new CX509PrivateKey();

            //Length: The key length of the private key.Normally the key length should NOT less than 1024 for security consideration.
            //Key Spec: Define how this key pair, and the certificate will be used. For example digital signature or key exchange.
            //Key Usage: The key usage value will be upgrade based on the Key Spec we defined.
            //Machine Context: Specify whether the certificate will be used for current user and machine.
            //Export Policy: Specify whether the private key can be exported or not from this machine.
            //CSP Information: The valid CSPs for this key pair.

            objPrivateKey.Length = 2048;
            objPrivateKey.KeySpec = X509KeySpec.XCN_AT_SIGNATURE;
            objPrivateKey.KeyUsage = X509PrivateKeyUsageFlags.XCN_NCRYPT_ALLOW_ALL_USAGES;
            objPrivateKey.MachineContext = false;
            objPrivateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_EXPORT_FLAG;
            objPrivateKey.CspInformations = objCSPs;
            objPrivateKey.Create();

            var objPkcs10 = new CX509CertificateRequestPkcs10();
            objPkcs10.InitializeFromPrivateKey(
                 X509CertificateEnrollmentContext.ContextUser,
                  objPrivateKey,
                  string.Empty);

            var objExtensionKeyUsage = new CX509ExtensionKeyUsage();
            objExtensionKeyUsage.InitializeEncode(
                   CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_DIGITAL_SIGNATURE_KEY_USAGE |
                 CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_NON_REPUDIATION_KEY_USAGE |
                   CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_KEY_ENCIPHERMENT_KEY_USAGE |
                  CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_DATA_ENCIPHERMENT_KEY_USAGE);
            objPkcs10.X509Extensions.Add((CX509Extension)objExtensionKeyUsage);

            var objObjectId = new CObjectId();
            var objObjectIds = new CObjectIds();
            var objX509ExtensionEnhancedKeyUsage = new CX509ExtensionEnhancedKeyUsage();


            //identity named Object ID (OID)
            //all extensions in certificate will be defined by an identity named Object ID (OID).
            //Here I added “Client Authentication” enhanced key usage extension to the certificate by specifying its OID “1.3.6.1.5.5.7.3.2”.

            //objObjectId.InitializeFromValue("1.3.6.1.5.5.7.3.2");
            objObjectId.InitializeFromValue(objectId);

            objObjectIds.Add(objObjectId);
            objX509ExtensionEnhancedKeyUsage.InitializeEncode(objObjectIds);
            objPkcs10.X509Extensions.Add((CX509Extension)objX509ExtensionEnhancedKeyUsage);

            var objDN = new CX500DistinguishedName();

            //CN:Common Name
            //C: Country(Must be 2 letter.)
            //S: State
            //L: Locality
            //O: Organization
            //OU:Organization Unit
            //E: Email
            //var subjectName = "CN = navaseelan, OU = ADCS, O = paymentsecurity, L = nKan, S = R@g@ma, C = SL";
            //subjectName = "CN = seucredP@yment, OU = secUreADCS, O = mBrain, L = SriL@nKan, S = R@g@ma, C = SL, E = navaseelan4u@gmail.com";

            subjectName = "CN = " + DeviceId + ", OU = " + PlatForm + ", O = " + Bank + ", L = SriL@nKan, S = R@g@ma, C = SL, E = " + EmailId;


            objDN.Encode(subjectName, X500NameFlags.XCN_CERT_NAME_STR_NONE);
            objPkcs10.Subject = objDN;
          
            var objEnroll = new CX509Enrollment();
            objEnroll.InitializeFromRequest(objPkcs10);
            var strRequest = objEnroll.CreateRequest(EncodingType.XCN_CRYPT_STRING_BASE64);

            return strRequest;


        }
        public int SendCertificateRequestCAServer(string message, string serverConfig)
        {
            var objCertRequest = new CCertRequest();
            var iDisposition = objCertRequest.Submit(
                    CR_IN_BASE64 | CR_IN_FORMATANY,
                    message,
                    //string.Empty, @"123.231.107.225\pal-CPAL-CA");
                    string.Empty, serverConfig);

            switch (iDisposition)
            {
                case CR_DISP_ISSUED:
                    Console.WriteLine("The certificate had been issued.");
                    break;
                case CR_DISP_UNDER_SUBMISSION:
                    Console.WriteLine("The certificate is still pending.");
                    break;
                default:
                    Console.WriteLine("The submission failed: " + objCertRequest.GetDispositionMessage());
                    Console.WriteLine("Last status: " + objCertRequest.GetLastStatus().ToString());
                    break;
            }
            return objCertRequest.GetRequestId();
        }
        public void DownloadAndInstallCert(int requestId, string serverConfig)
        {
            var objCertRequest = new CCertRequest();
            //var iDisposition = objCertRequest.RetrievePending(requestId, @"123.231.107.225\CPAL-CA");
            var iDisposition = objCertRequest.RetrievePending(requestId, serverConfig);

            if (iDisposition == CR_DISP_ISSUED)
            {
                var cert = objCertRequest.GetCertificate(CR_OUT_BASE64 | CR_OUT_CHAIN);
                var objEnroll = new CX509Enrollment();
                objEnroll.Initialize(X509CertificateEnrollmentContext.ContextUser);
                objEnroll.InstallResponse(
                    InstallResponseRestrictionFlags.AllowUntrustedRoot,
                    cert,
                   EncodingType.XCN_CRYPT_STRING_BASE64,
                    null);

                Console.WriteLine("The certificate had been installed successfully.");
            }
        }

        public int RenewCertificate(string certificateIdToFind, string serverConfig)
        {
            X509Certificate2 certificate = null;
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            try
            {
                store.Open(OpenFlags.ReadWrite);
                //certificate = store.Certificates.Find(X509FindType.FindByThumbprint, "c1555218deed2c6dbe5101178617ef7628388a85", false)[0];
                certificate = store.Certificates.Find(X509FindType.FindByThumbprint, certificateIdToFind, false)[0];

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                store.Close();
            }

            var objPkcs7 = new CX509CertificateRequestPkcs7();
            objPkcs7.InitializeFromCertificate(
               X509CertificateEnrollmentContext.ContextUser,
               true,
                 Convert.ToBase64String(certificate.RawData),
               EncodingType.XCN_CRYPT_STRING_BASE64,
                 X509RequestInheritOptions.InheritPrivateKey & X509RequestInheritOptions.InheritValidityPeriodFlag);

            var objEnroll = new CX509Enrollment();
            objEnroll.InitializeFromRequest(objPkcs7);
            var message = objEnroll.CreateRequest(EncodingType.XCN_CRYPT_STRING_BASE64);

            var objCertRequest = new CCertRequest();
            var iDisposition = objCertRequest.Submit(
                    CR_IN_BASE64 | CR_IN_FORMATANY,
               message,
               string.Empty,
              serverConfig);

            switch (iDisposition)
            {
                case CR_DISP_ISSUED:
                    Console.WriteLine("The certificate had been issued.");
                    break;
                case CR_DISP_UNDER_SUBMISSION:
                    Console.WriteLine("The certificate is still pending.");
                    break;
                default:
                    Console.WriteLine("The submission failed: " + objCertRequest.GetDispositionMessage());
                    Console.WriteLine("Last status: " + objCertRequest.GetLastStatus().ToString());
                    break;
            }

            return objCertRequest.GetRequestId();
        }

        public string DecodeCertificate(string certificate)
        {
            var subject = string.Empty;
           
            CX509CertificateRequestPkcs10 request = new CX509CertificateRequestPkcs10();
            request.InitializeDecode(certificate.Trim(), EncodingType.XCN_CRYPT_STRING_BASE64_ANY);
            request.CheckSignature();

       
            Console.WriteLine(((CX500DistinguishedName)request.Subject).Name);
            if (!string.IsNullOrWhiteSpace(((CX500DistinguishedName)request.Subject).Name))
            {
                subject = ((CX500DistinguishedName)request.Subject).Name;
                //var name= request.UIContextMessage;
                var data = subject.Split(',');

                //var certData = new DecodeCert {
                //    CommonName = data[0].ToString(),
                //    Organization = data[1].ToString(),
                //    OrganizationUnit = data[2].ToString(),
                //    Locality = data[3].ToString(),
                //    State = data[4].ToString(),
                //    Country = data[5].ToString(),
                //    EmailId = data[6].ToString()

                //};
               

            }

            return subject;
        }
        private class DecodeCert
        {
            public string CommonName { get; set; }
            public string Organization { get; set; }
            public string OrganizationUnit { get; set; }
            public string Locality { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string EmailId { get; set; }


        }

        public string EncodePkcs7(string signerCert,string certificateFromFile, string signerPassword)
        {
            var data = Encoding.UTF8.GetBytes(signerCert);

            //SIGNER PART, TAKE SOME PLAIN TEXT AND SIGN IT
            X509Certificate2 cert = new X509Certificate2(certificateFromFile, signerPassword);
            //debug data
            var msg = System.Text.ASCIIEncoding.ASCII.GetString(data);
            //--
            //Convert to array of bytes
            ContentInfo contentInfo = new ContentInfo(data);

            //New signedCMS object to perform the work
            SignedCms signedCms = new SignedCms(contentInfo, true); // <- true detaches the signature
            CmsSigner cmsSigner = new CmsSigner(cert);

            signedCms.ComputeSignature(cmsSigner);
            byte[] signature = signedCms.Encode();

            var signedDataInText = Convert.ToBase64String(signature);

            return signedDataInText;
        }

        public string EncodePkcs7(byte[] arMessage, string signerCert, string signerPassword)
        {
            //signerCert = @"C:\Users\N.Navaseelan\Desktop\LC\CASecurity.API\CACertificate\CertificateData\Certificates.pfx";
            //signerPassword = "navaseelan";

            //SIGNER PART, TAKE SOME PLAIN TEXT AND SIGN IT
            X509Certificate2 cert = new X509Certificate2(signerCert, signerPassword);
            //debug data
            var msg = System.Text.ASCIIEncoding.ASCII.GetString(arMessage);
            //--
            //Convert to array of bytes
            ContentInfo contentInfo = new ContentInfo(arMessage);

            //New signedCMS object to perform the work
            SignedCms signedCms = new SignedCms(contentInfo, true); // <- true detaches the signature
            CmsSigner cmsSigner = new CmsSigner(cert);

            signedCms.ComputeSignature(cmsSigner);
            byte[] signature = signedCms.Encode();

            var signedDataInText = Convert.ToBase64String(signature);
            

            return signedDataInText;
        }

        public bool ValidateSignedPkcs7(string signerCert, string signerPassword,string certificateFromFile)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes(signerCert);
                //certificateFromFile = @"C:\Users\N.Navaseelan\Desktop\LC\CASecurity.API\CACertificate\CertificateData\Certificates.pfx";
                signerPassword = "navaseelan";

                var signatureKey = EncodePkcs7(data, certificateFromFile, signerPassword);

                //contentInfo from the original message.
                ContentInfo contentInfo = new ContentInfo(System.Text.ASCIIEncoding.ASCII.GetBytes(signerCert));

                //SingedCms from the contentInfo above
                SignedCms signedCms = new SignedCms(contentInfo, true);

                //Here, I believe, I am attaching the signature I have to the Cms    
                signedCms.Decode(Convert.FromBase64String(signatureKey));

                //checking?
                signedCms.CheckSignature(true);
            }
            catch (Exception ex)
            {
               return  false;
            }
           
            return true;
        }

        //public bool Verify(SignedCms signedData)
        //{
        //    var myCetificates = new X509Store(StoreName.CertificateAuthority, StoreLocation.LocalMachine);
        //    myCetificates.Open(OpenFlags.ReadOnly);
        //    var certs = signedData.Certificates;

        //    return (from X509Certificate2 cert in certs
        //            select myCetificates.Certificates.Cast<X509Certificate2>()
        //                .Any(crt => crt.Thumbprint == cert.Thumbprint))
        //        .Any();

        //}

        public static string Sign(byte[] data, X509Certificate2 certificate)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (certificate == null)
                throw new ArgumentNullException("certificate");

            //1 setup the data to sign           
            Oid digestOid = new Oid("1.2.840.113549.1.7.2");//pkcs7 signed 
            ContentInfo content = new ContentInfo(digestOid, data);
            try
            {
                //2,SignerCms
                SignedCms signedCms = new SignedCms(content, true); //detached = true           

                //3. CmsSigner
                CmsSigner signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);

                signer.DigestAlgorithm = new Oid("1.3.14.3.2.26");//sha1

                //4.create signature
                signedCms.ComputeSignature(signer);

                //5,to Base64
                byte[] signEnv = signedCms.Encode();
                return Convert.ToBase64String(signEnv);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
