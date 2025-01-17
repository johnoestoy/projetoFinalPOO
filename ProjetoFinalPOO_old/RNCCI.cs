/*Classe RNCCI

Atributos
	•	Unidades: Lista de todas as unidades de saúde na rede.
	•	FilaEspera: Fila de espera global para utentes aguardando vaga.
*/
using System;
using System.Collections.Generic;
using System.Linq;

public static class RNCCI
{
    public static List<UnidadeSaude> Unidades { get; set; } = new List<UnidadeSaude>();
    public static Queue<Utente> FilaEspera { get; set; } = new Queue<Utente>();

    public static void AdicionarUnidade(UnidadeSaude unidade)
    {
        Unidades.Add(unidade);
        Console.WriteLine($"Unidade {unidade.Nome} adicionada à RNCCI.");
    }

    public static void RegistrarUtenteFila(Utente utente)
    {
        FilaEspera.Enqueue(utente);
        Console.WriteLine($"Utente {utente.Nome} (Nº Utente: {utente.NumeroUtente}) foi adicionado à fila de espera.");
    }

    public static UnidadeSaude SelecionarUnidadeDisponivel(Utente utente)
    {
        foreach (var unidade in Unidades.OrderBy(u => u.Localizacao))
        {
            if (unidade.ObterCamasDisponiveis() > 0)
            {
                return unidade;
            }
        }
        return null;
    }

    public static void InternarUtenteFila()
{
    if (FilaEspera.Count == 0)
    {
        Console.WriteLine("Nenhum utente na fila de espera.");
        return;
    }

    Utente utente = FilaEspera.Dequeue();
    UnidadeSaude unidade = SelecionarUnidadeDisponivel(utente);

    if (unidade != null)
    {
        unidade.RegistrarInternamento(utente, DateTime.Now);

        // Verificar transferências automáticas após internamento
        VerificarTransferencias(30, 90, 120);
    }
    else
    {
        Console.WriteLine($"Nenhuma unidade disponível para o utente {utente.Nome}.");
        RegistrarUtenteFila(utente); // Recoloca na fila caso não haja vagas
    }
}

    public static void TransferirUtente(Utente utente)
    {
        UnidadeSaude unidadeOrigem = utente.UnidadeAtual;
        UnidadeSaude unidadeDestino = SelecionarUnidadeDisponivel(utente);

        if (unidadeDestino != null && unidadeOrigem != null)
        {
            unidadeOrigem.LiberarCama(utente.CamaAtual);
            unidadeDestino.RegistrarInternamento(utente, DateTime.Now);

            Console.WriteLine($"Utente {utente.Nome} foi transferido da unidade {unidadeOrigem.Nome} para {unidadeDestino.Nome}.");
        }
        else
        {
            Console.WriteLine($"Utente {utente.Nome} foi colocado na fila de espera por falta de vagas.");
            RegistrarUtenteFila(utente);
        }
    }

    public static void VerificarTransferencias(int limiteDiasUC, int limiteDiasUMDR, int limiteDiasULDM)
    {
        foreach (var unidade in Unidades)
        {
            foreach (var utente in unidade.ListarUtentes())
            {
                TimeSpan tempoInternado = DateTime.Now - utente.DataEntrada;

                int limiteDias = unidade switch
                {
                    UnidadeConvalescenca => limiteDiasUC,
                    UnidadeMediaDuracaoReabilitacao => limiteDiasUMDR,
                    UnidadeLongaDuracaoManutencao => limiteDiasULDM,
                    _ => int.MaxValue // Unidades sem limite
                };

                if (tempoInternado.TotalDays > limiteDias)
                {
                    Console.WriteLine($"Utente {utente.Nome} (Nº Utente: {utente.NumeroUtente}) excedeu o limite de {limiteDias} dias na unidade {unidade.Nome}.");
                    TransferirUtente(utente);
                }
            }
        }
    }

    public static void GerarRelatorioOcupacao()
    {
        Console.WriteLine("Relatório de Ocupação das Unidades:");
        foreach (var unidade in Unidades)
        {
            int camasDisponiveis = unidade.ObterCamasDisponiveis();
            int camasOcupadas = unidade.CapacidadeMaxima - camasDisponiveis;

            Console.WriteLine($"- Unidade: {unidade.Nome}");
            Console.WriteLine($"  Localização: {unidade.Localizacao}");
            Console.WriteLine($"  Capacidade: {unidade.CapacidadeMaxima}");
            Console.WriteLine($"  Ocupadas: {camasOcupadas}");
            Console.WriteLine($"  Disponíveis: {camasDisponiveis}");
        }
    }
}