# Emprestimos
Arquitetura

Tecnologias adotadas.
•	Kinesis Data Streams - Mensagens
o	Amazon SQS possui limite de 10 mensagens por lote.
o	Hospedagem em 3 zonas.
o	Alocação de 200 estilhaços (shards), throughput de ingestão máxima 200.000 mensagens ou 200 megabytes por segundo.
o	Custo elevado, variável não considerada pelo case mas traz possibilidade de tempo real.
•	DynamoDB – Banco de dados orientado a documentos.
•	Amazon ECS – Container instance.
o	Microsserviços escritos em .NET 5.
o	Pode ser usado o AWS Lambda caso serverless seja desejado.
•	Amazon ECR – Container registry.
•	AWS Key Management Service – Armazenamento das credenciais.
•	Amazon API Gateway – Gerenciamento das rotas dos microsserviços.
Microsserviços
1.	ProcessarRecebiveis, recebe mensagens com a carteira de recebíveis, faz as validações e armazena no banco de dados DynamoDB.
2.	Lambda function consumindo em paralelo as mensagens da carteira de recebíveis e gravando em uma instância separada de DynamoDB.
3.	ConsultarLimite, consulta o saldo consolidado no DynamoDB de recebíveis e empréstimos já realizados.
4.	ConcederEmpréstimos, Consulta o limite do cliente, faz conceção de novos empréstimos.

Banco de dados
Para todas as soluções a recomendação é utilizar o DynamoDB pela possibilidade de escalar facilmente, dados estruturados de maneira não relacional, desempenho excelente e possibilidade de particionar por agência ou outra chave natural.

Observability

•	Monitoramento da saúde dos Microsserviços, processamento, memória com alarme.
o	Erros que podem gerar problemas de disponibilidade na aplicação.
•	Análise de logs das aplicações, application insights
o	Configuração de biblioteca de application insights em .NET, monitoramento detalhado da aplicação de conceção de crédito.
•	Monitoramento do status dos serviços da AWS.
•	Configuração de auto scaling.
•	Utilizar a biblioteca Amazon CloudWatch e gravar logs no DynamoDB.

Código de microserviço

Anexo no e-mail, enviado o microserviço de ingestão da carteira de recebíveis, no exemplo utilizei a plataforma Azure por ter mais familiaridade.
