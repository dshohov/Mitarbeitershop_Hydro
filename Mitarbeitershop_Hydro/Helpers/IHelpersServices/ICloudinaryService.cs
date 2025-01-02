using CloudinaryDotNet.Actions;

namespace Mitarbeitershop_Hydro.Helpers.IHelpersServices
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
