using SequenciaNumerica.Application.DTOs;
using SequenciaNumerica.Domain.Entities;

namespace SequenciaNumerica.Application.Interfaces;

public interface ISequenciaService
{
    SequenciaResultado Analisar(SequenciaNum sequencia);
}
