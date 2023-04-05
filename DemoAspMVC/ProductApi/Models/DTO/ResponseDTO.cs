namespace ProductApi.Models.DTO;

public class ResponseDTO
{
    public bool IsSuccess { get; set; } = true;
    public object Result { get; set; }
    public String DisplayMessage { get; set; } = "";
    public List<String> ErrorMessages { get; set; }
}