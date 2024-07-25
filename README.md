# Prova Sub
Essa POC foi criada para validação do projeto de Venda de Veiculos Online

## Technologies / Components implemented

- .NET 8
    - ASP.NET MVC Core
    - ASP.NET WebApi 
    - Background Services (Em desenvolvimento)

- Components / Services
    - Azure Service Bus (Em desenvolvimento)
    - PostgreSQL

## Justificativas de Arquitetura

### 1. Azure AppService
**Justificativa:**
- **Escalabilidade Automática:** Permite escalabilidade automática com base na demanda, sem necessidade de gerenciar servidores.
- **Desempenho e Confiabilidade:** Oferece SLAs de alta disponibilidade e desempenho.
- **Facilidade de Gerenciamento:** Integrado com ferramentas de desenvolvimento e CI/CD (Continuous Integration/Continuous Deployment).
- **Segurança Integrada:** Suporte para autenticação e autorização, integração com certificados SSL/TLS, e conformidade com regulamentos.

### 2. Azure Entra ID (Azure Active Directory)
**Justificativa:**
- **Gerenciamento de Identidade Centralizado:** Facilita o gerenciamento de identidades de usuários e controle de acesso em um único lugar.
- **Autenticação e Autorização Seguras:** Suporte para autenticação multifator (MFA), Single Sign-On (SSO) e políticas de acesso condicional.
- **Conformidade e Segurança:** Atende a vários padrões de conformidade e segurança, como GDPR, ISO/IEC 27001.

### 3. Azure Service Bus
**Justificativa:**
- **Desacoplamento e Escalabilidade:** Facilita a comunicação assíncrona entre diferentes partes de um sistema, permitindo escalabilidade independente.
- **Entrega Fiável de Mensagens:** Garantia de entrega de mensagens e suporte para transações.
- **Gerenciamento Simplificado:** Serviço totalmente gerenciado, reduzindo a sobrecarga operacional.

## Políticas de Segurança Implementadas

### Azure AppService
**Serviços de Segurança Utilizados:**
- **Certificados SSL/TLS:** Garante comunicação segura entre clientes e servidores.
- **Firewall de Aplicação Web (WAF):** Protege contra ataques comuns, como SQL injection e cross-site scripting (XSS).
- **Backup Automático:** Assegura a recuperação de dados em caso de falhas.

### Azure Entra ID (Azure Active Directory)
**Serviços de Segurança Utilizados:**
- **Autenticação Multifator (MFA):** Adiciona uma camada extra de segurança, exigindo mais de uma forma de verificação de identidade.
- **Políticas de Acesso Condicional:** Permitem aplicar regras de acesso baseadas em risco e contexto do usuário.
- **Gerenciamento de Identidades e Acesso (IAM):** Centraliza o controle de acesso e gerenciamento de permissões.

### Azure Service Bus
**Serviços de Segurança Utilizados:**
- **Criptografia de Dados em Trânsito e em Repouso:** Protege os dados contra acessos não autorizados durante a transmissão e armazenamento.
- **Controle de Acesso Baseado em Função (RBAC):** Permite definir permissões granulares para acesso ao serviço, garantindo que apenas usuários autorizados possam interagir com o serviço.

## Riscos e Ações de Mitigação

### Risco: Acesso Não Autorizado
**Ação de Mitigação:**
- Implementar RBAC e MFA, realizar auditorias regulares.

### Risco: Perda de Dados
**Ação de Mitigação:**
- Realizar backups regulares, armazenar backups de forma segura.

### Risco: Vazamento de Dados Sensíveis
**Ação de Mitigação:**
- Criptografar dados sensíveis, monitorar acessos e atividades.

### Risco: Ataques de Injeção de SQL
**Ação de Mitigação:**
- Utilizar ORM (Entity Framework) e validações de entrada rigorosas.

### Risco: Ataques de Phishing e Engenharia Social
**Ação de Mitigação:**
- Treinar usuários sobre segurança, implementar políticas de senha forte.

### Risco: Exploração de Vulnerabilidades
**Ação de Mitigação:**
- Manter o software atualizado, realizar testes de penetração regulares.

## Conclusão

A escolha de serviços serverless e/ou gerenciáveis no Azure, como Azure AppService, Azure Entra ID (Azure AD), e Azure Service Bus, permite construir uma solução escalável, segura e fácil de gerenciar. Essa abordagem reduz a complexidade operacional e permite focar no desenvolvimento e melhoria contínua da aplicação, enquanto o Azure gerencia a infraestrutura subjacente e a segurança.
