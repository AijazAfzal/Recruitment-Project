using OnlineExam.Business.Interfaces;
using OnlineExam.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Azure.Storage.Blobs;
using OnlineExam.Data;
using System.Linq;

namespace OnlineExam.Business.BusinessLayer
{
    public class EmailService : IEmailService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OnlineExamContext _onlineExamContext;

        public EmailService(IHttpClientFactory httpClientFactory, OnlineExamContext onlineExamContext)
        {
            _onlineExamContext = onlineExamContext;
            _httpClientFactory = httpClientFactory;
            
        }
        public async Task<bool> SendEmailAsync(ExamEmail email)
        {
            try
            {              
                var functionCode = "fR63ln50WQJCYqZzwXnIQyZfH4niZLhI95ontoSilTK03oJi25Gf7A==";
                var client = _httpClientFactory.CreateClient();
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, new Uri($"https://notifybyemail-dev.azurewebsites.net/api/SendEmail?code={functionCode}"))
                {
                    Content = GetStringContent(email)
                };
                var response = await client.SendAsync(httpRequest);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
        protected static StringContent GetStringContent(object input)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            return null;//new StringContent(JsonConvert.SerializeObject(input, settings), Encoding.UTF8, "application/json");
        }


        public async Task SaveResumeToBlob(IFormFile file,int userId)
        {
            var user = _onlineExamContext.Users.FirstOrDefault(e => e.UserId == userId);
            var filestream = file.OpenReadStream();
            var containerName = "interviewcandidates";
            FileInfo fileInfo = new FileInfo(file.FileName);
            var fileName = user.Email.ToString() + "_" + user.Technology+"_"+user.Experience+fileInfo.Extension;
            await UploadFileToBlob(containerName, fileName, filestream);
            user.UploadResume = fileName;
            await _onlineExamContext.SaveChangesAsync();
        }
     
        private async Task UploadFileToBlob(string containerName, string fileName, Stream filestream)
        {
            var storageAccount_connectionString = "DefaultEndpointsProtocol=https;AccountName=onlineexamresumes;AccountKey=0bYg0AsdBG5hl7kZV9pVin0n1O0KJ3NiJDVYf3iyWwjFIxsQ43T6myXAsuJK5e7EejAWBDeSwI4Q+AStOPAnWw==;EndpointSuffix=core.windows.net";

            var blobServiceClient = new BlobClient(connectionString: storageAccount_connectionString,blobContainerName: containerName, blobName: fileName);
            await blobServiceClient.UploadAsync(filestream);
        }
    }
}
