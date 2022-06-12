using BadPractices.Domain.Results;
using MediatR;

namespace BadPractices;

public struct SeasonCommand : IRequest<SeasonsResult>
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public string Country { get; set; }

}

public class SeasonWrapper : IRequest<SeasonsResult>
{
    public SeasonCommand Command { get; set; }

    public SeasonWrapper(SeasonCommand command)
    {
        Command = command;
    }

    public string Season { get; set; }

}