// Main Program - Program.cs
using Microsoft.VisualBasic.FileIO;
using System;
using TF.Entities;
using TF.Entities.Enums;
using TF.Services;

namespace TF
{
    class Program
    {
        static void Main(string[] args)
        {

            MainMenu();

        }

        //
        //
        //MENUS
        //
        //
        public static void MainMenu()
        {
            UnitService unitService = new UnitService();
            PatientService patientService = new PatientService();

            //Insere automatismos e associa às unidades
            InserUnitsAuto(unitService);

            Console.WriteLine("\n\nBem-vindo ao Sistema de Gestão da RNCCI");
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Gerir Unidades");
            Console.WriteLine("2. Gerir Admissões");
            Console.WriteLine("4. Consultar Relatórios");
            Console.WriteLine("5. Ver Unidades");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    ManageUnity(unitService);
                    break;
                case "2":
                    Console.Clear();
                    ManagePatient(patientService, unitService);
                    break;
                case "3":
                    Console.WriteLine("Funcionalidade não implementada ainda.");
                    break;
                case "4":
                    Console.WriteLine("Funcionalidade não implementada ainda.");
                    break;
                case "5":
                    Console.Clear();
                    ListUnits(unitService);
                    return;
                case "6":
                    Console.WriteLine("Encerrando o sistema...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    MainMenu();
                    break;
            }
        }


        //
        //
        //SUBMENU
        //
        //

        //
        //UNIDADES
        //Gere as Unidades - adiciona e consulta
        public static void ManageUnity(UnitService unitService)
        {
            Console.WriteLine("\n\n[Gerir Unidades]");
            Console.WriteLine("1. Inserir Unidade");
            Console.WriteLine("2. Consultar Unidade");
            Console.WriteLine("3. Voltar");
            Console.Write("Escolha uma opção: ");

            int option = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("\n\n[Inserir Unidade]");
                    Console.Write("Nome da Unidade: ");
                    string name = Console.ReadLine();
                    Console.Write("Distrito da Unidade: ");
                    District district = Enum.Parse<District>(Console.ReadLine());
                    Console.Write("Zona (Norte, Sul ou Centro): ");
                    Zone zone = Enum.Parse<Zone>(Console.ReadLine());
                    Console.Write("Capacidade da Unidade: ");
                    int maxCapacity = int.Parse(Console.ReadLine());
                    Console.Write("Tipo da Unidade (UC, UMDR, ULDM): ");
                    string type = Console.ReadLine();
                    UsTypes usType = Enum.Parse<UsTypes>(type.ToUpper());
                    Unit newUnity = new Unit(unitService.ListUnits().Count + 1, name, maxCapacity, district, usType, zone);
                    unitService.AddUnit(newUnity);
                    Console.WriteLine("\nUnidade inserida com sucesso!\n");
                    Console.Clear();
                    ManageUnity(unitService);
                    break;
                case 2:
                    ConsultUnit(unitService);
                    break;
                case 3:
                    MainMenu();
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    ManageUnity(unitService);
                    break;
            }

        }
        //Gere a Unidade - edita, pesquisa, remove, atualiza
        public static void ConsultUnit(UnitService unitService)
        {
            Console.WriteLine("\n\n[Consultar Unidade]");
            Console.WriteLine("1. Pesquisar por ID");
            Console.WriteLine("2. Pesquisar por Nome");
            Console.WriteLine("3. Voltar");
            Console.Write("Escolha uma opção: ");
            int option = int.Parse(Console.ReadLine());
            Console.Clear();
            Unit existingUnit;

            switch (option)
            {
                case 1:
                    Console.Write("ID da Unidade a Consultar: ");
                    int id = int.Parse(Console.ReadLine());
                    existingUnit = unitService.GetUnit(id);
                    if (existingUnit == null)
                    {
                        do
                        {
                            Console.WriteLine("\n\nNão existe nenhum unidade com esse ID.");
                            Console.Write("ID da Unidade a Consultar: ");
                            id = int.Parse(Console.ReadLine());
                            existingUnit = unitService.GetUnit(id); ;
                        } while (existingUnit == null);
                    }
                    break;
                case 2:
                    Console.Write("Nome da Unidade a Consultar: ");
                    string name = Console.ReadLine();
                    existingUnit = unitService.GetUnitName(name);
                    if (existingUnit == null)
                    {
                        do
                        {
                            Console.WriteLine("\n\nNão existe nenhum unidade com esse ID.");
                            Console.Write("Nome da Unidade a Consultar: ");
                            name = Console.ReadLine();
                            existingUnit = unitService.GetUnitName(name);
                        } while (existingUnit == null);
                    }
                    break;
                case 3:
                    existingUnit = new Unit(); //Para corrigir erro abaixo
                    ManageUnity(unitService);
                    break;
                default:
                    existingUnit = new Unit(); //Para corrigir erro abaixo
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    ConsultUnit(unitService);
                    break;
            }
            Console.Clear();

            ServicesUnit(existingUnit, unitService);

        }

