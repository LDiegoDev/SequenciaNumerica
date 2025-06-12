using SequenciaNumerica.Application.Services;
using SequenciaNumerica.Domain.Entities;

namespace SequenciaNumerica.Tests;

public class SequenciaServiceTests
{
    private readonly SequenciaService _service = new();

    [Fact]
    public void DeveRetornarCrescente()
    {
        var input = new SequenciaNum(new List<int> { 1, 2, 3 });
        var resultado = _service.Analisar(input);
        Assert.True(resultado.ECrescente);
    }

    [Fact]
    public void DeveRetornarDecrescente()
    {
        var input = new SequenciaNum(new List<int> { 5, 4, 3 });
        var resultado = _service.Analisar(input);
        Assert.True(resultado.EDecrescente);
    }

    [Fact]
    public void DeveDetectarRepetidos()
    {
        var input = new SequenciaNum(new List<int> { 1, 2, 2 });
        var resultado = _service.Analisar(input);
        Assert.True(resultado.PossuiRepetidos);
    }

    [Fact]
    public void DeveDetectarAlternada()
    {
        var input = new SequenciaNum(new List<int> { 1, 3, 2, 4 });
        var resultado = _service.Analisar(input);
        Assert.True(resultado.EAlternada);
    }

    [Fact]
    public void DeveVerificarPrimos()
    {
        var input = new SequenciaNum(new List<int> { 2, 3, 5, 7 });
        var resultado = _service.Analisar(input);
        Assert.True(resultado.TodosPrimos);
    }
}
