namespace Mango.Services.ProductAPI.Model.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessages { get; set; } = string.Empty;
        public List<string> ErrorMessages { get; set; }

    }
}
