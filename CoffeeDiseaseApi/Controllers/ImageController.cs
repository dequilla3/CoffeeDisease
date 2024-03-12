using CoffeeDiseaseApi.DTOs;
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
                var results = CoffeeDiseaseModel.PredictAllLabels(sampleData);

                List<Model> model = [];

                foreach (var res in results)
                {
                    model.Add(new Model() { ClassName = res.Key, Score  = Math.Round(res.Value * 100, 2) });
                }

                return Ok(new Response() { Models = model});
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
 
}
