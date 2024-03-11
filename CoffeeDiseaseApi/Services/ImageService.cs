using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CoffeeDiseaseApi.Services
{
    public class ImageService
    {
        public async Task<byte[]> ResizeImageAsync(IFormFile file, int width, int height)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Copy the contents of the uploaded image to a memory stream
                await file.CopyToAsync(memoryStream);

                // Reset the position of the memory stream to the beginning
                memoryStream.Position = 0;

                // Resize the image using ImageSharp
                using (var image = Image.Load(memoryStream))
                {
                    image.Mutate(x => x.Resize(width, height));

                    // Save the resized image to another memory stream
                    using (var outputStream = new MemoryStream())
                    {
                        image.Save(outputStream, new SixLabors.ImageSharp.Formats.Png.PngEncoder());

                        // Return the resized image as a byte array
                        return outputStream.ToArray();
                    }
                }
            }
        }
    }
}
