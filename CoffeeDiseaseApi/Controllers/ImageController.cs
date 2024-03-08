using Microsoft.AspNetCore.Mvc;

namespace CoffeeDiseaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
   
        [HttpPost("predict")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Predict([FromForm] ImageInputDto input)
        {
            if (input == null || input.Image == null || input.Image.Length == 0)
            {
                Console.WriteLine("Test");
                return BadRequest("Image file is required.");
            }

            // Read image bytes
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                await input.Image.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }

            // Now you can use 'imageBytes' for further processing

            //Load sample data
            CoffeeDiseaseModel.ModelInput sampleData = new()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = CoffeeDiseaseModel.Predict(sampleData);



            return Ok(new Response { ClassName = result.PredictedLabel, Score = Math.Round(result.Score.Max() * 100, 2) });
        }
    }
    public record Response
    {
        public string ClassName { get; init; } = null!;
        public object Score { get; init; } = null!;
    }
    public class ImageInputDto
    {
        public IFormFile Image { get; set; } = null!;
    }
}
