namespace ContextBack;

public class GetOrderListDbParameterDTO
{
    public string CompanyId { get; set; }
    public string DepartmentId { get; set; }
    public string SalesId { get; set; }
    public int OrderCount { get; set; }
}