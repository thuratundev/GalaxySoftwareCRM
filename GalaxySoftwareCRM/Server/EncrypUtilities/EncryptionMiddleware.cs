using GalaxySoftwareCRM.Server.JwtUtilities;
using GalaxySoftwareCRM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace GalaxySoftwareCRM.Server.EncryptUtilities
{
    public class EncryptionMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        const string ENCRYPTIONKEY = "TH!$C0NTENT!$ENCRYPTEDBYW@R10CK";
        public EncryptionMiddleware(RequestDelegate _requestDelegate)
        {
            requestDelegate = _requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Body = EncryptStream(context.Response.Body);
            context.Request.Body = DecryptStream(context.Request.Body);
            //if (context.Request.QueryString.HasValue)
            //{
            //    string decryptedString = DecryptString(context.Request.QueryString.Value.Substring(1));
            //    context.Request.QueryString = new QueryString($"?{decryptedString}");
            //}
            await requestDelegate(context);
            await context.Request.Body.DisposeAsync();
            await context.Response.Body.DisposeAsync();
        }

        private static CryptoStream EncryptStream(Stream responseStream)
        {
            Aes aes = GetEncryptionAlgorithm();

            ToBase64Transform base64Transform = new ToBase64Transform();
            CryptoStream base64EncodedStream = new CryptoStream(responseStream, base64Transform, CryptoStreamMode.Write);
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            CryptoStream cryptoStream = new CryptoStream(base64EncodedStream, encryptor, CryptoStreamMode.Write);

            return cryptoStream;
        }

        private static Stream DecryptStream(Stream cipherStream)
        {
            Aes aes = GetEncryptionAlgorithm();

            FromBase64Transform base64Transform = new FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces);
            CryptoStream base64DecodedStream = new CryptoStream(cipherStream, base64Transform, CryptoStreamMode.Read);
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            CryptoStream decryptedStream = new CryptoStream(base64DecodedStream, decryptor, CryptoStreamMode.Read);
            return decryptedStream;
        }

        private static Aes GetEncryptionAlgorithm()
        {

            Aes aes = Aes.Create();
            //aes.Key = Encoding.ASCII.GetBytes(ENCRYPTIONKEY);
            //aes.IV = initialization_vector;

            return aes;
        }
    }


}
