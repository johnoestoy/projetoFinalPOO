Entendimento do Sistema

A Rede Nacional de Cuidados Continuados Integrados (RNCCI) é composta por várias unidades de saúde, cada uma com tipologias específicas e características diferentes:
	1.	Unidade de Convalescença (UC):
	•	Internamento de até 30 dias.
	•	Ao atingir 25 dias, o sistema gera automaticamente uma solicitação de transferência para uma Unidade de Média Duração e Reabilitação (UMDR).
	2.	Unidade de Média Duração e Reabilitação (UMDR):
	•	Internamento de 30 a 90 dias.
	•	Ao atingir 85 dias, o sistema gera uma solicitação de transferência para uma Unidade de Longa Duração e Manutenção (ULDM).
	3.	Unidade de Longa Duração e Manutenção (ULDM):
	•	Internamento superior a 90 dias.
	•	Não possui limite de internamento, mas pode transferir pacientes para a Equipe Domiciliária de Cuidados Continuados Integrados (EDCCI), caso necessário.
	4.	Equipe Domiciliária de Cuidados Continuados Integrados (EDCCI):
	•	Atendimento domiciliar sem prazo de internamento.

Principais Requisitos
	1.	Gestão de Unidades e Tipologias:
	•	Inserir, atualizar, eliminar e consultar as unidades de saúde.
	•	Cada unidade deve controlar:
	•	Utentes internados.
	•	Camas disponíveis.
	•	Tipo de serviços oferecidos.
	2.	Gestão de Utentes:
	•	Inserção, atualização, exclusão e consulta de utentes.
	•	Cada doente está associado a uma unidade e a uma cama.
	•	Controle do tempo de internamento e movimentação (admissões, saídas, transferências).
	3.	Transferências Automáticas:
	•	O sistema deve monitorar o tempo de internamento dos utentes.
	•	Gerar automaticamente uma solicitação de transferência para a próxima unidade quando o prazo de internamento está próximo do limite.
	•	A transferência deve ser para a unidade mais próxima da família e com disponibilidade de camas.
	4.	Fila de Espera:
	•	Gerenciar uma fila de espera para entrada na rede.
	•	A seleção da unidade deve ser automática com base:
	•	Na disponibilidade de camas.
	•	Na proximidade da unidade em relação à residência do doente ou da família.
	5.	Gestão de Visitas:
	•	Registar visitas autorizadas por doente.
	•	Listar visitantes autorizados por unidade.
	•	Estatísticas sobre visitas (tempo médio de visita, % por tipo de doença, etc.).
	6.	Relatórios e Estatísticas:
	•	Relatório de ocupação por distrito e zona (Norte, Centro, Sul).
	•	Listagem de utentes por unidade e tipologia.
	•	Movimentos (admissões, saídas e transferências) por doente e cama.

Classes Identificadas

1. RNCCI
	•	Representa a rede nacional de cuidados.
	•	Atributos:
	•	Lista de unidades de saúde.
	•	Fila de espera global de utentes.
	•	Responsabilidades:
	•	Gerenciar as unidades e suas relações.
	•	Monitorar prazos de internamento e acionar transferências.
	•	Selecionar unidades para admissões e transferências.

2. UnidadeSaude (Classe Base)
	•	Representa uma unidade de saúde genérica.
	•	Atributos:
	•	Nome.
	•	Localização.
	•	Capacidade máxima (número de camas).
	•	Lista de camas.
	•	Lista de utentes.
	•	Responsabilidades:
	•	Gerenciar camas e internamentos.
	•	Monitorar prazos e gerar solicitações de transferência.
	•	Subclasses:
	•	UnidadeConvalescenca (UC): Prazo máximo de 30 dias.
	•	UnidadeMediaDuracaoReabilitacao (UMDR): Prazo máximo de 90 dias.
	•	UnidadeLongaDuracaoManutencao (ULDM): Sem limite, mas permite transferências.
	•	EquipeDomiciliaria (EDCCI): Atendimento domiciliar.
3. Cama
	•	Representa uma cama física na unidade.
	•	Atributos:
	•	ID.
	•	Status: Disponível ou Ocupada.
	•	Utente do Doente associado (se ocupada).
	•	Responsabilidades:
	•	Associar e liberar camas para utentes.
4. Doente
	•	Representa um paciente no sistema.
	•	Atributos:
	•	Nome.
    •	Utente.
	•	Tipo de doença.
	•	Unidade atual.
	•	Cama atual.
	•	Data de entrada.
	•	Responsabilidades:
	•	Registrar internamento, alta ou transferência.

5. FilaEspera
	•	Representa os utentes aguardando admissão.
	•	Atributos:
	•	Lista de utentes na fila.
	•	Responsabilidades:
	•	Organizar e priorizar a entrada de utentes na rede.
	•	Selecionar automaticamente uma unidade adequada.

6. Admissao
	•	Representa os movimentos de um doente na rede.
	•	Atributos:
	•	Utente.
	•	Unidade de origem.
	•	Unidade de destino.
	•	Tipo de movimento (admissão, alta, transferência).
	•	Data do movimento.
	•	Responsabilidades:
	•	Registrar os movimentos de um utente.

7. Visita
	•	Representa visitas feitas por familiares e amigos.
	•	Atributos:
	•	Visitante.
	•	Utente visitado.
	•	Data e duração da visita.
	•	Responsabilidades:
	•	Registrar visitas e gerar estatísticas.

8. Relatorio
	•	Gera informações consolidadas sobre a rede.
	•	Responsabilidades:
	•	Relatórios de ocupação por unidade, distrito e zona.
	•	Movimentos por doente e cama.
	•	Estatísticas sobre visitas.

Relações entre as Classes
	1.	RNCCI gerencia:
	•	Uma lista de UnidadeSaude.
	•	A fila de espera global.
	2.	UnidadeSaude:
	•	Contém uma lista de Cama.
	•	Contém uma lista de Utentes internados.
	3.	Utente:
	•	Está associado a uma UnidadeSaude e uma Cama.
	•	Está registrado na FilaEspera até a admissão.
	4.	Admissao:
	•	Relaciona Utente com UnidadeSaude e Cama.

Fluxo de Operações
	1.	Admissão de Utentes:
	•	Um utente entra na fila de espera.
	•	O sistema seleciona a unidade com base na proximidade e disponibilidade de camas.
	2.	Monitoramento de Internamentos:
	•	As unidades verificam o prazo de internamento dos utentes.
	•	Quando próximo ao limite, uma solicitação de transferência é gerada.
	3.	Transferências:
	•	A transferência ocorre automaticamente para a próxima unidade com base na tipologia.
	4.	Relatórios:
	•	Gerados periodicamente sobre ocupação, movimentos e visitas.