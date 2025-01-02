using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using Mitarbeitershop_Hydro.Helpers.HelpersModels;
using Mitarbeitershop_Hydro.Helpers.IHelpersServices;

namespace Mitarbeitershop_Hydro.Helpers.HelpersServces
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IOptions<CloudinarySettings> config)
        {
            _cloudinary = new Cloudinary(config.Value.CloudinaryUrl);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParms = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParms);
            return result;
        }

    }
}
