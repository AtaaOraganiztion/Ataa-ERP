using SharedKernel;

namespace Domain.FileUploads.Constraints;

public class FileUploadConstraints : BaseConstraints
{
    public const int ContentTypeMaxLength = 100;
    public const int ExtensionMaxLength = 15;
    public const int UploadForMaxLength = 15;
}
