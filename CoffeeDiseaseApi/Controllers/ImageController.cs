using CoffeeDiseaseApi.Services;
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
            try {
                if (input == null || input.Image == null || input.Image.Length == 0)
                {
                    return BadRequest("Image file is required.");
                }

                var imageService = new ImageService();
                var resizedImage = await imageService.ResizeImageAsync(input.Image, 256, 256);


                //Load sample data
                CoffeeDiseaseModel.ModelInput sampleData = new()
                {
                    ImageSource = resizedImage,
                };

                //Load model and predict output
                var result = CoffeeDiseaseModel.Predict(sampleData);

                return Ok(new Response { ClassName = result.PredictedLabel, Score = Math.Round(result.Score.Max() * 100, 2) });
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
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