        //Gerir Serviços da Unidade
        public static void ServicesUnit(Unit unit, UnitService unitService)
        {
            Console.WriteLine($"\n\nUnidade de Saúde: {unit.Name}");
            Console.WriteLine($"Zona: {unit.Zone}");
            Console.WriteLine($"Distrito: {unit.District}");
            Console.WriteLine($"Capacidade Máxima: {unit.MaxCapacity}");
            Console.WriteLine($"Tipo: {unit.UsType} \n\n");

            Console.WriteLine("1. Atualizar Unidade");
            Console.WriteLine("2. Eliminar Unidade");
            Console.WriteLine("3. Ver Pacientes");
            Console.WriteLine("4. Voltar");
            Console.Write("Escolha uma opção: ");
             int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    unitService.UpdateUnit(unit);
                    Console.WriteLine("\n\nUnidade atualizada com sucesso!");
                    //Volta para o menu dentro da pesquisa da entidade
                    Console.Clear();
                    ManageUnity(unitService);
                    break;
                case 2:
                    unitService.RemoveUnit(unit);
                    Console.WriteLine("Unidade eliminada com sucesso!");
                    //Volta para o menu dentro da pesquisa da entidade
                    Console.Clear();
                    ManageUnity(unitService);
                    break;
                case 3:
                    //VerPacientes(unidades); //TO DO
                    break;
                case 4:
                    //Volta para o menu dentro da pesquisa da entidade
                    Console.Clear();
                    ManageUnity(unitService);
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    ServicesUnit(unit, unitService);
                    break;
            }
        }

        //Lista as Unidades
        public static void ListUnits(UnitService unitService)
        {
            List<Unit> units = new List<Unit>();
            units = unitService.ListUnits();

            foreach (Unit unit in units)
            {
                Console.WriteLine($"Nome da Unidade: {unit.Name} | Tipologia: {unit.UsType} | Capaciade: {unit.MaxCapacity} | Distrito: {unit.District} | Zona: {unit.Zone} |");
            }

            Console.WriteLine("\n\n1. Voltar");
            Console.Write("Escolha uma opção: ");
            int option = int.Parse(Console.ReadLine());

            MainMenu();
            Console.Clear();

        }

        //
        //ADMISSÕES
        //Gere as Admissões
        public static void ManagePatient(PatientService patientService, UnitService unitService)
        {
            Console.WriteLine("\n\n[Gerir Admissões]");
            Console.WriteLine("1. Admitir Paciente");
            Console.WriteLine("2. Trânsferir Paciente");
            Console.WriteLine("3. Dar Alta Paciente");
            Console.WriteLine("4. Atualizar Dados Paciente");
            Console.WriteLine("5. Voltar");
            Console.Write("Escolha uma opção: ");
            int option = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (option)
            {
                case 1:
                    //Admitir Paciente
                    break;
                case 2:
                    //Trânferir Paciente
                    break;
                case 3:
                    //Remover Paciente
                    break;
                case 4:
                    //UpdatePatient(patientService);
                    //Pesquisa
                    Console.Write("Número de Saúde do Paciente: ");
                    int numeroSaude = int.Parse(Console.ReadLine());
                    Patient patient = patientService.GetPatientHealthNumber(numeroSaude);
                    if (patient == null)
                    {
                        do
                        {
                            Console.WriteLine("\n\nNão existe nenhum paciente com esse Número de Saúde.");
                            Console.Write("Número de Saúde do Paciente: ");
                            numeroSaude = int.Parse(Console.ReadLine());
                            patient = patientService.GetPatientHealthNumber(numeroSaude);
                        } while (patient == null);
                    }
                    patientService.UpdatePatient(patient);
                    Console.WriteLine("\n\nPaciente atualizado com sucesso!");
                    //Volta para o menu
                    Console.Clear();
                    ManagePatient(patientService, unitService);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    ManagePatient(patientService, unitService);
                    break;

            }
        }
        //
        //
        //AUXILIARES
        //
        //
        public static void InserUnitsAuto(UnitService unitService)
        {
            //Braga
            for (int i = 0; i < 5; i++)
            {
                string unidade = "Unidade " + (i + 1).ToString();
                Unit newUnity = new Unit(unitService.ListUnits().Count + 1, unidade, 150, District.Braga, UsTypes.UC, Zone.Norte);
                unitService.AddUnit(newUnity);
            }
            //Lisboa
            for (int i = 6; i < 10; i++)
            {
                string unidade = "Unidade " + (i + 1).ToString();
                Unit newUnity = new Unit(unitService.ListUnits().Count + 1, unidade, 150, District.Lisboa, UsTypes.ULDM, Zone.Sul);
                unitService.AddUnit(newUnity);
            }
        }
    }
}

