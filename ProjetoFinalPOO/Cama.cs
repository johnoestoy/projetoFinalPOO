/*
Classe Cama

A classe Cama representa uma cama física na unidade e gerencia seu status de ocupação.


*/

public class Cama
{
    public int Id { get; set; }
    public string Status { get; private set; } = "Disponivel"; // Disponível ou Ocupada
    public Utente UtenteAssociado { get; private set; }

    public Cama(int id)
    {
        Id = id;
    }

    public void AssociarUtente(Utente utente)
    {
        if (Status == "Disponivel")
        {
            UtenteAssociado = utente;
            Status = "Ocupada";
            Console.WriteLine($"Utente {utente.Nome} foi associado à cama {Id}.");
        }
        else
        {
            Console.WriteLine($"Cama {Id} já está ocupada.");
        }
    }

    public void Liberar()
    {
        if (Status == "Ocupada")
        {
            Console.WriteLine($"Cama {Id} liberada. Utente {UtenteAssociado.Nome} foi removido.");
            UtenteAssociado = null;
            Status = "Disponivel";
        }
        else
        {
            Console.WriteLine($"Cama {Id} já está disponível.");
        }
    }
}