namespace Contracts.Bills
{
    public record CreateBillRequest(
        decimal Amount,
        string Currency,
        string HostId,
        string DinnerId
    );
}
