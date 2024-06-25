using MassTransit;
using SupportManagement.Infrastructure;

namespace SupportManagement.Services;

public class SupportService
{
    private readonly SupportRepository _supportRepository;
    private readonly IBus _bus;

    public SupportService(SupportRepository supportRepository, IBus bus)
    {
        _supportRepository = supportRepository;
        _bus = bus;
    }
}
