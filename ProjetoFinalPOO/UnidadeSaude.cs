/*
Classe UnidadeSaude

Atributos
	•	Nome: Nome da unidade.
	•	Localizacao: Localização da unidade.
	•	CapacidadeMaxima: Quantidade máxima de camas na unidade.
	•	Camas: Lista de camas disponíveis na unidade.
	•	Utentes: Lista de utentes atualmente internados na unidade.

Métodos
	1.	RegistrarInternamento: Adiciona um utente a uma cama disponível.
	2.	LiberarCama: Libera uma cama após a alta do utente.
	3.	ObterCamasDisponiveis: Retorna o número de camas disponíveis.
	4.	ListarUtentes: Lista os utentes atualmente internados.
	5.	MonitorarInternamentos: Verifica o tempo de internamento dos utentes.
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class UnidadeSaude
{
    public string Nome { get; set; }
    public string Localizacao { get; set; }
    public int CapacidadeMaxima { get; set; }
    public List<Cama> Camas { get; set; }
    public List<Utente> Utentes { get; set; }

    public UnidadeSaude(string nome, string localizacao, int capacidadeMaxima)
    {
        Nome = nome;
        Localizacao = localizacao;
        CapacidadeMaxima = capacidadeMaxima;
        Camas = new List<Cama>();
        Utentes = new List<Utente>();

        // Criar camas automaticamente com IDs únicos
        for (int i = 1; i <= capacidadeMaxima; i++)
        {
            Camas.Add(new Cama(i));
        }
    }

    public void RegistrarInternamento(Utente utente, DateTime dataEntrada)
    {
        var camaDisponivel = Camas.FirstOrDefault(c => c.Status == "Disponivel");

        if (camaDisponivel != null)
        {
            camaDisponivel.AssociarUtente(utente);
            utente.RegistrarEntrada(this, camaDisponivel, dataEntrada);
            Utentes.Add(utente);
            Console.WriteLine($"Utente {utente.Nome} foi internado na unidade {Nome} na cama {camaDisponivel.Id}.");
        }
        else
        {
            Console.WriteLine($"Não há camas disponíveis na unidade {Nome}.");
        }
    }

    public void LiberarCama(Cama cama)
    {
        if (cama.Status == "Ocupada")
        {
            Utente utente = cama.UtenteAssociado;
            utente.RegistrarSaida();
            cama.Liberar();
            Utentes.Remove(utente);
        }
        else
        {
            Console.WriteLine($"Cama {cama.Id} já está disponível.");
        }
    }

    public int ObterCamasDisponiveis()
    {
        return Camas.Count(c => c.Status == "Disponivel");
    }

    public List<Utente> ListarUtentes()
    {
        return Utentes;
    }

    public void MonitorarInternamentos(int limiteDias)
    {
        DateTime hoje = DateTime.Now;

        foreach (var utente in Utentes)
        {
            TimeSpan tempoInternamento = hoje - utente.DataEntrada;

            if (tempoInternamento.TotalDays >= limiteDias)
            {
                Console.WriteLine($"ALERTA: Utente {utente.Nome} já ultrapassou o limite de {limiteDias} dias de internamento na unidade {Nome}.");
            }
        }
    }
}