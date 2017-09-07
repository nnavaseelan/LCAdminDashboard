using CACertificate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDKApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtDetails.Text = string.Empty;
                var apiClient = new CSRApiHandler();
                var certificateGenerator = new CertificateGenerator();
                var certificateFromFile = @"C:\Users\N.Navaseelan\Desktop\LC\CASecurity.API\CACertificate\CertificateData\Certificates.pfx";
                var certText = "hello security world";
                var certPassword = "navaseelan";
                var hostUrl = "http://localhost:62000/";

               // var emailId = txtEmailId.Text;
               //// var deviceId = txtDeviceId.Text;
               // var passport = txtPassport.Text;
               // var nic = txtNIC.Text;

                var deviceId = "12345134436775";
                var appId = "12.24.32.63.221";
                var bankCode = "Cey1311Do13";
                var merchantId = "Mr11352253";
                var parameters = "Any combination";

                var firstName = "navaseelan";
                var lastName = "nadesan";
                var country = "Lk";
                var emailId = txtEmailId.Text;
                var passport = txtPassport.Text;
                var nic = txtNIC.Text;
                var packageName = "com.mBrain.testApp";

                //Mapping
                //UID : Identity Card Number or Passport(P: N3443534 or I: 546456456V)
                //CN: DEVICE_ID + MerchantID + BankID(YRT645645645645_564654_645646)
                //OU: MerchantID(6564564)
                //O: BankID(564654)
                //C: LK
                //L : Application Package Name(com.companyname.appname)
                //emailaddress: sonar @blade.com

                //set the parameters you want if this comma separated format
                parameters = string.Empty;
                parameters += "FirstName:"+firstName;
                parameters += ",LastName:" + lastName;
                parameters += ",EmailId:" + emailId;
                parameters += ",PassportNo:" + passport;
                parameters += ",NIC:" + nic;
                parameters += ",PackageName:" + packageName;
                parameters += ",Country:" + country;
                parameters += ",MerchantId:" + merchantId;
                //parameters += ",EmailId=" + emailId;
                //parameters += ",EmailId=" + emailId;
                //parameters += ",EmailId=" + emailId;


                var subjectName = "CN =" + deviceId +"-"+ merchantId+"-"+ bankCode +",OU = " + merchantId + ", O = " +bankCode + ", L = "+ packageName + ",C = "+ country + ", E = " + emailId;
                

                //txtDetails.Text += "Passing values to SDK " + Environment.NewLine;
                txtDetails.Text += " -------------------------------" + Environment.NewLine;
                txtDetails.Text += "Email Id :" + emailId + Environment.NewLine;
                txtDetails.Text += "Device Id :" + deviceId + Environment.NewLine;
                txtDetails.Text += "Passport Number :" + passport + Environment.NewLine;
                txtDetails.Text += "NIC Number :" + nic + Environment.NewLine;
                txtDetails.Text += " -------------------------------" + Environment.NewLine;
                txtDetails.Text += "Connecting to Host " + Environment.NewLine;
                txtDetails.Text += "Call api/bank/issue_challenge" + Environment.NewLine;
                txtDetails.Text += "Passig the values to api/bank/issue_challenge" + Environment.NewLine;

                var response = await apiClient.GetToken(hostUrl,deviceId, appId,bankCode,merchantId,parameters,string.Empty);

                txtDetails.Text += "-------------------------------" + Environment.NewLine;
                if (!string.IsNullOrEmpty(response.ChallengeToken))
                {
                    txtDetails.Text += "-------------------------------" + Environment.NewLine;

                    txtDetails.Text += "waiting for api response" + Environment.NewLine;
                    txtDetails.Text += "Access auth token :" + response.AccessToken + Environment.NewLine;
                    txtDetails.Text += "Challenge Token :" + response.ChallengeToken + Environment.NewLine;
                    txtDetails.Text += "-------------------------------" + Environment.NewLine;

                    txtDetails.Text += "Call api/client/clientdata" + Environment.NewLine;
                    txtDetails.Text += "Passig the values to api/client/clientdata" + Environment.NewLine;
                    txtDetails.Text += "Access auth token :" + response.AccessToken + Environment.NewLine;
                    txtDetails.Text += "Challenge Token :" + response.ChallengeToken + Environment.NewLine;
                    txtDetails.Text += "-------------------------------" + Environment.NewLine;

                    var clientdata = await apiClient.GetClientInFo(hostUrl, response.ChallengeToken);
                    txtDetails.Text += "waiting for api response" + Environment.NewLine;
                    if (!string.IsNullOrEmpty(clientdata.DeviceId))
                    {
                        txtDetails.Text += "-------------------------------" + Environment.NewLine;

                        txtDetails.Text += "Email Id :" + clientdata.EmailId + Environment.NewLine;
                        txtDetails.Text += "Device Id :" + clientdata.DeviceId + Environment.NewLine;
                        txtDetails.Text += "Passport No :" + clientdata.PassportNo + Environment.NewLine;
                        txtDetails.Text += "User NIC :" + clientdata.UserNIC + Environment.NewLine;
                        txtDetails.Text += "-------------------------------" + Environment.NewLine;

                        txtDetails.Text += "Calling to SDK to generate CSR" + Environment.NewLine;
                        txtDetails.Text += "Passing values to SDK to generating CSR" + Environment.NewLine;

                        //CN:Common Name
                        //C: Country(Must be 2 letter.)
                        //S: State
                        //L: Locality
                        //O: Organization
                        //OU:Organization Unit
                        //E: Email
                         txtDetails.Text += "-------------------------------" + Environment.NewLine;

                        //things to note
                        var cert = certificateGenerator.CreateCertRequestMessage("1.3.6.1.5.5.7.3.2", subjectName);
                        if (!string.IsNullOrEmpty(cert))
                        {
                            txtDetails.Text += "Creating CSR-PKCS 10" + Environment.NewLine;
                            txtDetails.Text += "======================CSR===========================" + Environment.NewLine;
                            txtDetails.Text += cert + Environment.NewLine;
                            txtDetails.Text += "======================CSR End===========================" + Environment.NewLine;

                            txtDetails.Text += " ------------------Decoding CSR -----------------" + Environment.NewLine;
                            var decodeCert = certificateGenerator.DecodeCertificate(cert);
                            var data = decodeCert.Split(',');

                            txtDetails.Text += data[0].ToString() + Environment.NewLine;
                            txtDetails.Text += data[1].ToString() + Environment.NewLine;
                            txtDetails.Text += data[2].ToString() + Environment.NewLine;
                            txtDetails.Text += data[3].ToString() + Environment.NewLine;
                            txtDetails.Text += data[4].ToString() + Environment.NewLine;
                            txtDetails.Text += data[5].ToString() + Environment.NewLine;
                            txtDetails.Text += "--------------End Decoding CSR ---------------" + Environment.NewLine;


                            txtDetails.Text += "Creating the CMS Envelop - PKCS 7" + Environment.NewLine;
                            txtDetails.Text += "Reading .pfx file to envelop" + Environment.NewLine;
                            txtDetails.Text += "sending signing text & password " + Environment.NewLine;

                            certText = cert;

                            var pkcs7Sign = certificateGenerator.EncodePkcs7(certText, certificateFromFile, certPassword);
                            txtDetails.Text += "--------------waiting---------------" + Environment.NewLine;
                            txtDetails.Text += pkcs7Sign + Environment.NewLine;
                            txtDetails.Text += "--------------End CMS Envelop - PKCS 7---------------" + Environment.NewLine;

                            var pkcs7SignValidate = certificateGenerator.ValidateSignedPkcs7(certText, certPassword, certificateFromFile);
                            txtDetails.Text += "--------------validating---------------" + Environment.NewLine;

                            if (pkcs7SignValidate)
                                txtDetails.Text += "Successfully validated" + Environment.NewLine;
                            else
                                txtDetails.Text += "validation failed" + Environment.NewLine;

                        }
                        else
                        {
                            txtDetails.Text += "some error occured in  Creating CSR-PKCS 10" + Environment.NewLine;
                        }

                    }
                    else
                    {
                        txtDetails.Text += "some error occured in  api/client/clientdata" + Environment.NewLine;
                    }


                }
                else
                {
                    txtDetails.Text += "some error occured in  api/bank/issuechallenge" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex);
            }
            
        }
    }
}
