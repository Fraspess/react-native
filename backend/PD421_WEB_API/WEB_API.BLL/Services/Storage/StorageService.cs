using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
namespace WEB_API.BLL.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly HttpClient _httpClient = new HttpClient(); 
        public async Task<string?> SaveImageAsync(IFormFile file)
        {
            string baseFolder = Path.Combine(StorageOptions.ImagesPath);
            string imageName = $"{Guid.NewGuid()}" + ".webp";
            string imagePath = Path.Combine(baseFolder, imageName);
            try
            {
                var stream = file.OpenReadStream();

                using (Image image = Image.Load(stream))
                    image.SaveAsWebp(imagePath);

                return imageName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: " + ex.Message);
                return null;
            }
        }

        public async Task<string?> SaveImageAsync(String url)
        {
            string baseFolder = Path.Combine(StorageOptions.ImagesPath);
            string imageName = $"{Guid.NewGuid()}" + ".webp";
            string imagePath = Path.Combine(baseFolder, imageName);
            try
            {                
                var stream = await _httpClient.GetStreamAsync(url);

                using (Image image = Image.Load(stream))
                    image.SaveAsWebp(imagePath);

                return imageName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: " + ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<IFormFile> files)
        {
            var tasks = files.Select(SaveImageAsync);
            var results = await Task.WhenAll(tasks);
            return results.Where(res => res != null)!;
        }

        public async Task<IEnumerable<string>> SaveImagesAsync(IEnumerable<String> urls)
        {
            var tasks = urls.Select(SaveImageAsync);
            var results = await Task.WhenAll(tasks);
            return results.Where(res => res != null)!;
        }

        public async Task DeleteImageAsync(string imageName)
        {
            var path = Path.Combine(StorageOptions.ImagesPath, imageName);
            if (File.Exists(path))
            {
                try
                {
                    await Task.Run(() =>
                    {
                        File.Delete(path);
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
