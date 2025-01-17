using TF.Entities;
using TF.Entities.Enums;

namespace TF.Services
{
    internal class UnitService
    {
        public List<Unit> units = new List<Unit>();

        public void AddUnit(Unit unit)
        {
            units.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            units.Remove(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            Console.WriteLine("\n\n[Atualizar Unidade]");
            Console.Write("Nome (deixe vazio para manter): ");
            unit.Name = Console.ReadLine();
            Console.Write("Distrito (deixe vazio para manter): ");
            unit.District = Enum.Parse<District>(Console.ReadLine());
            Console.Write("Zona (deixe vazio para manter): ");
            unit.Zone = Enum.Parse<Zone>(Console.ReadLine());
            Console.Write("Tipo da Unidade (UC, UMDR, ULDM) (deixe vazio para manter): ");
            string type = Console.ReadLine();
            unit.UsType = Enum.Parse<UsTypes>(type.ToUpper());
            Console.Write("Capacidade Máxima (deixe vazio para manter): ");
            unit.MaxCapacity = int.Parse(Console.ReadLine());
        }

        public List<Unit> ListUnits()
        {
            return units;
        }

        public Unit GetUnit(int id)
        {
            return units.FirstOrDefault(u => u.Id == id);
        }
        public Unit GetUnitName(string name)
        {
            return units.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateAvailableBeds(int unitId, int quantity)
        {
            var unit = units.FirstOrDefault(u => u.Id == unitId);
            if (unit != null)
            {
                //unit.AvailableBeds += quantity;
            }
        }
    }
}

