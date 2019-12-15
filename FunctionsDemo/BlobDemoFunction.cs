using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionsDemo
{
    public static class BlobDemoFunction
    {
        [FunctionName("BlobDemoFunction")]
        public static void Run(
            [BlobTrigger("input/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, 
            [Blob("output/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")]Stream outputBlob, 
            string name, 
            ILogger log)
        {
            var len = myBlob.Length;
            myBlob.CopyTo(outputBlob);
        }
    }
}
