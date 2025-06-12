namespace SequenciaNumerica.Domain.Entities;

public class SequenciaNum
{
    public List<int> Valores { get; }

    public SequenciaNum(List<int> valores)
    {
        if (valores == null || !valores.Any())
            throw new ArgumentException("A sequência não pode estar vazia.");

        Valores = valores;
    }
}
