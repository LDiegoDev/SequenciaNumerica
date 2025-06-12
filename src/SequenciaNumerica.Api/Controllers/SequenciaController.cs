using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SequenciaNumerica.Api.Models;
using SequenciaNumerica.Application.DTOs;
using SequenciaNumerica.Application.Interfaces;
using SequenciaNumerica.Application.Services;
using SequenciaNumerica.Domain.Entities;

namespace SequenciaNumerica.Api.Controllers;

[ApiController]
[Route("api/sequencia")]
public class SequenciaController : ControllerBase
{
    private readonly ISequenciaService _service;
    private readonly ILogger<SequenciaController> _logger;

    public SequenciaController(ISequenciaService service, ILogger<SequenciaController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost("analisar")]
    public async Task<ActionResult<SequenciaResultado>> Analisar(
        [FromBody] SequenciaInput input,
        [FromServices] IValidator<SequenciaInput> validator)
    {
        _logger.LogInformation("Recebida nova requisição para análise: {valores}", string.Join(",", input.Valores));

        var validationResult = await validator.ValidateAsync(input);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Requisição inválida");
            return BadRequest(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        var sequencia = new SequenciaNum(input.Valores);
        var resultado = _service.Analisar(sequencia);
        _logger.LogInformation("Resultado: {@resultado}", resultado);
        return Ok(resultado);
    }


    [HttpPost("ordenar")]
    public ActionResult<List<int>> Ordenar(
    [FromBody] SequenciaInput input,
    [FromServices] IValidator<SequenciaInput> validator)
    {
        var validation = validator.Validate(input);
        if (!validation.IsValid)
            return BadRequest(validation.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));

        var ordenada = input.Valores.OrderBy(x => x).ToList();
        return Ok(ordenada);
    }
}
