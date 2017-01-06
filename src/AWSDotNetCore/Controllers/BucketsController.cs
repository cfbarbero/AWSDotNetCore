using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amazon.S3;

namespace AWSDotNetCore.Controllers
{
    [Route("api/[controller]")]
    public class BucketsController : Controller
    {
        private IAmazonS3 S3Client;

        public BucketsController(IAmazonS3 s3Client)
        {
            this.S3Client = s3Client;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var buckets = S3Client.ListBucketsAsync();

            return buckets.Result.Buckets.Select(x => x.BucketName);
        }

    }
}
