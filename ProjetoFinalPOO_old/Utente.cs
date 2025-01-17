/*Classe Utente

A classe Utente representa um paciente e contém atributos que identificam o utente, além de métodos para gerenciar sua entrada e saída do sistema.
*/

public class Utente
{
    public int NumeroUtente { get; set; } // Número único do utente
    public string Nome { get; set; }
    public string Doenca { get; set; }
    public UnidadeSaude UnidadeAtual { get; set; }
    public Cama CamaAtual { get; set; }
    public DateTime DataEntrada { get; set; }

    public Utente(int numeroUtente, string nome, string doenca)
    {
        NumeroUtente = numeroUtente;
        Nome = nome;
        Doenca = doenca;
    }

    public void RegistrarEntrada(UnidadeSaude unidade, Cama cama, DateTime dataEntrada)
    {
        UnidadeAtual = unidade;
        CamaAtual = cama;
        DataEntrada = dataEntrada;

        Console.WriteLine($"Utente {Nome} (Nº Utente: {NumeroUtente}) foi admitido na unidade {unidade.Nome} na cama {cama.Id} em {dataEntrada.ToShortDateString()}.");
    }

    public void RegistrarSaida()
    {
        if (UnidadeAtual != null && CamaAtual != null)
        {
            Console.WriteLine($"Utente {Nome} (Nº Utente: {NumeroUtente}) teve alta da unidade {UnidadeAtual.Nome}.");
        }
        else
        {
            Console.WriteLine($"Utente {Nome} (Nº Utente: {NumeroUtente}) não está associado a nenhuma unidade ou cama.");
        }

        UnidadeAtual = null;
        CamaAtual = null;
        DataEntrada = DateTime.MinValue;
    }
}