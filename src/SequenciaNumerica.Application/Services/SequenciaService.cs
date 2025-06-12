using SequenciaNumerica.Application.DTOs;
using SequenciaNumerica.Application.Interfaces;
using SequenciaNumerica.Domain.Entities;
namespace SequenciaNumerica.Application.Services;

public class SequenciaService : ISequenciaService
{
    public SequenciaResultado Analisar(SequenciaNum sequencia)
    {
        var valores = sequencia.Valores;

        return new SequenciaResultado
        {
            ECrescente = EhCrescente(valores),
            EDecrescente = EhDecrescente(valores),
            PossuiRepetidos = PossuiRepetidos(valores),
            EAlternada = EhAlternada(valores),
            TodosPrimos = valores.All(EhPrimo)
        };
    }

    private bool EhCrescente(List<int> lista) =>
        lista.Zip(lista.Skip(1)).All(pair => pair.First < pair.Second);

    private bool EhDecrescente(List<int> lista) =>
        lista.Zip(lista.Skip(1)).All(pair => pair.First > pair.Second);

    private bool PossuiRepetidos(List<int> lista) =>
        lista.Count != lista.Distinct().Count();

    private bool EhAlternada(List<int> lista)
    {
        if (lista.Count < 3) return false;

        bool? sobe = null;
        for (int i = 1; i < lista.Count; i++)
        {
            if (lista[i] == lista[i - 1]) return false;

            var atualSobe = lista[i] > lista[i - 1];
            if (sobe != null && atualSobe == sobe) return false;

            sobe = atualSobe;
        }

        return true;
    }

    private bool EhPrimo(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }
}
